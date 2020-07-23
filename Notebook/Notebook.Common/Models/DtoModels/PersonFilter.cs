using System;

namespace Notebook.Common.Models.DtoModels
{
    public class PersonFilter
    {
        /// <summary>
        /// Gets or sets the start of birthday.
        /// </summary>
        /// <value>
        /// The start birthday.
        /// </value>
        public DateTime? StartBirthday { get; set; }

        /// <summary>
        /// Gets or sets the end of birthday.
        /// </summary>
        /// <value>
        /// The end birthday.
        /// </value>
        public DateTime? EndBirthday { get; set; }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public Country Country { get; set; }
    }
}
