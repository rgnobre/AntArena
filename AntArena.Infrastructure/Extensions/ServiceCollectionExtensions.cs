using AntArena.Domain.Interfaces;
using AntArena.Infrastructure.Factories;
using AntArena.Infrastructure.Renderers;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;

namespace AntArena.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, Size arenaSize, Bitmap image)
        {
            services.AddSingleton<IAntFactory>(sp => new AntFactory(arenaSize, new Random(), image));
            services.AddSingleton<IRenderer, Renderer>();
            return services;
        }
    }
}