using RentalAppMVC.DTOs;

namespace RentalAppMVC.Services.Abstractions
{
    public interface IHouseService
    {
        Task<List<HouseDTO>> GetAllAsync();
        Task<HouseDTO> GetByIdAsync(int id);
        Task AddAsync(HouseDTO model);
        Task UpdateAsync(HouseDTO model);
        Task DeleteByIdAsync(int id);
        Task<List<HouseDTO>> GetHousesByAddressAsync(string address);
    }
}
