using Domain.SnackMachine;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static class InfrastructureDiExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<SnackMachine>();
            return services;
        }
    }
}