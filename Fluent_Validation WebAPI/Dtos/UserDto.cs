using Fluent_Validation_WebAPI.Model;

namespace Fluent_Validation_WebAPI.Dtos
{
	public class UserDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string Email { get; set; } = null!;
		
	}
}
