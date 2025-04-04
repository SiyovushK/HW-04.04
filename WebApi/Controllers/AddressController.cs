using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;
    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    public async Task<Response<List<Address>>> GetAllAsync()
    {
        return await _addressService.GetAllAsync();
    }

    [HttpGet("id")]
    public async Task<Response<Address>> GetByIdAsync(int ID)
    {
        return await _addressService.GetByIdAsync(ID);
    }

    [HttpPost]
    public async Task<Response<Address>> CreateAsync(Address Address)
    {
        return await _addressService.CreateAsync(Address);
    }

    [HttpPut]
    public async Task<Response<Address>> UpdateAsync(Address Address)
    {
        return await _addressService.UpdateAsync(Address);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int ID)
    {
        return await _addressService.DeleteAsync(ID);
    }
}