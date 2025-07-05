namespace MyProfileAPI.Domain.Models.Widgets;

public class EventWidget
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }

    private EventWidget() { }

    public static EventWidget Create(string title, DateTime date, string description)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Event title is required");

        return new EventWidget
        {
            Id = Guid.NewGuid(),
            Title = title,
            Date = date,
            Description = description
        };
    }
}
