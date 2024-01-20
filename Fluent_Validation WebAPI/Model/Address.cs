namespace Fluent_Validation_WebAPI.Model
{
	public class Address
	{
		public int Id { get; set; }
		public string Line1 { get; set; } = null!;
		public string Line2 { get; set; } = null!;
		public string Town { get; set; } = null!;
		public string Postcode { get; set; } = null!;
		public string Country { get; set; } = null!;
		public string State { get; set; } = null!;
	}
}