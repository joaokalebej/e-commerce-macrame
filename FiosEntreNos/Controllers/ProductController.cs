using FiosEntreNos.Models;
using FiosEntreNos.Services.Interfaces;
using FiosEntreNos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// ReSharper disable All

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

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateViewModel model, List<IFormFile> files)
    {
        if (ModelState.IsValid)
            await productService.AddProducts(model, files);
        
        return RedirectToAction("Index");
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