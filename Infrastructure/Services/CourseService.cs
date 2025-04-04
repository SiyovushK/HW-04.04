using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CourseService : ICourseService
{
    private readonly DataContext context;
    public CourseService(DataContext _context)
    {
        context = _context;
    }

    public async Task<Response<List<Course>>> GetAllAsync()
    {
        var Course = await context.Courses.ToListAsync();
        return new Response<List<Course>>(Course);
    }

    public async Task<Response<Course>> GetByIdAsync(int ID)
    {
        var Course = await context.Courses.FindAsync(ID);

        return Course == null
            ? new Response<Course>(HttpStatusCode.NotFound, "Not found")
            : new Response<Course>(Course);
    }

    public async Task<Response<Course>> CreateAsync(Course Course)
    {
        await context.Courses.AddAsync(Course);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Course>(HttpStatusCode.BadRequest, "Course wasn't created")
            : new Response<Course>(Course);
    }

    public async Task<Response<Course>> UpdateAsync(Course Course)
    {
        context.Courses.Update(Course);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Course>(HttpStatusCode.BadRequest, "Course wasn't updated")
            : new Response<Course>(Course);
    }

    public async Task<Response<string>> DeleteAsync(int ID)
    {
        var Course = await context.Courses.FindAsync(ID);

        if (Course == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, $"Course with id {ID} wasn't found");
        }

        context.Remove(Course);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "Course wasn't deleted")
            : new Response<string>("Course deleted successfully");
    }
}