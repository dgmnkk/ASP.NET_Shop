using BusinessLogic.Interfaces;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Helpers;

namespace ShopApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        public IActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(cartService.GetAdverts());
        }

        public IActionResult Add(int id, string returnUrl)
        {
            cartService.Add(id);
            return Redirect(returnUrl);
        }

        public IActionResult Remove(int id, string returnUrl)
        {
            cartService.Remove(id);
            return Redirect(returnUrl);
        }
    }
}
