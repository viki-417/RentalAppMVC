using AutoMapper;
using RentalAppMVC.Data;
using RentalAppMVC.DTOs;
using RentalAppMVC.Repositories.Abstractions;
using RentalAppMVC.Services.Abstractions;

namespace RentalAppMVC.Services
{
    public class HouseService : IHouseService
    {
        private readonly ICrudRepository<Houses> _houseRepository;
        private readonly IMapper _mapper;

        public HouseService(ICrudRepository<Houses> houseRepository, IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(HouseDTO model)
        {
            var house = _mapper.Map<Houses>(model);
            await _houseRepository.AddAsync(house);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _houseRepository.DeleteByIdAsync(id);
        }

        public async Task<List<HouseDTO>> GetAllAsync()
        {
            var houses = await _houseRepository.GetAllAsync();
            return _mapper.Map<List<HouseDTO>>(houses);
        }

        public async Task<HouseDTO> GetByIdAsync(int id)
        {
            var house = await _houseRepository.GetByIdAsync(id);
            return _mapper.Map<HouseDTO>(house);
        }

        public async Task<List<HouseDTO>> GetHousesByAddressAsync(string address)
        {
            var houses = await _houseRepository.GetByFilterAsync(h => h.Address.Contains(address));
            return _mapper.Map<List<HouseDTO>>(houses);
        }

        public async Task UpdateAsync(HouseDTO model)
        {
            var house = _mapper.Map<Houses>(model);
            await _houseRepository.UpdateAsync(house);
        }
    }
}
