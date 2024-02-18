using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using ShopApp.Helpers;

namespace ShopApp.Services
{
    public class CartService : ICartService
    {
        const string key = "cart_items_key";
        private readonly IAdvertsService advertsService;
        private readonly HttpContext httpContext;

        public CartService(IAdvertsService advertsService, IHttpContextAccessor contextAccessor)
        {
            this.advertsService = advertsService;
            httpContext = contextAccessor.HttpContext ?? throw new Exception();
        }

        private List<int> GetCartItems()
        {
            return httpContext.Session.Get<List<int>>(key) ?? new();
        }
        private void SaveCartItems(List<int> items)
        {
            httpContext.Session.Set(key, items);
        }

        public void Add(int id)
        {
            var ids = GetCartItems();
            ids.Add(id);

            SaveCartItems(ids);
        }

        public IEnumerable<AdvertisementDto> GetAdverts()
        {
            var ids = GetCartItems();
            return advertsService.Get(ids);
        }

        public void Remove(int id)
        {
            var ids = GetCartItems();
            ids.Remove(id);

            SaveCartItems(ids);
        }

        public int GetCount()
        {
            return GetCartItems().Count;
        }

        public bool IsExists(int id)
        {
            return GetCartItems().Contains(id);
        }
    }
}
