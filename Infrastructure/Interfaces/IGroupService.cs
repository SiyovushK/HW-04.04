using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IGroupService
{
    Task<Response<List<Group>>> GetAllAsync();
    Task<Response<Group>> GetByIdAsync(int ID);
    Task<Response<Group>> CreateAsync(Group Group);
    Task<Response<Group>> UpdateAsync(Group Group);
    Task<Response<string>> DeleteAsync(int ID);
}