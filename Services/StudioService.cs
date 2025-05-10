using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentalAppMVC.Data;
using RentalAppMVC.DTOs;
using RentalAppMVC.Repositories.Abstractions;
using RentalAppMVC.Services.Abstractions;

namespace RentalAppMVC.Services
{
    public class StudioService : IStudioService
    {
        private readonly ICrudRepository<Studio> _studioRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public StudioService(ICrudRepository<Studio> studioRepository, IMapper mapper, ApplicationDbContext context)
        {
            _studioRepository = studioRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task AddAsync(StudioDTO model)
        {
            var studio = _mapper.Map<Studio>(model);
            await _studioRepository.AddAsync(studio);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _studioRepository.DeleteByIdAsync(id);
        }

        public async Task<List<StudioDTO>> GetAllAsync() 
        {
            var studios = await _studioRepository.GetAllAsync();
            return _mapper.Map<List<StudioDTO>>(studios);
        }

        public async Task<StudioDTO> GetByIdAsync(int id)
        {
            var studio = await _studioRepository.GetByIdAsync(id);
            return _mapper.Map<StudioDTO>(studio);
        }

        public async Task<List<StudioDTO>> GetStudioByAddressAsync(string address)
        {
            var studios = (await _studioRepository.GetByFilterAsync(item => item.Address.Contains(address)));
            return _mapper.Map<List<StudioDTO>>(studios);

        }
        public async Task RentAsync(int id)
        {
            var studio = await _context.Studios.FirstOrDefaultAsync(a => a.Id == id);
            if (studio != null && studio.IsAvailable)
            {
                studio.IsAvailable = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(StudioDTO model)
        {
            var studio = _mapper.Map<Studio>(model);
            await _studioRepository.UpdateAsync(studio);
        }
    }
}
        
 

