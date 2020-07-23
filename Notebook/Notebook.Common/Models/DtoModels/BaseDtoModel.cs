using System;
using System.ComponentModel;
using Notebook.Common.Models.DbModels;

namespace Notebook.Common.Models.DtoModels
{
    /// <summary>
    /// The implementation of a base DTO model.
    /// </summary>
    public abstract class BaseDtoModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Browsable(false)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Converts to database model.
        /// </summary>
        /// <returns></returns>
        public abstract BaseDbModel ConvertToDbModel();
    }
}
