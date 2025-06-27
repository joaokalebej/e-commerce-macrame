using FiosEntreNos.Models;
using FiosEntreNos.ViewModel;

namespace FiosEntreNos.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> GetActivesProductsAsync();
    Task<IEnumerable<ProductModel>> GetAllProductsAsync();
    Task AddProducts(ProductCreateViewModel product, List<IFormFile> files);
    Task AddImages(List<ProductImageModel> product);
}