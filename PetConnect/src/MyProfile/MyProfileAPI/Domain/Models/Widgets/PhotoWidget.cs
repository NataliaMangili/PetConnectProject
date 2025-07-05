namespace MyProfileAPI.Domain.Models.Widgets;

public class PhotoWidget
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Url { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public Guid ProfileId { get; private set; }
    public Profile Profile { get; private set; }

    private PhotoWidget() { }

    public PhotoWidget(string url, string description)
    {
        Url = url;
        Description = description;
    }

    public static PhotoWidget Create(string url, string description)
    {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException("Photo URL is required");

        return new PhotoWidget
        {
            Id = Guid.NewGuid(),
            Url = url,
            Description = description
        };
    }
}

