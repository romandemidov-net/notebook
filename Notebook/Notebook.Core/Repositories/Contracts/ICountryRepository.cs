using Notebook.Common.Models.DbModels;

namespace Notebook.Core.Repositories.Contracts
{
    /// <summary>
    /// The country repository contract.
    /// </summary>
    /// <seealso cref="Notebook.Core.Repositories.IBaseRepository{Notebook.Common.Models.DbModels.Country}" />
    public interface ICountryRepository : IBaseRepository<Country>
    {
    }
}
