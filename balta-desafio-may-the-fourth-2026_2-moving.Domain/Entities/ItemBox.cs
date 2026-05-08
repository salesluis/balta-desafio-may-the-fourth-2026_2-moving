namespace balta_desafio_may_the_fourth_2026_2_moving.Domain.Entities;

public class ItemBox
{
    public Guid Id { get; private set; }
    public Guid BoxId { get; private set; }
    public string Description { get; private set; } =  string.Empty;
    public float[] Embedding { get; private set; } = [];
    public DateTime CreatedAt { get; private set; }
}
