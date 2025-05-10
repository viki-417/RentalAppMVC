using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentalAppMVC.Data;
using RentalAppMVC.DTOs;
using RentalAppMVC.Repositories.Abstractions;
using RentalAppMVC.Services.Abstractions;

namespace RentalAppMVC.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly ICrudRepository<Apartment> _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ApartmentService(ICrudRepository<Apartment> apartmentRepository, IMapper mapper, ApplicationDbContext context)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task AddAsync(ApartmentDTO model)
        {
            var apartment = _mapper.Map<Apartment>(model);
            await _apartmentRepository.AddAsync(apartment);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _apartmentRepository.DeleteByIdAsync(id);
        }

        public async Task<List<ApartmentDTO>> GetAllAsync()
        {
            var apartments = await _apartmentRepository.GetAllAsync();
            return _mapper.Map<List<ApartmentDTO>>(apartments);
        }

        public async Task<ApartmentDTO> GetByIdAsync(int id)
        {
            var apartment = await _apartmentRepository.GetByIdAsync(id);
            return _mapper.Map<ApartmentDTO>(apartment);
        }

        public async Task<List<ApartmentDTO>> GetApartmentByAddressAsync(string address)
        {
            var apartments = (await _apartmentRepository.GetByFilterAsync(item => item.Address.Contains(address)));
            return _mapper.Map<List<ApartmentDTO>>(apartments);

        }
        public async Task RentAsync(int id)
        {
            var apartment = await _context.Apartments.FirstOrDefaultAsync(a => a.Id == id);
            if (apartment != null && apartment.IsAvailable)
            {
                apartment.IsAvailable = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(ApartmentDTO model)
        {
            var apartment = _mapper.Map<Apartment>(model);
            await _apartmentRepository.UpdateAsync(apartment);
        }
    }
}