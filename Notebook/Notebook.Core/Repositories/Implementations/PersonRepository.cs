using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Notebook.Common.Models.DbModels;
using Notebook.Core.Repositories.Contexts;
using Notebook.Core.Repositories.Contracts;

namespace Notebook.Core.Repositories.Implementations
{
    /// <summary>
    /// The implementation of a person repository.
    /// </summary>
    /// <seealso cref="Notebook.Core.Repositories.Implementations.BaseRepository
    /// {
    ///     Notebook.Common.Models.DbModels.Person,
    ///     Notebook.Core.Repositories.Contexts.NotebookDbContext
    /// }" />
    /// <seealso cref="Notebook.Core.Repositories.Contracts.IPersonRepository" />
    public class PersonRepository : BaseRepository<Person, NotebookDbContext>, IPersonRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public PersonRepository(IDbContextFactory<NotebookDbContext> dbContextFactory) : base(dbContextFactory)
        {
            
        }

        /// <summary>
        /// Gets all people with countries.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetAllPeopleWithTheirCountries()
        {
            var people = DbSetAsNoTracking.Include(p => p.Country).ToList();

            return people;
        }

        /// <summary>
        /// Gets the filtered people with their countries.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <param name="startBirthdayDate">The start of a birthday date.</param>
        /// <param name="endBirthdayDate">The end of a birthday date.</param>
        /// <param name="countryId">The country identifier.</param>
        /// <returns></returns>
        public IEnumerable<Person> GetFilteredPeopleWithTheirCountries(
            string lastName,
            DateTime? startBirthdayDate,
            DateTime? endBirthdayDate,
            Guid? countryId)
        {
            var peopleQueryBuilder = DbSetAsNoTracking;

            if (!string.IsNullOrEmpty(lastName))
            {
                peopleQueryBuilder = peopleQueryBuilder.Where(p => p.LastName.Contains(lastName));
            }

            if (startBirthdayDate.HasValue)
            {
                peopleQueryBuilder = peopleQueryBuilder.Where(p => p.Birthday >= startBirthdayDate.Value);
            }

            if (endBirthdayDate.HasValue)
            {
                peopleQueryBuilder = peopleQueryBuilder.Where(p => p.Birthday <= endBirthdayDate);
            }

            if (countryId.HasValue)
            {
                peopleQueryBuilder = peopleQueryBuilder.Where(p => p.CountryId == countryId.Value);
            }

            var people = peopleQueryBuilder.Include(p => p.Country).ToList();

            return people;
        }
    }
}
