using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Data.Entities;
using ShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Profiles
{
	public class ApplicationProfile :Profile
	{
		public ApplicationProfile() 
		{
			CreateMap<AdvertisementDto, Advertisement>()
				.ForMember(x => x.Category, opt => opt.Ignore())
				.ForMember(x => x.Condition, opt => opt.Ignore())
				.ForMember(x => x.Seller, opt => opt.Ignore())
				.ForMember(x => x.Location, opt => opt.Ignore());
			CreateMap<Advertisement, AdvertisementDto>();
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<Condition, ConditionDto>().ReverseMap();
			CreateMap<Location, LocationDto>().ReverseMap();
			CreateMap<ShopApp.Data.Entities.Attribute, AttributeDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
	}
}
