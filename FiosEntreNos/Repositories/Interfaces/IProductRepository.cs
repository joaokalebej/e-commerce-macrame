using FiosEntreNos.Models;

namespace FiosEntreNos.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<ProductModel>> GetAllProductsAsync();
    Task<IEnumerable<ProductModel>> GetAllProductsWithStatusAsync(bool active);
    Task AddAsync(ProductModel product);
    Task UpdateAsync(ProductModel product);
    Task ActiveAsync(bool active, int id);
}