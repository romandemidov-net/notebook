using Moq;
using Xunit;
using System;
using System.Linq;
using System.Collections.Generic;
using Notebook.Core.Repositories.Contexts;
using Notebook.Core.Repositories.Contracts;
using Notebook.Core.Services.Implementations;
using DbModels = Notebook.Common.Models.DbModels;
using DtoModels = Notebook.Common.Models.DtoModels;

namespace Notebook.Tests.Services
{
    public class PersonServiceTests
    {
        /// <summary>
        /// Gets all people with their countries.
        /// </summary>
        [Fact]
        public void GetAllPeopleWithTheirCountries()
        {
            // Arrange
            var unitOfWorkFactoryMock = new Mock<IUnitOfWorkFactory<NotebookDbContext>>();
            var personRepositoryMock = new Mock<IPersonRepository>();

            var testPeople = GetTestPeople().ToList();
            personRepositoryMock.Setup(r => r.GetAllPeopleWithTheirCountries()).Returns(testPeople);

            var personService = new PersonService(unitOfWorkFactoryMock.Object, personRepositoryMock.Object);

            // Act
            var result = personService.GetAllPeopleWithTheirCountries().ToList();

            // Assert
            Assert.Equal(result.Count, testPeople.Count);
            Assert.All(result, item => Assert.NotNull(item));
            Assert.All(result, item => Assert.NotNull(item.Birthday));
            Assert.All(result, item => Assert.NotNull(item.Country));
        }

        /// <summary>
        /// Gets the filtered people with their countries by full filters.
        /// </summary>
        [Fact]
        public void GetFilteredPeopleWithTheirCountriesByFullFilters()
        {
            // Arrange
            var unitOfWorkFactoryMock = new Mock<IUnitOfWorkFactory<NotebookDbContext>>();
            var personRepositoryMock = new Mock<IPersonRepository>();

            var testPeople = GetTestPeople().ToList();
            personRepositoryMock.Setup(r => r.GetAllPeopleWithTheirCountries()).Returns(testPeople);

            var personService = new PersonService(unitOfWorkFactoryMock.Object, personRepositoryMock.Object);

            var firstTestPerson = testPeople.First();

            var filter = new DtoModels.PersonFilter
            {
                LastName = firstTestPerson.LastName[firstTestPerson.LastName.Length - 1].ToString(),
                EndBirthday = firstTestPerson.Birthday + TimeSpan.FromDays(10),
                StartBirthday = firstTestPerson.Birthday - TimeSpan.FromDays(10),
                Country = new DtoModels.Country
                {
                    Id = firstTestPerson.Country.Id,
                    Name = firstTestPerson.Country.Name
                }
            };

            // Act
            var result = personService.GetFilteredPeopleWithTheirCountries(filter);

            // Assert
            Assert.All(result, item => Assert.NotNull(item));
            Assert.All(result, item => Assert.NotNull(item.Birthday));
            Assert.All(result, item => Assert.NotNull(item.Country));
            Assert.All(result, item => Assert.Contains(item.LastName, filter.LastName));
            Assert.All(result, item => Assert.InRange(item.Birthday.Value, filter.StartBirthday.Value, filter.EndBirthday.Value));
            Assert.All(result, item => Assert.Equal(item.Country.Id, filter.Country.Id));
        }

        /// <summary>
        /// Gets the test people.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<DbModels.Person> GetTestPeople()
        {
            var random = new Random();

            var people = new List<DbModels.Person>();

            for(var i = 0; i < random.Next(5, 20); ++i)
            {
                var countryId = Guid.NewGuid();

                var person = new DbModels.Person()
                {
                    Id = Guid.NewGuid(),
                    Name = $"PersonName{i}",
                    LastName = $"PersonLastName{i}",
                    Birthday = DateTime.Now - TimeSpan.FromDays(random.Next(0, 100000)),
                    Phone = $"PersonPhone{i}",
                    CountryId = countryId,
                    Country = new DbModels.Country
                    {
                        Id = countryId,
                        Name = $"CountryName{i}"
                    }
                };

                people.Add(person);
            }

            return people;
        }
    }
}
