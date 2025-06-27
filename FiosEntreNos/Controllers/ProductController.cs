using FiosEntreNos.Services.Interfaces;
using FiosEntreNos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FiosEntreNos.Controllers;

public class ProductController(IProductService productService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> GridProducts()
    {
        var products = productService.GetAllProductsAsync();

        List<QueryListProduct> query = products.Result.Select(s => new QueryListProduct
        {
            Id = s.Id,
            Name = s.Name,
            Price = s.Price,
            Active = s.Active
        }).ToList();

        return PartialView("_PartialGridProduct", query);
    }
}