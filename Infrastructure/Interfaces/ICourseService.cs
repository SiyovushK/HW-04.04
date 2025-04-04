using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface ICourseService
{
    Task<Response<List<Course>>> GetAllAsync();
    Task<Response<Course>> GetByIdAsync(int ID);
    Task<Response<Course>> CreateAsync(Course Course);
    Task<Response<Course>> UpdateAsync(Course Course);
    Task<Response<string>> DeleteAsync(int ID);   
}