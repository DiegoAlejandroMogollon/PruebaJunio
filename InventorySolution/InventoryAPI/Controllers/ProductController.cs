using InventoryAPI.Interfaces;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace InventoryAPI.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    // GET: api/product
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _repository.GetAllAsync());

    // POST: api/product
    [HttpPost]
    public async Task<IActionResult> Add(ProductS product)
    {
        await _repository.AddAsync(product);
        return Ok(product);
    }

    // PUT: api/product/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductS product)
    {
        if (id != product.Id) return BadRequest();
        await _repository.UpdateAsync(product);
        return NoContent();
    }

    // PUT: api/product/{id}/defect
    [HttpPut("{id}/defect")]
    public async Task<IActionResult> MarkDefective(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return NotFound();

         product.Estado = "Devuelto";
        await _repository.UpdateAsync(product);
        return NoContent();
    }

    // DELETE: api/product/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
