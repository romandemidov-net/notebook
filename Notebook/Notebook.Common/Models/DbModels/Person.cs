using Notebook.Common.Models.DtoModels;
using System;

namespace Notebook.Common.Models.DbModels
{
    /// <summary>
    /// The implementation of a person DB model.
    /// </summary>
    /// <seealso cref="Notebook.Common.Models.DbModels.BaseDbModel" />
    public class Person : BaseDbModel
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
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        /// <value>
        /// The birthday.
        /// </value>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public Guid CountryId { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public Country Country { get; set; }

        /// <summary>
        /// Converts to dto model.
        /// </summary>
        /// <returns></returns>
        public override BaseDtoModel ConvertToDtoModel()
        {
            var dtoModel = new DtoModels.Person()
            {
                Id = this.Id,
                Birthday = this.Birthday,
                Name = this.Name,
                LastName = this.LastName,
                Phone = this.Phone
            };

            if (this.Country != null)
            {
                dtoModel.Country = (DtoModels.Country)this.Country.ConvertToDtoModel();
            }

            return dtoModel;
        }
    }
}
