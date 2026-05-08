namespace balta_desafio_may_the_fourth_2026_2_moving.Domain.Entities;

public class Box
{
    public Guid Id { get; private set; } =  Guid.NewGuid();
    public int Number { get; private set; }
    public string Label { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
}