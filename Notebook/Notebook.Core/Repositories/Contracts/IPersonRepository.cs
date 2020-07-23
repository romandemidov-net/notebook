using System;
using System.Collections.Generic;
using Notebook.Common.Models.DbModels;

namespace Notebook.Core.Repositories.Contracts
{
    /// <summary>
    /// The people repository contract.
    /// </summary>
    /// <seealso cref="Notebook.Core.Repositories.IBaseRepository{Notebook.Common.Models.DbModels.Person}" />
    public interface IPersonRepository : IBaseRepository<Person>
    {
        /// <summary>
        /// Gets all people with countries.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Person> GetAllPeopleWithTheirCountries();

        /// <summary>
        /// Gets the filtered people with their countries.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <param name="startBirthdayDate">The start of a birthday date.</param>
        /// <param name="endBirthdayDate">The end of a birthday date.</param>
        /// <param name="countryId">The country identifier.</param>
        /// <returns></returns>
        IEnumerable<Person> GetFilteredPeopleWithTheirCountries(
            string lastName,
            DateTime? startBirthdayDate,
            DateTime? endBirthdayDate,
            Guid? countryId);
    }
}
