using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
    Task<Response<List<Student>>> GetAllAsync();

    Task<Response<Student>> GetByIdAsync(int ID);

    Task<Response<Student>> CreateAsync(Student Student);

    Task<Response<Student>> UpdateAsync(Student Student);

    Task<Response<string>> DeleteAsync(int ID);
}