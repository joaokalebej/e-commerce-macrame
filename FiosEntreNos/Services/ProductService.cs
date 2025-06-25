using FiosEntreNos.Models;
using FiosEntreNos.Repositories.Interfaces;
using FiosEntreNos.Services.Interfaces;

namespace FiosEntreNos.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<IEnumerable<ProductModel>> GetActivesProductsAsync()
    {
        try
        {
            IEnumerable<ProductModel> productsActives = await productRepository
                .GetAllProductsWithStatusAsync(true);

            return productsActives;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}