using RentalAppMVC.DTOs;

namespace RentalAppMVC.Services.Abstractions
{
    public interface IApartmentService
    {
        Task<List<ApartmentDTO>> GetAllAsync();
        Task<ApartmentDTO> GetByIdAsync(int id);
        Task<List<ApartmentDTO>> GetApartmentByAddressAsync(string address);
        Task AddAsync(ApartmentDTO model);
        Task UpdateAsync(ApartmentDTO model);
        Task DeleteByIdAsync(int id);
        Task RentAsync(int id);
        Task GetByIdAsync(string propertyId);
    }
}