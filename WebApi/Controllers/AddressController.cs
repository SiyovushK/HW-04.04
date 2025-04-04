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

    public async Task<Response<List<Address>>> GetAllAsync()
    {
        return await _addressService.GetAllAsync();
    }

    public async Task<Response<Address>> GetByIdAsync(int ID)
    {
        return await _addressService.GetByIdAsync(ID);
    }

    public async Task<Response<Address>> CreateAsync(Address Address)
    {
        return await _addressService.CreateAsync(Address);
    }

    public async Task<Response<Address>> UpdateAsync(Address Address)
    {
        return await _addressService.UpdateAsync(Address);
    }

    public async Task<Response<string>> DeleteAsync(int ID)
    {
        return await _addressService.DeleteAsync(ID);
    }
}