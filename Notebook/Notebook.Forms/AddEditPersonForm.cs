using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using Notebook.Common.Constants;
using System.Collections.Generic;
using Notebook.Common.Models.DtoModels;

namespace Notebook.Forms
{
    public partial class AddEditPersonForm : Form
    {
        /// <summary>
        /// Gets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        protected BindingList<Country> Countries { get; private set; }

        /// <summary>
        /// Gets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        public Person Person { get; private set; }

        /// <summary>
        /// Gets a value indicating whether person instance is completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this person instance is completed; otherwise, <c>false</c>.
        /// </value>
        public bool PersonIsCompleted
        {
            get
            {
                return Person != null
                       && !string.IsNullOrEmpty(Person.Name)
                       && !string.IsNullOrEmpty(Person.LastName)
                       && !string.IsNullOrEmpty(Person.Phone)
                       && Person.Country != null
                       && Person.Birthday.HasValue;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddEditPersonForm"/> class.
        /// </summary>
        /// <param name="countries">The countries.</param>
        /// <param name="person">The person.</param>
        public AddEditPersonForm(List<Country> countries, Person person = null)
        {
            InitializeComponent();

            InitializeContent(countries, person);
        }

        /// <summary>
        /// Initializes the content.
        /// </summary>
        /// <param name="countries">The countries.</param>
        /// <param name="person">The person.</param>
        private void InitializeContent(List<Country> countries, Person person)
        {
            InitializeNameInput(person);

            InitializeLastNameInput(person);

            InitializeBirthdayInput(person);

            InitializeCountriesInput(countries, person);

            InitializePhoneInput(person);

            Person = person ?? new Person();

            ChangeOkButtonState();
        }

        /// <summary>
        /// Initializes the countries input.
        /// </summary>
        /// <param name="countries">The countries.</param>
        /// <param name="person">The person.</param>
        private void InitializeCountriesInput(List<Country> countries, Person person)
        {
            this.Countries = new BindingList<Country>(countries);

            countryComboBox.DisplayMember = "Name";
            countryComboBox.ValueMember = "Id";

            countryComboBox.DataSource = this.Countries;

            if (person == null)
            {
                return;
            }

            countryComboBox.SelectedIndex = countryComboBox.FindStringExact(person.CountryName);
        }

        /// <summary>
        /// Initializes the birthday input.
        /// </summary>
        /// <param name="person">The person.</param>
        private void InitializeBirthdayInput(Person person)
        {
            if (person == null)
            {
                birthdayDateTimePicker.CustomFormat = DateTimePickerCustomFormat.EMPTY;
                birthdayDateTimePicker.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                birthdayDateTimePicker.Value = person.Birthday.Value;
            }
        }

        /// <summary>
        /// Initializes the name input.
        /// </summary>
        /// <param name="person">The person.</param>
        private void InitializeNameInput(Person person)
        {
            if (person == null)
            {
                return;
            }

            nameTextBox.Text = person.Name;
        }

        /// <summary>
        /// Initializes the last name input.
        /// </summary>
        /// <param name="person">The person.</param>
        private void InitializeLastNameInput(Person person)
        {
            if (person == null)
            {
                return;
            }

            lastNameTextBox.Text = person.LastName;
        }

        /// <summary>
        /// Initializes the phone input.
        /// </summary>
        /// <param name="person">The person.</param>
        private void InitializePhoneInput(Person person)
        {
            if (person == null)
            {
                return;
            }

            phoneTextBox.Text = person.Phone;
        }

        /// <summary>
        /// Changes the state of the ok button.
        /// </summary>
        private void ChangeOkButtonState()
        {
            okButton.Enabled = PersonIsCompleted;
        }

        /// <summary>
        /// Handles the TextChanged event of the nameTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Person == null)
            {
                return;
            }

            Person.Name = nameTextBox.Text;

            ChangeOkButtonState();
        }

        /// <summary>
        /// Handles the TextChanged event of the lastNameTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Person == null)
            {
                return;
            }

            Person.LastName = lastNameTextBox.Text;

            ChangeOkButtonState();
        }

        /// <summary>
        /// Handles the ValueChanged event of the birthdayDateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void birthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (Person == null)
            {
                return;
            }

            var value = birthdayDateTimePicker.Value;

            if (value > DateTime.Now)
            {
                return;
            }

            birthdayDateTimePicker.CustomFormat = DateTimePickerCustomFormat.SHORT;

            Person.Birthday = value.Date;

            ChangeOkButtonState();
        }

        /// <summary>
        /// Handles the TextChanged event of the phoneTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Person == null)
            {
                return;
            }

            Person.Phone = phoneTextBox.Text;

            ChangeOkButtonState();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the countryComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Person == null)
            {
                return;
            }

            var value = (Country) countryComboBox.SelectedItem;

            if (value.Id.HasValue)
            {
                Person.Country = (Country)countryComboBox.SelectedItem;
            }
            else
            {
                Person.Country = null;
            }

            ChangeOkButtonState();
        }

        /// <summary>
        /// Handles the KeyDown event of the birthdayDateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void birthdayDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
