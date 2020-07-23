using System;
using System.ComponentModel;
using Notebook.Common.Models.DbModels;

namespace Notebook.Common.Models.DtoModels
{
    /// <summary>
    /// The implementation of a person DTO model.
    /// </summary>
    /// <seealso cref="Notebook.Common.Models.DtoModels.BaseDtoModel" />
    public class Person : BaseDtoModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        /// <value>
        /// The birthday.
        /// </value>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [Browsable(false)]
        public Country Country { get; set; }

        /// <summary>
        /// Gets the name of the country.
        /// </summary>
        /// <value>
        /// The name of the country.
        /// </value>
        [DisplayName("Country")]
        public string CountryName => Country?.Name;

        /// <summary>
        /// Converts to database model.
        /// </summary>
        /// <returns></returns>
        public override BaseDbModel ConvertToDbModel()
        {
            var dbModel = new DbModels.Person
            {
                Birthday = this.Birthday.Value,
                Id = this.Id ?? Guid.NewGuid(),
                Name = this.Name,
                LastName = this.LastName,
                Phone = this.Phone
            };

            if (this.Country != null)
            {
                dbModel.CountryId = this.Country.Id.Value;
            }

            return dbModel;
        }
    }
}
