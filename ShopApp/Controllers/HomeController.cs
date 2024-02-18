using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;
using System.Diagnostics;

namespace ShopApp.Controllers
{
    public class HomeController : Controller
    {
       private readonly IAdvertsService advertsService;

        public HomeController(IAdvertsService advertsService)
        {
           this.advertsService = advertsService;
        }

        public IActionResult Index()
        {
            return View(advertsService.GetAll());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}