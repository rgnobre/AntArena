using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using AntArena.Domain.Interfaces;
using AntArena.Infrastructure.Extensions;
using System.Drawing;

namespace Ant_3_Arena
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            services.AddInfrastructure(new Size(800, 450), Properties.Resources.Ant);

            services.AddSingleton<IArenaSimulation, ArenaSimulation>();
            services.AddSingleton<AntArena>();

            var serviceProvider = services.BuildServiceProvider();
            var form = serviceProvider.GetRequiredService<AntArena>();
            Application.Run(form);
        }
    }
}
