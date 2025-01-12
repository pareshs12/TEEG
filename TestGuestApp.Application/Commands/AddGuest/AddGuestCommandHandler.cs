using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TestGuestApp.Core.Entities;
using TestGuestApp.Core.Interfaces;

namespace TestGuestApp.Application.Commands.AddGuest
{
    public class AddGuestCommandHandler : IRequestHandler<AddGuestCommand, Guest>
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddGuestCommandHandler> _logger;

        public AddGuestCommandHandler(IGuestRepository guestRepository, IMapper mapper, ILogger<AddGuestCommandHandler> logger)
        {
            _guestRepository = guestRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guest> Handle(AddGuestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handling AddGuestCommand for Guest with FirstName: {FirstName} and LastName: {LastName}", request.FirstName, request.LastName);
                
                var guest = _mapper.Map<Guest>(request);
                await _guestRepository.AddAsync(guest);

                _logger.LogInformation("Successfully added guest with ID: {GuestId}", guest.Id);

                return guest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling AddGuestCommand for Guest with FirstName: {FirstName} and LastName: {LastName}", request.FirstName, request.LastName);

                return null;
            } 
        }
    }
}
