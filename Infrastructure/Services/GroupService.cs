using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService : IGroupService
{
    private readonly DataContext context;
    public GroupService(DataContext _context)
    {
        context = _context;
    }

    public async Task<Response<List<Group>>> GetAllAsync()
    {
        var Group = await context.Group.ToListAsync();
        return new Response<List<Group>>(Group);
    }

    public async Task<Response<Group>> GetByIdAsync(int ID)
    {
        var Group = await context.Group.FindAsync(ID);

        return Group == null
            ? new Response<Group>(HttpStatusCode.NotFound, "Not found")
            : new Response<Group>(Group);
    }

    public async Task<Response<Group>> CreateAsync(Group Group)
    {
        await context.Group.AddAsync(Group);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Group>(HttpStatusCode.BadRequest, "Group wasn't created")
            : new Response<Group>(Group);
    }

    public async Task<Response<Group>> UpdateAsync(Group Group)
    {
        context.Group.Update(Group);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Group>(HttpStatusCode.BadRequest, "Group wasn't updated")
            : new Response<Group>(Group);
    }

    public async Task<Response<string>> DeleteAsync(int ID)
    {
        var Group = await context.Group.FindAsync(ID);

        if (Group == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, $"Group with id {ID} wasn't found");
        }

        context.Remove(Group);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "Group wasn't deleted")
            : new Response<string>("Group deleted successfully");
    }

}