using balta_desafio_may_the_fourth_2026_2_moving.Domain.Entities;

namespace balta_desafio_may_the_fourth_2026_2_moving.Domain.Repositories;

public interface IItemBoxRepository
{
    Task CreateAsync(ItemBox? item, int numberBox);
    Task<ItemBox?> GetAsync(string name);
    Task<List<ItemBox>> SearchSimilarAsync(float[] queryEmbedding, int limit = 5);
}