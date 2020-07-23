using System;
using Notebook.Common.Models.DtoModels;

namespace Notebook.Common.Models.DbModels
{
    /// <summary>
    /// The implementation of a base DB model.
    /// </summary>
    public abstract class BaseDbModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Converts to dto model.
        /// </summary>
        /// <returns></returns>
        public abstract BaseDtoModel ConvertToDtoModel();
    }
}
