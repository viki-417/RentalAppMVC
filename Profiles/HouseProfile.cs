using AutoMapper;
using RentalAppMVC.Data;
using RentalAppMVC.DTOs;

namespace RentalAppMVC.Profiles
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<House, HouseDTO>()
                .ReverseMap();
        }
    }
}
