using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TestGuestApp.Application;

namespace TestGuestApp.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var applicationAssembly = typeof(IApplicationAssemblyMarker).Assembly;
            var assemblies = new[] { applicationAssembly };

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
            services.AddValidatorsFromAssemblies(assemblies, ServiceLifetime.Scoped);
            services.AddAutoMapper(assemblies);

            return services;
        }
    }
}
