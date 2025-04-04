using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<Response<List<Product>>> GetAllAsync()
    {
        return await _productService.GetAllAsync();
    }

    [HttpGet("id")]
    public async Task<Response<Product>> GetByIdAsync(int ID)
    {
        return await _productService.GetByIdAsync(ID);
    }

    [HttpPost]
    public async Task<Response<Product>> CreateAsync(Product product)
    {
        return await _productService.CreateAsync(product);
    }

    [HttpPut]
    public async Task<Response<Product>> UpdateAsync(Product product)
    {
        return await _productService.UpdateAsync(product);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int ID)
    {
        return await _productService.DeleteAsync(ID);
    }
}