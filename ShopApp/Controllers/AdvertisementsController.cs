using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Data.Entities;
using ShopApp.Helpers;
using System.Security.Claims;

namespace ShopApp.Controllers
{
    public class AdvertisementsController : Controller
    {
		private readonly IAdvertsService advertsService;
		private readonly IMapper mapper;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        public AdvertisementsController(IAdvertsService advertsService, IMapper mapper)
        {
            this.advertsService = advertsService;
            this.mapper = mapper;
		}
        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(advertsService.GetAllCategories(), nameof(Category.Id), nameof(Category.Name));
		}
        private void LoadConditions()
        {
            ViewBag.Conditions = new SelectList(advertsService.GetAllConditions(), nameof(Condition.Id), nameof(Condition.Name));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(advertsService.GetAll());
        }

        [AllowAnonymous]
        public IActionResult MyAdvertisements()
        {
            return View("Index", advertsService.GetByUser(UserId));
        }

        public IActionResult Create()
        {
            LoadCategories();
            LoadConditions();
            return View();
        }

        [HttpPost]
        public IActionResult Create(AdvertisementDto advertisement)
        {
			advertisement.Views = 0;
			advertisement.PublicationDate = DateTime.Now;
            advertisement.SellerId = UserId;
			if (!ModelState.IsValid)
            {
                LoadConditions();
                LoadCategories();
                return View();
            }
            advertsService.Create(advertisement);
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(MyAdvertisements));
            }
		}
        [AllowAnonymous]
        public IActionResult Details(int id, string? returnUrl)
        {
            var advert = advertsService.Get(id);
            if (advert == null) return NotFound();

            ViewBag.ReturnUrl = returnUrl;

            return View(advert);
        }

		public IActionResult Edit(int id)
		{
			var advert = advertsService.Get(id);
			if (advert == null) return NotFound();
			LoadConditions();
			LoadCategories();
			return View(advert);
		}

		[HttpPost]
		public IActionResult Edit(AdvertisementDto model)
		{
			if (!ModelState.IsValid)
			{
				LoadConditions();
				LoadCategories();
				return View();
			}

			advertsService.Edit(model);

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(MyAdvertisements));
            }
        }

		public IActionResult Delete(int id)
		{
			advertsService.Delete(id);
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(MyAdvertisements));
            }
        }
	}
}
