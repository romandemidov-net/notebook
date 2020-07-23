using System.Linq;
using System.Collections.Generic;
using Notebook.Core.Services.Contracts;
using Notebook.Core.Repositories.Contexts;
using Notebook.Core.Repositories.Contracts;
using DbModels = Notebook.Common.Models.DbModels;
using DtoModels = Notebook.Common.Models.DtoModels;

namespace Notebook.Core.Services.Implementations
{
    /// <summary>
    /// The implementation of a person service.
    /// </summary>
    /// <seealso cref="Notebook.Core.Services.Implementations.BaseService
    /// {
    ///     Notebook.Common.Models.DtoModels.Person,
    ///     Notebook.Common.Models.DbModels.Person,
    ///     Notebook.Core.Repositories.Contracts.IPersonRepository,
    ///     Notebook.Core.Repositories.Contexts.NotebookDbContext
    /// }" />
    /// <seealso cref="Notebook.Core.Services.Contracts.IPersonService" />
    public class PersonService : BaseService<DtoModels.Person, DbModels.Person, IPersonRepository, NotebookDbContext>, IPersonService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        /// <param name="unitOfWorkFactory">The unit of work factory.</param>
        /// <param name="repository">The repository.</param>
        public PersonService(
            IUnitOfWorkFactory<NotebookDbContext> unitOfWorkFactory,
            IPersonRepository repository) : base(unitOfWorkFactory, repository)
        {
            
        }

        /// <summary>
        /// Gets all people with countries.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DtoModels.Person> GetAllPeopleWithTheirCountries()
        {
            var personDbModels =_repository.GetAllPeopleWithTheirCountries();

            var personDtoModels = personDbModels.Select(p => (DtoModels.Person) p.ConvertToDtoModel()).ToList();

            return personDtoModels;
        }

        /// <summary>
        /// Gets the filtered person with their countries.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public IEnumerable<DtoModels.Person> GetFilteredPersonWithTheirCountries(DtoModels.PersonFilter filter)
        {
            var lastName = filter.LastName;
            var startBirthday = filter.StartBirthday;
            var endBirthday = filter.EndBirthday;
            var countryId = filter.Country?.Id;

            var personDbModels = _repository.GetFilteredPeopleWithTheirCountries(lastName, startBirthday, endBirthday, countryId);

            var personDtoModels = personDbModels.Select(p => (DtoModels.Person) p.ConvertToDtoModel()).ToList();

            return personDtoModels;
        }
    }
}
