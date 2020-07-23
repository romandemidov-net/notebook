using System;
using System.Linq;
using Notebook.Common.Constants;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Notebook.Common.Models.DbModels;

namespace Notebook.Core.Migrations
{
    /// <summary>
    /// Implementation of Notebook Db context configuration.
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigrationsConfiguration{Notebook.Core.Repositories.Contexts..NotebookDbContext}" />
    internal sealed class Configuration : DbMigrationsConfiguration<Notebook.Core.Repositories.Contexts.NotebookDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        /// <remarks>
        /// Note that the database may already contain seed data when this method runs. This means that
        /// implementations of this method must check whether or not seed data is present and/or up-to-date
        /// and then only make changes if necessary and in a non-destructive way. The
        /// <see cref="M:System.Data.Entity.Migrations.DbSetMigrationsExtensions.AddOrUpdate``1(System.Data.Entity.IDbSet{``0},``0[])" />
        /// can be used to help with this, but for seeding large amounts of data it may be necessary to do less
        /// granular checks if performance is an issue.
        /// If the <see cref="T:System.Data.Entity.MigrateDatabaseToLatestVersion`2" /> database
        /// initializer is being used, then this method will be called each time that the initializer runs.
        /// If one of the <see cref="T:System.Data.Entity.DropCreateDatabaseAlways`1" />, <see cref="T:System.Data.Entity.DropCreateDatabaseIfModelChanges`1" />,
        /// or <see cref="T:System.Data.Entity.CreateDatabaseIfNotExists`1" /> initializers is being used, then this method will not be
        /// called and the Seed method defined in the initializer should be used instead.
        /// </remarks>
        protected override void Seed(Notebook.Core.Repositories.Contexts.NotebookDbContext context)
        {
            var defaultCountries = new List<Country>
            {
                new Country { Id = Guid.NewGuid(), Name = CountryName.BELARUS },
                new Country { Id = Guid.NewGuid(), Name = CountryName.RUSSIA },
                new Country { Id = Guid.NewGuid(), Name = CountryName.UKRAINE },
                new Country { Id = Guid.NewGuid(), Name = CountryName.GERMANY },
                new Country { Id = Guid.NewGuid(), Name = CountryName.USA },
                new Country { Id = Guid.NewGuid(), Name = CountryName.ITALY },
                new Country { Id = Guid.NewGuid(), Name = CountryName.UNITED_KINGDOM },
                new Country { Id = Guid.NewGuid(), Name = CountryName.FRANCE }
            };

            if (!context.Countries.Any())
            {
                context.Countries.AddRange(defaultCountries);

                context.SaveChanges();
            }

            if (!context.People.Any())
            {
                var belarusCountryId = defaultCountries.First(dc => dc.Name == CountryName.BELARUS).Id;
                var usaCountryId = defaultCountries.First(dc => dc.Name == CountryName.USA).Id;

                var defaultPersons = new List<Person>
                {
                    Configuration.CreateAndGetNewPerson("Roman", "Demidov", "777-77-77", "1993-10-09", belarusCountryId),
                    Configuration.CreateAndGetNewPerson("Semen", "Semenov", "123-45-67", "1999-12-19", belarusCountryId),
                    Configuration.CreateAndGetNewPerson("John", "Snow", "999-99-99", "1987-04-08", usaCountryId),
                    Configuration.CreateAndGetNewPerson("Leo", "Petrov", "765-43-21", "1983-10-09", usaCountryId)
                };

                context.People.AddRange(defaultPersons);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the and get new person.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="birthday">The birthday. Format: yyyy-MM-dd.</param>
        /// <param name="countryId">The country identifier.</param>
        /// <returns></returns>
        private static Person CreateAndGetNewPerson(string name, string lastName, string phone, string birthday, Guid countryId)
        {
            const string DATE_TIME_PARSE_FORMAT = "yyyy-MM-dd";

            return new Person
            {
                Id = Guid.NewGuid(),
                Name = name,
                LastName = lastName,
                Phone = phone,
                Birthday = DateTime.ParseExact(birthday, DATE_TIME_PARSE_FORMAT, null),
                CountryId = countryId
            };
        }
    }
}
