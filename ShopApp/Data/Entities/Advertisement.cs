namespace ShopApp.Data.Entities
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int CategoryId { get; set; }
        public int Views { get; set; }
        public DateOnly PublicationDate { get; set; }
        public Category Category { get; set; }
        public int ConditionId { get; set; }
        public Condition Condition { get; set; }
        public int SellerId { get; set; }
        public User Seller { get; set; }
    }
}
