using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentGroupService : IStudentGroup
{
    private readonly DataContext context;
    public StudentGroupService(DataContext _context)
    {
        context = _context;
    }

    public async Task<Response<List<StudentGroup>>> GetAllAsync()
    {
        var StudentGroup = await context.StudentGroups.ToListAsync();
        return new Response<List<StudentGroup>>(StudentGroup);
    }

    public async Task<Response<StudentGroup>> GetByIdAsync(int ID)
    {
        var StudentGroup = await context.StudentGroups.FindAsync(ID);

        return StudentGroup == null
            ? new Response<StudentGroup>(HttpStatusCode.NotFound, "Not found")
            : new Response<StudentGroup>(StudentGroup);
    }

    public async Task<Response<StudentGroup>> CreateAsync(StudentGroup StudentGroup)
    {
        await context.StudentGroups.AddAsync(StudentGroup);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<StudentGroup>(HttpStatusCode.BadRequest, "StudentGroup wasn't created")
            : new Response<StudentGroup>(StudentGroup);
    }

    public async Task<Response<StudentGroup>> UpdateAsync(StudentGroup StudentGroup)
    {
        context.StudentGroups.Update(StudentGroup);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<StudentGroup>(HttpStatusCode.BadRequest, "StudentGroup wasn't updated")
            : new Response<StudentGroup>(StudentGroup);
    }

    public async Task<Response<string>> DeleteAsync(int ID)
    {
        var StudentGroup = await context.StudentGroups.FindAsync(ID);

        if (StudentGroup == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, $"StudentGroup with id {ID} wasn't found");
        }

        context.Remove(StudentGroup);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "StudentGroup wasn't deleted")
            : new Response<string>("StudentGroup deleted successfully");
    }
}