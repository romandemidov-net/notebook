using System.Data.Entity;

namespace Notebook.Core.Repositories.Contracts
{
    /// <summary>
    /// The contract of "unit of work" factory.
    /// </summary>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    public interface IUnitOfWorkFactory<TDbContext> where TDbContext: DbContext
    {
        /// <summary>
        /// Creates the "unit of work" instance.
        /// </summary>
        /// <returns></returns>
        IUnitOfWork<TDbContext> Create();

        /// <summary>
        /// Rollbacks changes.
        /// </summary>
        void Rollback();
    }
}
