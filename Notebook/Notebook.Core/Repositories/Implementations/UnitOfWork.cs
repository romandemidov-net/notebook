using System.Linq;
using System.Data.Entity;
using Notebook.Core.Repositories.Contracts;

namespace Notebook.Core.Repositories.Implementations
{
    /// <summary>
    /// The "unit of work" implementation.
    /// </summary>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <seealso cref="Notebook.Core.Repositories.Contracts.IUnitOfWork{TDbContext}" />
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext: DbContext
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly DbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork{TDbContext}"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public UnitOfWork(IDbContextFactory<TDbContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.GetContext();
        }

        /// <summary>
        /// Commits changes.
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            var result = _dbContext.SaveChanges();

            DetachAllEntities();

            return result;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="UnitOfWork{TDbContext}"/> class.
        /// </summary>
        ~UnitOfWork()
        {
            Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// Detaches all entities.
        /// </summary>
        private void DetachAllEntities()
        {
            var changedEntriesCopy = _dbContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Unchanged).ToList();

            foreach (var entry in changedEntriesCopy)
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
