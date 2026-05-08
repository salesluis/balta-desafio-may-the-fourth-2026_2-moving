namespace balta_desafio_may_the_fourth_2026_2_moving.Domain.Contracts;

public interface IUnitOfWork
{
    Task CommitAsync();
}