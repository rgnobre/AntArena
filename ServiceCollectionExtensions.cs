using Ant_3_Arena.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Ant_3_Arena
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAntArenaSimulation(this IServiceCollection services)
        {
            var rng = new Random();
            var arenaSize = Screen.PrimaryScreen!.Bounds.Size;

            services.AddSingleton<IAntFactory>(sp => new AntFactory(arenaSize, rng));

            services.AddSingleton<IArenaSimulation, ArenaSimulation>();

            services.AddSingleton<IRenderer, Renderer>();

            services.AddSingleton<AntArena>();

            return services;
        }
    }
}
