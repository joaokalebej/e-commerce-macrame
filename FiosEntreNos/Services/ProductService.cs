using System.Reflection.Metadata;
using FiosEntreNos.Models;
using FiosEntreNos.Repositories.Interfaces;
using FiosEntreNos.Services.Interfaces;
using FiosEntreNos.ViewModel;

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

    public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
    {
        try
        {
            return await productRepository
                .GetAllProductsAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task AddProducts(ProductCreateViewModel product, List<IFormFile> files)
    {
        try
        {
            ProductModel model = new()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Height = product.Heigth,
                Width = product.Width,
                DateInclude = DateTime.UtcNow,
                Active = true
            };
            await productRepository.AddAsync(model);

            List<ProductImageModel> productImages = new();

            string webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            string imageFolder = Path.Combine(webRootPath, "images");

            if (!Directory.Exists(imageFolder))
                Directory.CreateDirectory(imageFolder);

            foreach (var image in files)
            {
                if (image.Length > 0)
                {
                    var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                    var path = Path.Combine("wwwroot/images", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    productImages.Add(new ProductImageModel
                    {
                        ImageUrl = fileName,
                        ProductId = model.Id
                    });

                    await AddImages(productImages);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task AddImages(List<ProductImageModel> productImages)
    {
        try
        {
            foreach (var img in productImages)
            {
                ProductImageModel model = new()
                {
                    ImageUrl = img.ImageUrl,
                    ProductId = img.ProductId
                };

                await productRepository.AddImageAsync(model);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}