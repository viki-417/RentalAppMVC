using AutoMapper;
using RentalAppMVC.Data;
using RentalAppMVC.DTOs;

namespace RentalAppMVC.Profiles
{
    public class ApartmentProfile : Profile
    {
        public ApartmentProfile()
        {
            CreateMap<Apartment, ApartmentDTO>()
                .ReverseMap();
        }
    }
}
