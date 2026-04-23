using Application.DTOs.Inventory;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class InventoryMappingProfile : Profile
{
    public InventoryMappingProfile()
    {
        CreateMap<InventoryItem, InventoryItemDto>()
            .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : null))
            .ForMember(dest => dest.IsLowStock, opt => opt.MapFrom(src => src.CurrentStock <= src.MinStockLevel));

        CreateMap<CreateInventoryItemRequest, InventoryItem>();

        CreateMap<WasteLog, WasteLogDto>()
            .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.InventoryItem.Name));

        CreateMap<PurchaseOrder, PurchaseOrderDto>()
            .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name));

        CreateMap<PurchaseOrderItem, PurchaseOrderItemDto>()
            .ForMember(dest => dest.InventoryItemName, opt => opt.MapFrom(src => src.InventoryItem.Name));

        CreateMap<CreatePurchaseOrderRequest, PurchaseOrder>();
        CreateMap<CreatePurchaseOrderItemRequest, PurchaseOrderItem>();

        CreateMap<Supplier, SupplierDto>();
        CreateMap<CreateSupplierRequest, Supplier>();
    }
}