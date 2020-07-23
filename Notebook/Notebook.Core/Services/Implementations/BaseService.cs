using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Notebook.Common.Models.DbModels;
using Notebook.Common.Models.DtoModels;
using Notebook.Core.Services.Contracts;
using Notebook.Core.Repositories.Contracts;

namespace Notebook.Core.Services.Implementations
{
    /// <summary>
    /// The implementation of base CRUD service.
    /// </summary>
    /// <typeparam name="TDtoModel">The type of the dto model.</typeparam>
    /// <typeparam name="TDbModel">The type of the database model.</typeparam>
    /// <typeparam name="TRepository">The type of the repository.</typeparam>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <seealso cref="Notebook.Core.Services.Contracts.IBaseService{TDtoModel, TDbModel, TRepository, TDbContext}" />
    public abstract class BaseService<TDtoModel, TDbModel, TRepository, TDbContext> : IBaseService<TDtoModel, TDbModel, TRepository, TDbContext>
        where TDtoModel : BaseDtoModel
        where TDbModel : BaseDbModel
        where TRepository : IBaseRepository<TDbModel>
        where TDbContext: DbContext
    {
        /// <summary>
        /// The "unit of work" factory.
        /// </summary>
        protected readonly IUnitOfWorkFactory<TDbContext> _unitOfWorkFactory;

        /// <summary>
        /// The repository.
        /// </summary>
        protected readonly TRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TDtoModel, TDbModel, TRepository, TDbContext}"/> class.
        /// </summary>
        /// <param name="unitOfWorkFactory">The unit of work factory.</param>
        /// <param name="repository">The repository.</param>
        protected BaseService(IUnitOfWorkFactory<TDbContext> unitOfWorkFactory, TRepository repository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _repository = repository;
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Create(TDtoModel dto)
        {
            var entity = (TDbModel)dto.ConvertToDbModel();

            using (var uow = _unitOfWorkFactory.Create())
            {
                _repository.Create(entity);

                uow.Commit();
            }
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual IEnumerable<TDtoModel> GetAll()
        {
            var entities = _repository.GetAll();

            var dtos = entities.Select(e => (TDtoModel)e.ConvertToDtoModel()).ToList();

            return dtos;
        }

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual TDtoModel GetById(Guid id)
        {
            var entity = _repository.GetById(id);

            var dto = (TDtoModel)entity.ConvertToDtoModel();

            return dto;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Update(TDtoModel dto)
        {
            var entity = (TDbModel)dto.ConvertToDbModel();

            using (var uow = _unitOfWorkFactory.Create())
            {
                _repository.Update(entity);

                uow.Commit();
            }
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Delete(TDtoModel dto)
        {
            var entity = (TDbModel)dto.ConvertToDbModel();

            using (var uow = _unitOfWorkFactory.Create())
            {
                _repository.Delete(entity);

                uow.Commit();
            }
        }
    }
}
