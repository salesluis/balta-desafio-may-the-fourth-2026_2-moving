using balta_desafio_may_the_fourth_2026_2_moving.Domain.Entities;

namespace balta_desafio_may_the_fourth_2026_2_moving.Application.Abstractions.Repositories;

public interface IBoxRepository
{
    Task CreateAsync(Box itemBox);
}