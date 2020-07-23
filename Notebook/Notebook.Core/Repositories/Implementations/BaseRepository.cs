using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Notebook.Common.Models.DbModels;
using Notebook.Core.Repositories.Contracts;

namespace Notebook.Core.Repositories.Implementations
{
    /// <summary>
    /// The base CRUD repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <seealso cref="Notebook.Core.Repositories.Contracts.IBaseRepository{TEntity}" />
    public abstract class BaseRepository<TEntity, TDbContext> : IBaseRepository<TEntity>
        where TEntity : BaseDbModel
        where TDbContext : DbContext
    {
        /// <summary>
        /// The database context factory.
        /// </summary>
        private readonly IDbContextFactory<TDbContext> _dbContextFactory;

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        protected TDbContext Context => _dbContextFactory.GetContext();

        /// <summary>
        /// Gets the database set.
        /// </summary>
        /// <value>
        /// The database set.
        /// </value>
        protected virtual DbSet<TEntity> DbSet => Context.Set<TEntity>();

        /// <summary>
        /// Gets the database set as no tracking.
        /// </summary>
        /// <value>
        /// The database set as no tracking.
        /// </value>
        protected virtual IQueryable<TEntity> DbSetAsNoTracking => Context.Set<TEntity>().AsNoTracking();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity, TDbContext}"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        protected BaseRepository(IDbContextFactory<TDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Create(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSetAsNoTracking.ToList();
        }

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual TEntity GetById(Guid id)
        {
            return DbSetAsNoTracking.FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
