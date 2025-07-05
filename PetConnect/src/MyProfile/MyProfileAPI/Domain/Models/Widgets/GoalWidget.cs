namespace MyProfileAPI.Domain.Models.Widgets;

public class GoalWidget
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int Target { get; private set; }
    public int Current { get; private set; }

    private GoalWidget() { }

    public static GoalWidget Create(string title, string description, int target)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Goal title is required");

        return new GoalWidget
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Target = target,
            Current = 0
        };
    }

    public void UpdateProgress(int amount)
    {
        if (amount < 0) throw new ArgumentException("Amount must be positive");
        Current += amount;
        if (Current > Target) Current = Target;
    }
}
