using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService : IStudentService
{
    private readonly DataContext context;
    public StudentService(DataContext _context)
    {
        context = _context;
    }

    public async Task<Response<List<Student>>> GetAllAsync()
    {
        var Students = await context.Students.ToListAsync();
        return new Response<List<Student>>(Students);
    }

    public async Task<Response<Student>> GetByIdAsync(int ID)
    {
        var Student = await context.Students.FindAsync(ID);

        return Student == null
            ? new Response<Student>(HttpStatusCode.NotFound, "Not found")
            : new Response<Student>(Student);
    }

    public async Task<Response<Student>> CreateAsync(Student Student)
    {
        await context.Students.AddAsync(Student);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Student>(HttpStatusCode.BadRequest, "Student wasn't created")
            : new Response<Student>(Student);
    }

    public async Task<Response<Student>> UpdateAsync(Student Student)
    {
        context.Students.Update(Student);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Student>(HttpStatusCode.BadRequest, "Student wasn't updated")
            : new Response<Student>(Student);
    }

    public async Task<Response<string>> DeleteAsync(int ID)
    {
        var Student = await context.Students.FindAsync(ID);

        if (Student == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, $"Student with id {ID} wasn't found");
        }

        context.Remove(Student);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "Student wasn't deleted")
            : new Response<string>("Student deleted successfully");
    }
}