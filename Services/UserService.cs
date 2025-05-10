using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentalAppMVC.Data;
using RentalAppMVC.DTOs;
using RentalAppMVC.Services.Abstractions;

namespace RentalAppMVC.Services
{
    public class UserService : IUserService
    {


        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserDTO? GetById(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user != null ? _mapper.Map<UserDTO>(user) : null;
        }
    }
}
