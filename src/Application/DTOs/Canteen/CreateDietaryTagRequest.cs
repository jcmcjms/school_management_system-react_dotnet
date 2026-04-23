using Domain.Enums;

namespace Application.DTOs.Canteen;

public class CreateDietaryTagRequest
{
    public string Name { get; set; } = string.Empty;
    public DietaryTagType Type { get; set; }
    public string Icon { get; set; } = string.Empty;
}