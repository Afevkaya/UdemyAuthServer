using AutoMapper;
using UdemyAuthServer.Core.DTOs;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Service.Mapping
{
    // Entity classlarını ve Dto classlarını birbirine maplediğimiz class

    // DtoMapper class
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<ProductDto,Product>().ReverseMap();
            CreateMap<UserAppDto,UserApp>().ReverseMap();
        }
    }
}
