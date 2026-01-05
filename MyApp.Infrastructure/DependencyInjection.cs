using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Infrastructure;

public static class DependencyInjection
    {
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
        services.AddDbContext<AppDbContext>(options => options
                .UseSqlServer(""));
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
        }
    }

