using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Data.Configuration;
using ShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
	public class AdvertisementsService : IAdvertsService
	{
		private readonly IMapper mapper;
		private readonly ShopDbContext context;

		public AdvertisementsService(IMapper mapper, ShopDbContext context)
		{
			this.mapper = mapper;
			this.context = context;
		}
		public void Create(AdvertisementDto advertisement)
		{
			context.Advertisements.Add(mapper.Map<Advertisement>(advertisement));
			context.SaveChanges();
		}
		public void Delete(int id)
		{
			var advert = context.Advertisements.Find(id);

			if (advert == null) return;

			context.Remove(advert);
			context.SaveChanges();
		}

		public void Edit(AdvertisementDto advert)
		{
			context.Advertisements.Update(mapper.Map<Advertisement>(advert));
			context.SaveChanges();
		}
		public AdvertisementDto? Get(int id)
		{
			var item = context.Advertisements.Find(id);
			if(item == null)
			{
				return null;
			}
			context.Entry(item).Reference(x => x.Category).Load();
			var dto = mapper.Map<AdvertisementDto>(item);
			return dto;
		}
        public IEnumerable<AdvertisementDto> Get(IEnumerable<int> ids)
        {
            return mapper.Map<List<AdvertisementDto>>(context.Advertisements
                .Include(x => x.Category)
				.Include(x => x.Condition)
                .Where(x => ids.Contains(x.Id))
                .ToList());
        }
        public IEnumerable<AdvertisementDto> GetAll()
		{
			return mapper.Map<List<AdvertisementDto>>(context.Advertisements
				.Include(x => x.Category)
				.Include(x => x.Seller)
				.Include(x => x.Condition)
				.ToList());
		}

        public IEnumerable<AdvertisementDto> GetByUser(string id)
		{
            return mapper.Map<List<AdvertisementDto>>(context.Advertisements
                .Include(x => x.Category)
                .Include(x => x.Seller)
                .Include(x => x.Condition)
				.Where(x => x.SellerId == id)
                .ToList());
        }

        public IEnumerable<CategoryDto> GetAllCategories()
		{
			return mapper.Map<List<CategoryDto>>(context.Categories.ToList());
		}

		public IEnumerable<ConditionDto> GetAllConditions()
		{
			return mapper.Map<List<ConditionDto>>(context.Conditions.ToList());
		}
	}
}
