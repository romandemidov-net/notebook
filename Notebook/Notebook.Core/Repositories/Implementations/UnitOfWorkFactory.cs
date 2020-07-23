using System.Data.Entity;
using Notebook.Core.Repositories.Contracts;

namespace Notebook.Core.Repositories.Implementations
{
    /// <summary>
    /// The implementation of "unit of work" factory.
    /// </summary>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <seealso cref="Notebook.Core.Repositories.Contracts.IUnitOfWorkFactory{TDbContext}" />
    public class UnitOfWorkFactory<TDbContext> : IUnitOfWorkFactory<TDbContext> where TDbContext: DbContext
    {
        /// <summary>
        /// The database context factory.
        /// </summary>
        private readonly IDbContextFactory<TDbContext> _dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkFactory{TDbContext}"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public UnitOfWorkFactory(IDbContextFactory<TDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Creates the "unit of work" instance.
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork<TDbContext> Create()
        {
            return new UnitOfWork<TDbContext>(_dbContextFactory);
        }

        /// <summary>
        /// Rollbacks changes.
        /// </summary>
        public void Rollback()
        {
            var dbContext = _dbContextFactory.GetContext();

            foreach (var dbEntityEntry in dbContext.ChangeTracker.Entries())
            {
                if (dbEntityEntry.Entity != null)
                {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }
        }
    }
}
