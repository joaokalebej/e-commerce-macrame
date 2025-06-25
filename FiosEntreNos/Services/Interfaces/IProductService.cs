using FiosEntreNos.Models;

namespace FiosEntreNos.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> GetActivesProductsAsync();
}