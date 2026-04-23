using Application.DTOs.Canteen;
using Application.DTOs.Orders;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class CanteenMappingProfile : Profile
{
    public CanteenMappingProfile()
    {
        CreateMap<MenuItem, MenuItemDto>()
            .ForMember(dest => dest.DietaryTags, opt => opt.MapFrom(src => src.DietaryTags.Select(md => md.DietaryTag)));

        CreateMap<CreateMenuItemRequest, MenuItem>();
        CreateMap<UpdateMenuItemRequest, MenuItem>();

        CreateMap<DietaryTag, DietaryTagDto>();
        CreateMap<CreateDietaryTagRequest, DietaryTag>();

        CreateMap<MenuSchedule, MenuScheduleDto>()
            .ForMember(dest => dest.MenuItemName, opt => opt.MapFrom(src => src.MenuItem.Name));

        CreateMap<CreateMenuScheduleRequest, MenuSchedule>();

        CreateMap<CanteenSettings, CanteenSettingsDto>();
        CreateMap<UpdateCanteenSettingsRequest, CanteenSettings>();

        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}".Trim()));

        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.MenuItemName, opt => opt.MapFrom(src => src.MenuItem.Name));

        CreateMap<Order, OrderDetailDto>()
            .ForMember(dest => dest.TotalCalories, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.MenuItem.Calories * oi.Quantity)))
            .ForMember(dest => dest.TotalProtein, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.MenuItem.Protein * oi.Quantity)))
            .ForMember(dest => dest.TotalCarbs, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.MenuItem.Carbs * oi.Quantity)))
            .ForMember(dest => dest.TotalFats, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.MenuItem.Fats * oi.Quantity)))
            .ForMember(dest => dest.TotalSodium, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.MenuItem.Sodium * oi.Quantity)));
    }
}