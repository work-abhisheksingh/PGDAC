using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tflstore.Models;

namespace tflstore.Controllers;

public class LoginpageController : Controller
{
    private readonly ILogger<LoginpageController> _logger;

    public LoginpageController(ILogger<LoginpageController> logger)
    {
        Console.WriteLine("Loginpage Controller instance initialized......");
        _logger = logger;
    }

    public IActionResult Index(){
        //fetch data from Model
        //send list of Loginpage to ViewData Collection
        
<<<<<<< HEAD
        List<Product>  allLoginpage=ProductManager.GetAllLoginpage();
        ViewData["catalog"]=allLoginpage;
=======
        List<Product>  allProducts=ProductManager.GetProducts();
        ViewData["catalog"]=allProducts;
>>>>>>> 8c4fdb0a431528ecc5fbe4452567ac5b8f5277e2
        return View();
    }
    
}
