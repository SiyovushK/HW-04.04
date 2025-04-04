using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly DataContext context;
    public ProductService(DataContext _context)
    {
        context = _context;
    }

    public async Task<Response<List<Product>>> GetAllAsync()
    {
        var products = await context.Products.ToListAsync();
        return new Response<List<Product>>(products);
    }

    public async Task<Response<Product>> GetByIdAsync(int ID)
    {
        var product = await context.Products.FindAsync(ID);

        return product == null
            ? new Response<Product>(HttpStatusCode.NotFound, "Not found")
            : new Response<Product>(product);
    }

    public async Task<Response<Product>> CreateAsync(Product product)
    {
        await context.Products.AddAsync(product);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Product>(HttpStatusCode.BadRequest, "Product wasn't created")
            : new Response<Product>(product);
    }

    public async Task<Response<Product>> UpdateAsync(Product product)
    {
        context.Products.Update(product);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Product>(HttpStatusCode.BadRequest, "Product wasn't updated")
            : new Response<Product>(product);
    }

    public async Task<Response<string>> DeleteAsync(int ID)
    {
        var product = await context.Products.FindAsync(ID);

        if (product == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, $"Product with id {ID} wasn't found");
        }

        context.Remove(product);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "Product wasn't deleted")
            : new Response<string>("Product deleted successfully");
    }
}