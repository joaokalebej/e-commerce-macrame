using Microsoft.AspNetCore.Mvc;

namespace FiosEntreNos.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}