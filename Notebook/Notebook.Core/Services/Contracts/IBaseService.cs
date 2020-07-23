using System;
using System.Data.Entity;
using System.Collections.Generic;
using Notebook.Common.Models.DbModels;
using Notebook.Common.Models.DtoModels;
using Notebook.Core.Repositories.Contracts;

namespace Notebook.Core.Services.Contracts
{
    /// <summary>
    /// The contract of base CRUD service.
    /// </summary>
    /// <typeparam name="TDtoModel">The type of the dto model.</typeparam>
    /// <typeparam name="TDbModel">The type of the database model.</typeparam>
    /// <typeparam name="TRepository">The type of the repository.</typeparam>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    public interface IBaseService<TDtoModel, TDbModel, TRepository, TDbContext>
        where TDtoModel : BaseDtoModel
        where TDbModel : BaseDbModel
        where TRepository: IBaseRepository<TDbModel>
        where TDbContext: DbContext
    {
        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="dto">The dto.</param>
        void Create(TDtoModel dto);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TDtoModel> GetAll();

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TDtoModel GetById(Guid id);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="dto">The dto.</param>
        void Update(TDtoModel dto);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="dto">The dto.</param>
        void Delete(TDtoModel dto);
    }
}
