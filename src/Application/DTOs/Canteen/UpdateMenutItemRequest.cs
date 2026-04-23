namespace Application.DTOs.Canteen;

public class UpdateMenuItemRequest : CreateMenuItemRequest
{
    public Guid Id { get; set; }
}