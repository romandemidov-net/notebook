using System.Data.Entity;
using Notebook.Core.Repositories.Contracts;

namespace Notebook.Core.Repositories.Implementations
{
    /// <summary>
    /// The implementation of database context factory.
    /// </summary>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <seealso cref="Notebook.Core.Repositories.Contracts.IDbContextFactory{TDbContext}" />
    public class DbContextFactory<TDbContext> : IDbContextFactory<TDbContext> where TDbContext: DbContext, new()
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly TDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextFactory{TDbContext}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DbContextFactory()
        {
            _context = new TDbContext();
        }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <returns></returns>
        public TDbContext GetContext()
        {
            return _context;
        }
    }
}
