using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupController : ControllerBase
{
    private readonly IStudentGroup _studentGroup;
    public StudentGroupController(IStudentGroup studentGroup)
    {
        _studentGroup = studentGroup;
    }

    [HttpGet]
    public async Task<Response<List<StudentGroup>>> GetAllAsync()
    {
        return await _studentGroup.GetAllAsync();
    }

    [HttpGet("id")]
    public async Task<Response<StudentGroup>> GetByIdAsync(int ID)
    {
        return await _studentGroup.GetByIdAsync(ID);
    }

    [HttpPost]
    public async Task<Response<StudentGroup>> CreateAsync(StudentGroup StudentGroup)
    {
        return await _studentGroup.CreateAsync(StudentGroup);
    }

    [HttpPut]
    public async Task<Response<StudentGroup>> UpdateAsync(StudentGroup StudentGroup)
    {
        return await _studentGroup.UpdateAsync(StudentGroup);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int ID)   
    {
        return await _studentGroup.DeleteAsync(ID);
    }
}