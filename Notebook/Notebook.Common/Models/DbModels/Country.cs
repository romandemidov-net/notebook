using System.Collections.Generic;
using Notebook.Common.Models.DtoModels;

namespace Notebook.Common.Models.DbModels
{
    /// <summary>
    /// The implementation of a country DB model.
    /// </summary>
    /// <seealso cref="Notebook.Common.Models.DbModels.BaseDbModel" />
    public class Country : BaseDbModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        /// <value>
        /// The persons.
        /// </value>
        public List<Person> Persons { get; set; }

        /// <summary>
        /// Converts to dto model.
        /// </summary>
        /// <returns></returns>
        public override BaseDtoModel ConvertToDtoModel()
        {
            var dtoModel = new DtoModels.Country
            {
                Id = this.Id,
                Name = this.Name
            };

            return dtoModel;
        }
    }
}
