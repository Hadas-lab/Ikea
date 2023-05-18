using AutoMapper;
using DTO;
using Entities;
using Entities;
namespace Ikea
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductDto>()
              .ForMember(productDto => productDto.CategoryName,
               opt => opt.MapFrom(src => src.Category.Name))
               .ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}
