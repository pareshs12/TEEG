using FluentValidation;
using TestGuestApp.Application.DTOs;
using TestGuestApp.Core.Interfaces;

namespace TestGuestApp.Application.Validators
{
    public class AddPhoneDTOValidator : AbstractValidator<AddPhoneDTO>
    {
        private readonly IGuestRepository _guestRepository;

        public AddPhoneDTOValidator(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;

            RuleFor(x => x.GuestId).NotEmpty().WithMessage("Guest ID is required.");
            
            RuleFor(x => x.PhoneNumber).NotEmpty()
                .WithMessage("PhoneNumber is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.")
                .MustAsync(async (dto, phoneNumber, cancellation) =>
                {
                    var guest = await _guestRepository.GetByIdAsync(dto.GuestId);
                    return guest != null && !guest.PhoneNumbers.Contains(phoneNumber);
                }).WithMessage("Phone number already exists.");

            //RuleFor(x => x).CustomAsync(async (command, context, cancellationToken) =>
            //{
            //    var guest = await _guestRepository.GetByIdAsync(command.GuestId);
            //    if (guest == null)
            //    {
            //        context.AddFailure("Guest not found.");
            //    }
            //    else if (guest.PhoneNumbers.Contains(command.PhoneNumber))
            //    {
            //        context.AddFailure("Phone number already exists.");
            //    }
            //});
        }

    }
}
