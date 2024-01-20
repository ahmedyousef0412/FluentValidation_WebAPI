using Fluent_Validation_WebAPI.Core.Consts;
using Fluent_Validation_WebAPI.Dtos;
using Fluent_Validation_WebAPI.Model;
using FluentValidation;

namespace Fluent_Validation_WebAPI.Core.Validations
{
	public class UserValidation:AbstractValidator<UserDto>
	{

        public UserValidation()
        {
		

			RuleFor(x => x.Name)
				.NotNull()
				.NotEmpty()
				.Length(10,30)
				.WithMessage("Name can't be more than 30 char , and less than 10 char ");

			RuleFor(x => x.PhoneNumber)
				.NotEmpty()
				.Matches(Regex.MobileNumber)
				.WithMessage("Invalid mobile number.");


			RuleFor(u => u.Email)
				.EmailAddress()
				.WithMessage("Please specify a email , like test@exampl.com");


			// Complex Properties
			//RuleFor(x => x.Address)?.InjectValidator();

		}
    }
}
