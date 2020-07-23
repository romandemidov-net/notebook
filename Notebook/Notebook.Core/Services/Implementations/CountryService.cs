using Notebook.Core.Services.Contracts;
using Notebook.Core.Repositories.Contexts;
using Notebook.Core.Repositories.Contracts;
using DbModels = Notebook.Common.Models.DbModels;
using DtoModels = Notebook.Common.Models.DtoModels;

namespace Notebook.Core.Services.Implementations
{
    /// <summary>
    /// The implementation of a country service.
    /// </summary>
    /// <seealso cref="Notebook.Core.Services.Implementations.BaseService
    /// {
    ///     Notebook.Common.Models.DtoModels.Country,
    ///     Notebook.Common.Models.DbModels.Country,
    ///     Notebook.Core.Repositories.Contracts.ICountryRepository,
    ///     Notebook.Core.Repositories.NotebookDbContext
    /// }" />
    /// <seealso cref="Notebook.Core.Services.Contracts.ICountryService" />
    public class CountryService : BaseService<DtoModels.Country, DbModels.Country, ICountryRepository, NotebookDbContext>, ICountryService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryService"/> class.
        /// </summary>
        /// <param name="unitOfWorkFactory">The unit of work factory.</param>
        /// <param name="repository">The repository.</param>
        public CountryService(
            IUnitOfWorkFactory<NotebookDbContext> unitOfWorkFactory,
            ICountryRepository repository) : base(unitOfWorkFactory, repository)
        {
            
        }
    }
}
