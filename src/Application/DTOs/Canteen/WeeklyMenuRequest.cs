namespace Application.DTOs.Canteen;

public class WeeklyMenuRequest
{
    public DateOnly WeekStartDate { get; set; }
    public List<CreateMenuScheduleRequest> Items { get; set; } = new();
}