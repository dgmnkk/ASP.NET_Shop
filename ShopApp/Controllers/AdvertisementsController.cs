using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ShopApp.Data;
using ShopApp.Data.Entities;

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
            var adverts = context.Advertisements
                .Include(x => x.Category)
                .Include(x => x.Seller)
                .Include(x => x.Condition)
                .ToList();
            return View(adverts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Advertisement advertisement)
        {
            advertisement.Views = 0;
            advertisement.SellerId = 1;
            advertisement.PublicationDate = DateTime.Now;
            context.Advertisements.Add(advertisement);
            context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
    }
}
