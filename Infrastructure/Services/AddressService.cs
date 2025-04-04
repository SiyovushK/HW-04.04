using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressService : IAddressService
{
    private readonly DataContext context;
    public AddressService(DataContext _context)
    {
        context = _context;
    }

    public async Task<Response<List<Address>>> GetAllAsync()
    {
        var Address = await context.Address.ToListAsync();
        return new Response<List<Address>>(Address);
    }

    public async Task<Response<Address>> GetByIdAsync(int ID)
    {
        var Address = await context.Address.FindAsync(ID);

        return Address == null
            ? new Response<Address>(HttpStatusCode.NotFound, "Not found")
            : new Response<Address>(Address);
    }

    public async Task<Response<Address>> CreateAsync(Address Address)
    {
        await context.Address.AddAsync(Address);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Address>(HttpStatusCode.BadRequest, "Address wasn't created")
            : new Response<Address>(Address);
    }

    public async Task<Response<Address>> UpdateAsync(Address Address)
    {
        context.Address.Update(Address);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Address>(HttpStatusCode.BadRequest, "Address wasn't updated")
            : new Response<Address>(Address);
    }

    public async Task<Response<string>> DeleteAsync(int ID)
    {
        var Address = await context.Address.FindAsync(ID);

        if (Address == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, $"Address with id {ID} wasn't found");
        }

        context.Remove(Address);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "Address wasn't deleted")
            : new Response<string>("Address deleted successfully");
    }

}