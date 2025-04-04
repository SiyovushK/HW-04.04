using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }


    [HttpGet]
    public async Task<Response<List<Student>>> GetAllAsync()
    {
        return await _studentService.GetAllAsync();
    }
    
    [HttpGet("id")]
    public async Task<Response<Student>> GetByIdAsync(int ID)
    {
        return await _studentService.GetByIdAsync(ID);
    }

    [HttpPost]
    public async Task<Response<Student>> CreateAsync(Student Student)
    {
        return await _studentService.CreateAsync(Student);
    }

    [HttpPut]
    public async Task<Response<Student>> UpdateAsync(Student Student)
    {
        return await _studentService.UpdateAsync(Student);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int ID)
    {
        return await _studentService.DeleteAsync(ID);
    }
}