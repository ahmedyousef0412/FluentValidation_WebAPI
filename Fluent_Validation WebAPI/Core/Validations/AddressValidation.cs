using Fluent_Validation_WebAPI.Dtos;
using Fluent_Validation_WebAPI.Model;
using FluentValidation;

namespace Fluent_Validation_WebAPI.Core.Validations
{
	public class AddressValidation :AbstractValidator<AddressDto>
	{
        public AddressValidation()
        {
			RuleFor(x => x.State)
				.NotNull()
				.NotEmpty()
				.WithMessage("Please specify a State");

			RuleFor(x => x.Country)
				.NotEmpty()
				.WithMessage("Please specify a Country.");

			RuleFor(x => x.Postcode)
				.NotNull()
				.Must(BeAValidPostcode)
				.WithMessage("Please specify a valid postcode");
		}

		private bool BeAValidPostcode(string postcode)
		{
			return postcode.Length == 6;
		}
	}
    }

