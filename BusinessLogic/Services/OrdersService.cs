using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IMapper mapper;
        private readonly ShopDbContext context;
        private readonly ICartService cartService;
        public OrdersService(IMapper mapper,
                           ShopDbContext context,
                           ICartService cartService)               
        {
            this.mapper = mapper;
            this.context = context;
            this.cartService = cartService;        
        }

        public async Task Create(string userId, int id)
        {
            var advert = await context.Advertisements.FirstOrDefaultAsync(x => x.Id == id);

            if (advert == null)
            {
                return;
            }
            var order = new Order()
            {
                Date = DateTime.Now,
                UserId = userId,
                Advertisement = advert
            };

            context.Orders.Add(order);
            context.SaveChanges();
            context.Entry(order).Reference(x => x.User).Load();
        }

        public IEnumerable<OrderDto> GetAllByUser(string userId)
        {
            var items = context.Orders.Include(x => x.Advertisement).Where(x => x.UserId == userId).ToList();
            return mapper.Map<IEnumerable<OrderDto>>(items);
        }
    }
}
