using AutoMapper;
using RentalAppMVC.Data;
using RentalAppMVC.DTOs;

namespace RentalAppMVC.Profiles
{
    public class StudioProfile : Profile
    {
        public StudioProfile()
        {
            CreateMap<Studio, StudioDTO>()
                .ReverseMap();
        }
    }
}