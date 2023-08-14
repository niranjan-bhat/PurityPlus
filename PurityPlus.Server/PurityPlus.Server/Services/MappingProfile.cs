using AutoMapper;
using PurityPlus.Database.Entity;
using PurityPlus.Services.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand));

        CreateMap<Category, CategoryDTO>();
        CreateMap<Brand, BrandDTO>();
        CreateMap<Order, OrderDTO>();
        CreateMap<Payment, PaymentDTO>();
        CreateMap<OrderItem, OrderItemDTO>();

        CreateMap<ApplicationUser, ApplicationUserDTO>();
    }
}