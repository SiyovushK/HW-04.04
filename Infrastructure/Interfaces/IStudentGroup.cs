using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IStudentGroup
{
    Task<Response<List<StudentGroup>>> GetAllAsync();
    Task<Response<StudentGroup>> GetByIdAsync(int ID);
    Task<Response<StudentGroup>> CreateAsync(StudentGroup StudentGroup);
    Task<Response<StudentGroup>> UpdateAsync(StudentGroup StudentGroup);
    Task<Response<string>> DeleteAsync(int ID);
}