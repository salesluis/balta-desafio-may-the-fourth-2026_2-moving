using balta_desafio_may_the_fourth_2026_2_moving.Domain.Contracts;
using balta_desafio_may_the_fourth_2026_2_moving.Infra.Context;

namespace balta_desafio_may_the_fourth_2026_2_moving.Infra.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public Task CommitAsync() 
        => context.SaveChangesAsync();
}