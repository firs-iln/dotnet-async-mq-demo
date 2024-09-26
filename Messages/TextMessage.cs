namespace Messages;

public class TextMessage
{
    public Guid Id { get; init; }
    public string Text { get; init; }
    public DateTime CreatedAt { get; init; }
}