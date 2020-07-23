using System;
using Notebook.Core;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Notebook.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServies(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var peopleForm = serviceProvider.GetRequiredService<PeopleForm>();

                Application.Run(peopleForm);
            }
        }

        /// <summary>
        /// Configures the servies.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void ConfigureServies(ServiceCollection services)
        {
            services.UseDatabase();
            services.UseUnitOfWork();
            services.UseBusinessServices();

            services.AddScoped<PeopleForm>();
        }
    }
}
