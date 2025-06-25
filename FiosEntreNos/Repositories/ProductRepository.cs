using FiosEntreNos.Data;
using FiosEntreNos.Models;
using FiosEntreNos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiosEntreNos.Repositories;

public class ProductRepository(DBContext context) : IProductRepository
{
    public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
    {
        return await context.Product.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<ProductModel>> GetAllProductsWithStatusAsync(bool active)
    {
        return await context.Product.AsNoTracking()
            .Where(w => w.Active == active)
            .ToListAsync();
    }
    
    public async Task AddAsync(ProductModel product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        context.Product.Add(product);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductModel product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        await context.Product.Where(w => w.Id == product.Id)
            .ExecuteUpdateAsync(e => e.SetProperty(s => s.Active, false)
                .SetProperty(s => s.DateChange, DateTime.Now));

        await AddAsync(product);
    }

    public async Task ActiveAsync(bool active, int id)
    {
        await context.Product.Where(w => w.Id == id)
            .ExecuteUpdateAsync(e =>
                e.SetProperty(s => s.Active, active));
    }
}