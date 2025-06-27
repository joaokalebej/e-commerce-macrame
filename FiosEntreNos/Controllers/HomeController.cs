using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FiosEntreNos.Models;
using FiosEntreNos.Services.Interfaces;
using FiosEntreNos.ViewModel;

namespace FiosEntreNos.Controllers;

public class HomeController(IProductService productService) : Controller
{
    public async Task<IActionResult> Index()
    {
        IEnumerable<ProductModel> products = await productService.GetActivesProductsAsync();

        List<ProductHomeViewModel> productViewModel = products.Select(s => new ProductHomeViewModel
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Price = s.Price,
            UrlImage = s.ProductImages?.FirstOrDefault()?.ImageUrl ?? ""
        }).ToList();

        return View(productViewModel);
    }
}
