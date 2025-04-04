using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Task<Response<List<Product>>> GetAllAsync();
    Task<Response<Product>> GetByIdAsync(int ID);
    Task<Response<Product>> CreateAsync(Product product);
    Task<Response<Product>> UpdateAsync(Product product);
    Task<Response<string>> DeleteAsync(int ID);
}