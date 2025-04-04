using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<Response<List<Course>>> GetAllAsync()
    {
        return await _courseService.GetAllAsync();
    }

    [HttpGet("id")]
    public async Task<Response<Course>> GetByIdAsync(int ID)
    {
        return await _courseService.GetByIdAsync(ID); 
    }

    [HttpPost]
    public async Task<Response<Course>> CreateAsync(Course Course)
    {
        return await _courseService.CreateAsync(Course);
    }

    [HttpPut]
    public async Task<Response<Course>> UpdateAsync(Course Course)
    {
        return await _courseService.UpdateAsync(Course);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int ID)
    {
        return await _courseService.DeleteAsync(ID);
    }
}