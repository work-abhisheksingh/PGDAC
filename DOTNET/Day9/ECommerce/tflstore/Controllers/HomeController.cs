using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tflstore.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tflstore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        Console.WriteLine("Home Controller instance initialized......");
        _logger = logger;
    }

    //Action Methods
    public IActionResult Index()
    {
        Console.WriteLine("Invoking Home Controller index method.. ");
        return View();
    }
   
     [HttpGet]
     public IActionResult Login()
    {
        Console.WriteLine("Invoking Home Controller Login method.. ");
        return View();
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        Console.WriteLine("Invoking Home Controller Privacy method. ");
        return View();
    }
   
   [HttpGet]
    public IActionResult Aboutus()
    {
        Console.WriteLine("Invoking Home Controller About us method. ");
        return View();
    }

    [HttpGet]
    public IActionResult Contact()
    {
        Console.WriteLine("Invoking Home Controller About us method. ");
        return View();
    }
     [HttpGet]
    public IActionResult Loginpage()
    {
      return View();
    }
   
     public IActionResult Validate(string email,string password)
    {
         string newfile=@"D:\GoaravsapkaleAllmodul\dotnet\practicedotnet\Loginpage.json";
             string jsonString = System.IO.File.ReadAllText(newfile);
            List<Loginpage> Loginlist = JsonSerializer.Deserialize<List<Loginpage>>(jsonString);
            foreach(Loginpage emp in Loginlist){
        if(email==emp.Email && password==emp.password)
        {
           
            
              
            return Redirect("/home/welcome");
        }
            }
            //  return Redirect("/home");
            // new Email().Send(contact);

    // ViewBag.Message = "wrong cred"; 

    return View();
        // return View(Loginlist);
    }
    public IActionResult SaveData(string fname,string lname,string cnumber,string email,string password)
    {
        
    // Loginpage emp=new Loginpage(fname,lname,cnumber,email,pass);
    var login=new Loginpage(){FirstName=fname,LastName=lname,ContactNo=cnumber,Email=email,password=password};

    List<Loginpage> userlistt=new List<Loginpage>();
    Loginlist.Add(login);
    
    try{
     var options=new JsonSerializerOptions {IncludeFields=true};
            var produtsJson=JsonSerializer.Serialize<List<Loginpage>>(Loginlist,options);
            string fileName=@"D:\GoaravsapkaleAllmodul\dotnet\practicedotnet\Loginpage.json";
            //Serialize all Flowers into json file

           System.IO.File.WriteAllText(fileName,produtsJson);

           return Redirect("/home/Success");

           }
           catch{

           }
           finally{ }
                return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
