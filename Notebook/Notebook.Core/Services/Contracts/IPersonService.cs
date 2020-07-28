using System.Collections.Generic;
using Notebook.Core.Repositories.Contexts;
using Notebook.Core.Repositories.Contracts;
using DbModels = Notebook.Common.Models.DbModels;
using DtoModels = Notebook.Common.Models.DtoModels;

namespace Notebook.Core.Services.Contracts
{
    /// <summary>
    /// The contract of a person service.
    /// </summary>
    /// <seealso cref="Notebook.Core.Services.Contracts.IBaseService
    /// {
    ///     Notebook.Common.Models.DtoModels.Person,
    ///     Notebook.Common.Models.DbModels.Person,
    ///     Notebook.Core.Repositories.Contracts.IPersonRepository,
    ///     Notebook.Core.Repositories.NotebookDbContext
    /// }" />
    public interface IPersonService : IBaseService<DtoModels.Person, DbModels.Person, IPersonRepository, NotebookDbContext>
    {
        /// <summary>
        /// Gets all people with countries.
        /// </summary>
        /// <returns></returns>
        IEnumerable<DtoModels.Person> GetAllPeopleWithTheirCountries();

        /// <summary>
        /// Gets the filtered people with their countries.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        IEnumerable<DtoModels.Person> GetFilteredPeopleWithTheirCountries(DtoModels.PersonFilter filter);
    }
}
