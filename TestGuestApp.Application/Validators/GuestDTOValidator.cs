using FluentValidation;
using TestGuestApp.Application.DTOs;
using TestGuestApp.Core.Enums;

namespace TestGuestApp.Application.Validators
{
    public class GuestDTOValidator : AbstractValidator<AddGuestDTO>
    {
        public GuestDTOValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.");
            
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required.");
            
            RuleFor(x => x.PhoneNumbers)
            .NotEmpty().WithMessage("At least one phone number is required.")
            .Must(phoneNumbers => phoneNumbers.Any()).WithMessage("At least one phone number is required.")
            .ForEach(phoneNumber => phoneNumber
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format."));

            RuleFor(x => x.Title)
            .IsEnumName(typeof(Title), caseSensitive: false)
            .WithMessage("Invalid title. Valid values are: " + string.Join(", ", Enum.GetNames(typeof(Title))));
        }
    }
}
