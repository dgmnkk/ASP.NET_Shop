namespace ShopApp.Data.Entities
{
	public class Attribute
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Advertisement> Advertisements { get; set;}
	}
}
