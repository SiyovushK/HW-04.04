using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IAddressService
{
    Task<Response<List<Address>>> GetAllAsync();
    Task<Response<Address>> GetByIdAsync(int ID);
    Task<Response<Address>> CreateAsync(Address Address);
    Task<Response<Address>> UpdateAsync(Address Address);
    Task<Response<string>> DeleteAsync(int ID);
}