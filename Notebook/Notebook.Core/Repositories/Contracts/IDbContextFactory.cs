using System.Data.Entity;

namespace Notebook.Core.Repositories.Contracts
{
    public interface IDbContextFactory<TDbContext> where TDbContext: DbContext
    {
        TDbContext GetContext();
    }
}
