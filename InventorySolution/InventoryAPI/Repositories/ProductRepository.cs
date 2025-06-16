using InventoryAPI.Data;
using InventoryAPI.Interfaces;
using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly InventoryDbContext _context;

    public ProductRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductS>> GetAllAsync() =>
        await _context.Product.ToListAsync();

    public async Task<ProductS?> GetByIdAsync(int id) =>
        await _context.Product.FindAsync(id);

    public async Task AddAsync(ProductS product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductS product)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
