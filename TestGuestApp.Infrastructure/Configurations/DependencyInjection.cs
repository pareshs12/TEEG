using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestGuestApp.Core.Interfaces;
using TestGuestApp.Infrastructure.DataContext;
using TestGuestApp.Infrastructure.Repositories;

namespace TestGuestApp.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<TestGuestDbContext>(options =>
                options.UseInMemoryDatabase("GuestDb"));
            services.AddScoped<IGuestRepository, GuestRepository>();
            return services;
        }
    }
}
