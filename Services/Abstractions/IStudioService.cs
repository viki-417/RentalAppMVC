using RentalAppMVC.DTOs;

namespace RentalAppMVC.Services.Abstractions
{
    public interface IStudioService
    {
        Task<List<StudioDTO>> GetAllAsync();
        Task<StudioDTO> GetByIdAsync(int id);
        Task<List<StudioDTO>> GetStudioByAddressAsync(string address);
        Task AddAsync(StudioDTO model);
        Task UpdateAsync(StudioDTO model);
        Task DeleteByIdAsync(int id);
        Task RentAsync(int id);

        Task CreateAsync(StudioDTO model);
    }
}
