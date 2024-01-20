using System.Net;

namespace Fluent_Validation_WebAPI.Model
{
	public class User
	{

        public int Id { get; set; }
        public string  Name { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string Email { get; set; } = null!;
		
	}
}
