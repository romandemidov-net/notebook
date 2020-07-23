using System;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using Notebook.Common.Constants;
using System.Collections.Generic;
using Notebook.Common.Models.DtoModels;
using Notebook.Core.Services.Contracts;
using System.Configuration;

namespace Notebook.Forms
{
    /// <summary>
    /// The implementation of a people form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class PeopleForm : Form
    {
        /// <summary>
        /// The due time.
        /// </summary>
        private const int DUE_TIME = 10000; // Ms.

        /// <summary>
        /// The check birthday timer.
        /// </summary>
        protected System.Threading.Timer _checkBirthdayTimer;

        /// <summary>
        /// The country service.
        /// </summary>
        protected readonly ICountryService _countryService;

        /// <summary>
        /// The person service.
        /// </summary>
        protected readonly IPersonService _personService;

        /// <summary>
        /// Gets the people source.
        /// </summary>
        /// <value>
        /// The people source.
        /// </value>
        public BindingSource PeopleSource { get; private set; }

        /// <summary>
        /// Gets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        public BindingList<Country> Countries { get; private set; }

        /// <summary>
        /// Gets the person filter.
        /// </summary>
        /// <value>
        /// The person filter.
        /// </value>
        public PersonFilter PersonFilter { get; private set; }

        /// <summary>
        /// Gets the check birthday timer period.
        /// </summary>
        /// <value>
        /// The check birthday timer period.
        /// </value>
        public int CheckBirthdayTimerPeriod { get; private set; } // Milliseconds.

        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleForm"/> class.
        /// </summary>
        /// <param name="countryService">The country service.</param>
        /// <param name="personService">The person service.</param>
        public PeopleForm(ICountryService countryService, IPersonService personService)
        {
            InitializeComponent();

            _countryService = countryService;
            _personService = personService;

            InititalizeContent();
        }

        /// <summary>
        /// Inititalizes the content.
        /// </summary>
        private void InititalizeContent()
        {
            SetConfigurationValue();

            InitializePeopleGrid();

            InitializeCountryFilter();

            InitializeBirthdayFilters();

            PersonFilter = new PersonFilter();

            SetCheckBirthdayTimer();
        }

        /// <summary>
        /// Sets the configuration value.
        /// </summary>
        private void SetConfigurationValue()
        {
            CheckBirthdayTimerPeriod = int.Parse(ConfigurationManager.AppSettings["checkBirthdayPeriodMs"]);
        }

        /// <summary>
        /// Initializes the people grid.
        /// </summary>
        private void InitializePeopleGrid()
        {
            var people = _personService.GetAllPeopleWithTheirCountries()
                .OrderBy(p => p.Name)
                .ThenBy(p => p.LastName)
                .ToList();

            this.PeopleSource = new BindingSource();

            this.PeopleSource.DataSource = people;

            peopleGridView.DataSource = this.PeopleSource;
        }

        /// <summary>
        /// Initializes the country filter.
        /// </summary>
        private void InitializeCountryFilter()
        {
            var countries = new List<Country> { new Country { Id = null, Name = string.Empty } };

            var existedCountries = _countryService.GetAll();

            countries.AddRange(existedCountries);

            this.Countries = new BindingList<Country>(countries.OrderBy(c => c.Name).ToList());

            countryFilterComboBox.DisplayMember = "Name";
            countryFilterComboBox.ValueMember = "Id";

            countryFilterComboBox.DataSource = this.Countries;
        }

        /// <summary>
        /// Initializes the birthday filters.
        /// </summary>
        private void InitializeBirthdayFilters()
        {
            birthdayFilterStartDateTimePicker.CustomFormat = DateTimePickerCustomFormat.EMPTY;
            birthdayFilterStartDateTimePicker.Format = DateTimePickerFormat.Custom;

            birthdayFilterEndDateTimePicker.CustomFormat = DateTimePickerCustomFormat.EMPTY;
            birthdayFilterEndDateTimePicker.Format = DateTimePickerFormat.Custom;
        }

        /// <summary>
        /// Sets the check birthday timer.
        /// </summary>
        private void SetCheckBirthdayTimer()
        {
            var autoEvent = new System.Threading.AutoResetEvent(false);

            _checkBirthdayTimer = new System.Threading.Timer(CheckBirthdays, autoEvent, DUE_TIME, CheckBirthdayTimerPeriod);
        }

        /// <summary>
        /// Checks the birthdays.
        /// </summary>
        private void CheckBirthdays(Object stateInfo)
        {
            var people = _personService.GetAll();

            var personForNotification = new List<Person>();

            foreach (var person in people)
            {
                var birthdayAndTodayDifference = DateTime.Today.DayOfYear - person.Birthday.Value.DayOfYear;

                if (birthdayAndTodayDifference >= 0 && birthdayAndTodayDifference <= 2)
                {
                    personForNotification.Add(person);
                }
            }

            if (personForNotification.Any())
            {
                var messageBoxMessage = "Don't forget about the birthday(s) of:";

                foreach (var person in personForNotification)
                {
                    messageBoxMessage +=
                        $"\n{person.Name} {person.LastName} - {person.Birthday.Value.ToShortDateString()}";
                }

                MessageBox.Show(messageBoxMessage, "Let's congratulate!", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Handles the Click event of the addButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void addButton_Click(object sender, System.EventArgs e)
        {
            CreateOrUpdatePerson();
        }

        /// <summary>
        /// Handles the Click event of the editButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void editButton_Click(object sender, System.EventArgs e)
        {
            var selectedPerson = (Person) peopleGridView.CurrentRow.DataBoundItem;

            CreateOrUpdatePerson(selectedPerson);
        }

        /// <summary>
        /// Creates the or update person.
        /// </summary>
        /// <param name="selectedPerson">The selected person.</param>
        private void CreateOrUpdatePerson(Person selectedPerson = null)
        {
            using (var addEditPersonForm = new AddEditPersonForm(this.Countries.ToList(), selectedPerson))
            {
                var formResult = addEditPersonForm.ShowDialog(this);

                if (formResult == DialogResult.Cancel)
                {
                    return;
                }

                var updatedOrCreatedPerson = addEditPersonForm.Person;

                if (!updatedOrCreatedPerson.Id.HasValue)
                {
                    _personService.Create(updatedOrCreatedPerson);
                }
                else
                {
                    _personService.Update(updatedOrCreatedPerson);
                }

                UpdatePeopleSource();
            }
        }

        /// <summary>
        /// Handles the Click event of the deleteButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void deleteButton_Click(object sender, System.EventArgs e)
        {
            var selectedPerson = (Person)peopleGridView.CurrentRow.DataBoundItem;

            _personService.Delete(selectedPerson);

            UpdatePeopleSource();
        }

        /// <summary>
        /// Handles the TextChanged event of the lastNameFilterTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lastNameFilterTextBox_TextChanged(object sender, System.EventArgs e)
        {
            if (PersonFilter == null)
            {
                return;
            }

            PersonFilter.LastName = lastNameFilterTextBox.Text;

            UpdatePeopleSource();
        }

        /// <summary>
        /// Handles the ValueChanged event of the birthdayFilterStartDateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void birthdayFilterStartDateTimePicker_ValueChanged(object sender, System.EventArgs e)
        {
            if (PersonFilter == null)
            {
                return;
            }

            birthdayFilterStartDateTimePicker.CustomFormat = DateTimePickerCustomFormat.SHORT;

            var birthdayStartDate = birthdayFilterStartDateTimePicker.Value;

            if (PersonFilter.EndBirthday.HasValue && PersonFilter.EndBirthday.Value < birthdayStartDate)
            {
                birthdayFilterEndDateTimePicker.CustomFormat = DateTimePickerCustomFormat.EMPTY;

                PersonFilter.EndBirthday = null;
            }

            PersonFilter.StartBirthday = birthdayStartDate.Date;

            UpdatePeopleSource();
        }

        /// <summary>
        /// Handles the ValueChanged event of the birthdayFilterEndDateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void birthdayFilterEndDateTimePicker_ValueChanged(object sender, System.EventArgs e)
        {
            if (PersonFilter == null)
            {
                return;
            }

            birthdayFilterEndDateTimePicker.CustomFormat = DateTimePickerCustomFormat.SHORT;

            var birthdayEndDate = birthdayFilterEndDateTimePicker.Value;

            if (PersonFilter.StartBirthday.HasValue && PersonFilter.StartBirthday.Value > birthdayEndDate)
            {
                birthdayFilterStartDateTimePicker.CustomFormat = DateTimePickerCustomFormat.EMPTY;

                PersonFilter.StartBirthday = null;
            }

            PersonFilter.EndBirthday = birthdayEndDate.Date;

            UpdatePeopleSource();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the countryFilterComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void countryFilterComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (PersonFilter == null)
            {
                return;
            }

            PersonFilter.Country = (Country)countryFilterComboBox.SelectedItem;

            UpdatePeopleSource();
        }

        /// <summary>
        /// Updates the people source.
        /// </summary>
        private void UpdatePeopleSource()
        {
            if (PersonFilter == null)
            {
                return;
            }

            var people = _personService.GetFilteredPersonWithTheirCountries(PersonFilter)
                .OrderBy(p => p.Name)
                .ThenBy(p => p.LastName);

            this.PeopleSource.DataSource = people;

            this.PeopleSource.ResetBindings(false);
        }
    }
}
