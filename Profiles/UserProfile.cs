﻿using AutoMapper;
using RentalAppMVC.Data;
using RentalAppMVC.DTOs;

namespace RentalAppMVC.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap();
        }
    }
}