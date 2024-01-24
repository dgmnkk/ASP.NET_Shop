using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(context.Categories.ToList(), nameof(Category.Id), nameof(Category.Name));
		}
        private void LoadConditions()
        {
            ViewBag.Conditions = new SelectList(context.Conditions.ToList(),nameof(Condition.Id), nameof(Condition.Name));
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
            LoadCategories();
            LoadConditions();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Advertisement advertisement)
        {
			advertisement.Views = 0;
			advertisement.SellerId = 1;
			advertisement.PublicationDate = DateTime.Now;
			if (!ModelState.IsValid)
            {
                LoadConditions();
                LoadCategories();
                return View();
            }
            context.Advertisements.Add(advertisement);
            context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
    }
}
