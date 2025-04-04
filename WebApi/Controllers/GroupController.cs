using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;
    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public async Task<Response<List<Group>>> GetAllAsync()
    {
        return await _groupService.GetAllAsync();
    }

    [HttpGet("id")]
    public async Task<Response<Group>> GetByIdAsync(int ID)
    {
        return await _groupService.GetByIdAsync(ID);
    }

    [HttpPost]
    public async Task<Response<Group>> CreateAsync(Group Group)
    {
        return await _groupService.CreateAsync(Group);
    }

    [HttpPut]
    public async Task<Response<Group>> UpdateAsync(Group Group)
    {
        return await _groupService.UpdateAsync(Group);
    }
    
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int ID)
    {
        return await _groupService.DeleteAsync(ID);
    }
}