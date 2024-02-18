using Microsoft.AspNetCore.Identity;
namespace ShopApp.Data.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Advertisement>? Advertisements { get; set; }
    }
}
