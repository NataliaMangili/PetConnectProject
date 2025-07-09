namespace MyProfileAPI.Application.GoalsWidget.Dto;

public record GoalWidgetDto(Guid Id, string Title, string Description, decimal TargetValue, DateTime CreatedAt);

