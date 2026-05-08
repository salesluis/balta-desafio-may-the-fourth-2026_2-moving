using balta_desafio_may_the_fourth_2026_2_moving.Application.Abstractions.Repositories;
using balta_desafio_may_the_fourth_2026_2_moving.Domain.Contracts;
using balta_desafio_may_the_fourth_2026_2_moving.Domain.Repositories;
using balta_desafio_may_the_fourth_2026_2_moving.Infra.Context;
using balta_desafio_may_the_fourth_2026_2_moving.Infra.Data;
using balta_desafio_may_the_fourth_2026_2_moving.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace balta_desafio_may_the_fourth_2026_2_moving.Infra;

public static class DependencyInjection
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                connString,
                o => o.UseVector()
            ));
        
        services.AddScoped<IItemBoxRepository, ItemBoxRepository>();
        services.AddScoped<IBoxRepository, BoxRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}