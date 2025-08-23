using Ant_3_Arena.Simulation;
using AntArena.Domain.Interfaces;
using AntArena.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ant_3_Arena
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
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