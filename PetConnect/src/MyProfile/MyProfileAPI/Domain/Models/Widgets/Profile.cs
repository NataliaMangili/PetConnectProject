using MyProfileAPI.Domain.Models.Widgets;

namespace MyProfileAPI.Domain.Models;

public class Profile
{
    public Guid Id { get; private set; }
    public Guid OngId { get; private set; }

    public string About { get; private set; }
    public string Mission { get; private set; }
    public string Vision { get; private set; }
    public string Values { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.Now;

    private readonly List<PhotoWidget> _photos = new();
    public IReadOnlyCollection<PhotoWidget> Photos => _photos.AsReadOnly();

    private readonly List<GoalWidget> _goals = new();
    public IReadOnlyCollection<GoalWidget> Goals => _goals.AsReadOnly();

    private readonly List<EventWidget> _events = new();
    public IReadOnlyCollection<EventWidget> Events => _events.AsReadOnly();

    private Profile() { } // EF Core

    public static Profile Create(Guid ongId, string about, string mission, string vision, string values)
    {
        if (string.IsNullOrWhiteSpace(about)) throw new ArgumentException("About is required");
        if (string.IsNullOrWhiteSpace(mission)) throw new ArgumentException("Mission is required");

        return new Profile
        {
            Id = Guid.NewGuid(),
            OngId = ongId,
            About = about,
            Mission = mission,
            Vision = vision,
            Values = values
        };
    }

    public void Update(string about, string mission, string vision, string values)
    {
        if (!string.IsNullOrWhiteSpace(about)) About = about;
        if (!string.IsNullOrWhiteSpace(mission)) Mission = mission;
        if (!string.IsNullOrWhiteSpace(vision)) Vision = vision;
        if (!string.IsNullOrWhiteSpace(values)) Values = values;
    }

    public void AddPhoto(string url, string description)
    {
        _photos.Add(PhotoWidget.Create(url, description));
    }

    public void AddGoal(string title, string description, int target)
    {
        _goals.Add(GoalWidget.Create(title, description, target));
    }

    public void AddEvent(string title, DateTime date, string description)
    {
        _events.Add(EventWidget.Create(title, date, description));
    }
}

