using System;
using Notebook.Common.Models.DbModels;

namespace Notebook.Common.Models.DtoModels
{
    /// <summary>
    /// The implementation of a country DTO model.
    /// </summary>
    /// <seealso cref="Notebook.Common.Models.DtoModels.BaseDtoModel" />
    public class Country : BaseDtoModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Converts to database model.
        /// </summary>
        /// <returns></returns>
        public override BaseDbModel ConvertToDbModel()
        {
            var dbModel = new DbModels.Country
            {
                Id = this.Id ?? Guid.NewGuid(),
                Name = this.Name
            };

            return dbModel;
        }
    }
}
