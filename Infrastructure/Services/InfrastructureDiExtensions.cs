using Domain.SnackMachine;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static class InfrastructureDiExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<SnackMachine>();
            services.AddDbContext<MachineContext>(builder =>
            {
                builder.EnableSensitiveDataLogging();
                builder.UseSqlServer(
                    "Server=localhost, 1433;Database=SnackDb;User ID=SA;Password=DDDinPractice2021;Integrated Security=false;");
            });
            return services;
        }
    }
}