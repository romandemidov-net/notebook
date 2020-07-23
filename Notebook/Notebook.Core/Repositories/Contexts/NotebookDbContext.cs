using System.Data.Entity;
using Notebook.Common.Models.DbModels;

namespace Notebook.Core.Repositories.Contexts
{
    /// <summary>
    /// The implementation of a notebook database context.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class NotebookDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the people.
        /// </summary>
        /// <value>
        /// The people.
        /// </value>
        public DbSet<Person> People { get; set; }

        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotebookDbContext"/> class.
        /// </summary>
        public NotebookDbContext() : base("NotebookDbConnection")
        {
            InitContext();
        }

        /// <summary>
        /// Initializes the context.
        /// </summary>
        private void InitContext()
        {

        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuilder, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id)
                .HasRequired(p => p.Country)
                .WithMany(c => c.Persons)
                .HasForeignKey(p => p.CountryId);

            modelBuilder.Entity<Country>()
                .HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
