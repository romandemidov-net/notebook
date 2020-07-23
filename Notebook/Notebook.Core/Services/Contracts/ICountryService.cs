using Notebook.Core.Repositories.Contexts;
using Notebook.Core.Repositories.Contracts;
using DbModels = Notebook.Common.Models.DbModels;
using DtoModels = Notebook.Common.Models.DtoModels;

namespace Notebook.Core.Services.Contracts
{
    /// <summary>
    /// The contract of a country service.
    /// </summary>
    /// <seealso cref="Notebook.Core.Services.Contracts.IBaseService
    /// {
    ///     Notebook.Common.Models.DtoModels.Country,
    ///     Notebook.Common.Models.DbModels.Country,
    ///     Notebook.Core.Repositories.Contracts.ICountryRepository,
    ///     Notebook.Core.Repositories.Contexts.NotebookDbContext
    /// }" />
    public interface ICountryService : IBaseService<DtoModels.Country, DbModels.Country, ICountryRepository, NotebookDbContext>
    {
    }
}
