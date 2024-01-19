using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ShopApp.Data;

namespace ShopApp.Controllers
{
    public class AdvertisementsController : Controller
    {
        private readonly ShopDbContext context;
        public AdvertisementsController(ShopDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context);
        }
    }
}
