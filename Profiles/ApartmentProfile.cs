using AutoMapper;
using RentalAppMVC.Data;
using RentalAppMVC.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

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