using System;
using System.Data.Entity;

namespace Notebook.Core.Repositories.Contracts
{
    /// <summary>
    /// The "unit of work" contract.
    /// </summary>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork<TDbContext> : IDisposable where TDbContext: DbContext
    {
        /// <summary>
        /// Commits changes.
        /// </summary>
        /// <returns></returns>
        int Commit();
    }
}
