using AutoMapper;
using DomainLayer.DTO.Request;
using DomainLayer.DTO.Response;
using DomainLayer.Model;

namespace FoodDeliveryApp.Util
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            CreateMap<MenuItemRequest, MenuItem>();
            CreateMap<User, UserRequest>();
            CreateMap<UserRequest, User>();
            CreateMap<UserResponse, User>();
            CreateMap<User, UserResponse>();
            CreateMap<IEnumerable<UserResponse>, IEnumerable<User>>()
    .       ConvertUsing(source => source.Select(Mapper.Map<User>));
            CreateMap<Address,AddressRequest>().ReverseMap();
            CreateMap<Address, AddressResponse>().ReverseMap();


        }
    }
}

