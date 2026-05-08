using balta_desafio_may_the_fourth_2026_2_moving.Application.Abstractions.Repositories;
using balta_desafio_may_the_fourth_2026_2_moving.Domain.Entities;
using balta_desafio_may_the_fourth_2026_2_moving.Domain.Repositories;
using balta_desafio_may_the_fourth_2026_2_moving.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Pgvector;
using Pgvector.EntityFrameworkCore;

namespace balta_desafio_may_the_fourth_2026_2_moving.Infra.Repository;

public class ItemBoxRepository(AppDbContext context) : IItemBoxRepository
{
    public async Task CreateAsync(ItemBox? item, int numberBox)
    {
        var box = await context
            .Boxes
            .FirstOrDefaultAsync(box => box.Number == numberBox);

        if (box is null)
            return;
        
        await context
            .ItemBoxes
            .AddAsync(item!);
    }
    
    public async Task<ItemBox?> GetAsync(string description) =>
        await context
            .ItemBoxes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => 
                x.Description.ToLower() == description.ToLower());

    public async Task<List<ItemBox>> SearchSimilarAsync(float[] queryEmbedding, int limit = 5) =>
        await context.ItemBoxes
            .OrderBy(x => x
                .Embedding
                .CosineDistance(new Vector(queryEmbedding)))
            .Take(limit)
            .AsNoTracking()
            .ToListAsync();
}