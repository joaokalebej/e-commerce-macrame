using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories;

public class ProductRepository(DBContext context) : IProductRepository
{
    public async Task<Product> GetByIdAsync(int id)
    {
        return await context.Product.FirstAsync(f => f.Id == id);
    }

    public Task<List<Product>> GetAllAsync()
    {
        return context.Product.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        if(product is null)
            throw new Exception("Product cannot be null");
        
        context.Product.Add(product);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        if (product is null)
            throw new Exception("Product cannot be null");

        await context.Product.Where(w => w.Id == product.Id)
            .ExecuteUpdateAsync(e => e.SetProperty(s => s.Active, false)
                .SetProperty(s => s.DateChange, DateTime.Now));

        await AddAsync(product);
    }
    
    public async Task ActivateAsync(bool active, int id)
    {
        var product = await GetByIdAsync(id);
        
        if (product is null)
            throw new Exception("Product not found");

        await context.Product.Where(w => w.Id == product.Id)
            .ExecuteUpdateAsync(e => e.SetProperty(s => s.Active, active));
    }
}