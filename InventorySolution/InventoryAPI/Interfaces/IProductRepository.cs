using InventoryAPI.Models;

namespace InventoryAPI.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<ProductS>> GetAllAsync();
    Task<ProductS?> GetByIdAsync(int id);
    Task AddAsync(ProductS product);
    Task UpdateAsync(ProductS product);
    Task DeleteAsync(int id);
}
