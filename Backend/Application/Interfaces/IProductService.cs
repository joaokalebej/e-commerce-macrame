using Backend.Domain.Entities;

namespace Backend.Application.Interfaces;

public interface IProductService
{
    Product GetById(int id);
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
    void Activate(int id);
}