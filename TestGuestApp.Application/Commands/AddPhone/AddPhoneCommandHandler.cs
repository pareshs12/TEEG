using MediatR;
using Microsoft.Extensions.Logging;
using TestGuestApp.Core.Interfaces;

namespace TestGuestApp.Application.Commands.AddPhone
{
    public class AddPhoneCommandHandler : IRequestHandler<AddPhoneCommand, bool>
    {
        private readonly IGuestRepository _guestRepository;
        private readonly ILogger<AddPhoneCommandHandler> _logger;

        public AddPhoneCommandHandler(IGuestRepository guestRepository, ILogger<AddPhoneCommandHandler> logger)
        {
            _guestRepository = guestRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(AddPhoneCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Starting to handle AddPhoneCommand for GuestId: {GuestId} with PhoneNumber: {PhoneNumber}", request.GuestId, request.PhoneNumber);

                var guest = await _guestRepository.GetByIdAsync(request.GuestId);
                if (guest == null)
                {
                    _logger.LogWarning("Guest with ID {GuestId} not found.", request.GuestId);
                    return false;
                }

                guest.PhoneNumbers.Add(request.PhoneNumber);

                await _guestRepository.UpdateAsync(guest);

                _logger.LogInformation("Successfully added phone number {PhoneNumber} to GuestId: {GuestId}.", request.PhoneNumber, request.GuestId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling AddPhoneCommand for GuestId: {GuestId} and PhoneNumber: {PhoneNumber}.", request.GuestId, request.PhoneNumber);
                throw;
            }
        }
    }
}
