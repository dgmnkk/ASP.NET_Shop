namespace ShopApp.Data.Entities
{
    public class Condition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
