using Notebook.Common.Models.DbModels;
using Notebook.Core.Repositories.Contexts;
using Notebook.Core.Repositories.Contracts;

namespace Notebook.Core.Repositories.Implementations
{
    /// <summary>
    /// The implementation of a country repository.
    /// </summary>
    /// <seealso cref="Notebook.Core.Repositories.Implementations.BaseRepository{Notebook.Common.Models.DbModels.Country, Notebook.Core.Repositories.Contexts.NotebookDbContext}" />
    /// <seealso cref="Notebook.Core.Repositories.Contracts.ICountryRepository" />
    public class CountryRepository : BaseRepository<Country, NotebookDbContext>, ICountryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryRepository"/> class.
        /// </summary>
        /// <param name="contextFactory">The context factory.</param>
        public CountryRepository(IDbContextFactory<NotebookDbContext> contextFactory) : base(contextFactory)
        {
            
        }
    }
}
