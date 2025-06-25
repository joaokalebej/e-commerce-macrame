using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task ActivateAsync(bool active, int id);
}