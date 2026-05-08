using balta_desafio_may_the_fourth_2026_2_moving.Application.Abstractions.Repositories;
using balta_desafio_may_the_fourth_2026_2_moving.Domain.Entities;
using balta_desafio_may_the_fourth_2026_2_moving.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace balta_desafio_may_the_fourth_2026_2_moving.Infra.Repository;

public class BoxRepository(AppDbContext context) : IBoxRepository
{
    public async Task CreateAsync(Box itemBox) => 
        await context
            .Boxes
            .AddAsync(itemBox);
    
}