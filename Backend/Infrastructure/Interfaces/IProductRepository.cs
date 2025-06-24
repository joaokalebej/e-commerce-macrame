using Backend.Domain.Entities;

namespace Backend.Infrastructure.Interfaces;

public interface IProductRepository
{
    Product GetById(int id);
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
    void Active(int id);
}