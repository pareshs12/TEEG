using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TestGuestApp.Application.DTOs;
using TestGuestApp.Core.Interfaces;

namespace TestGuestApp.Application.Queries.GetAllGuests
{
    public class GetAllGuestsQueryHandler : IRequestHandler<GetAllGuestsQuery, IEnumerable<GuestDTO>>
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllGuestsQueryHandler> _logger;

        public GetAllGuestsQueryHandler(IGuestRepository guestRepository, IMapper mapper, ILogger<GetAllGuestsQueryHandler> logger)
        {
            _guestRepository = guestRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<GuestDTO>> Handle(GetAllGuestsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Starting to handle GetAllGuestsQuery.");

                var guests = await _guestRepository.GetAllAsync();

                if (guests == null || !guests.Any())
                {
                    _logger.LogWarning("No guests found.");
                    return Enumerable.Empty<GuestDTO>();
                }

                var guestDTOs = _mapper.Map<IEnumerable<GuestDTO>>(guests);

                _logger.LogInformation("Successfully handled GetAllGuestsQuery. {GuestCount} guests found.", guestDTOs.Count());

                return guestDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling GetAllGuestsQuery.");
                throw;
            }
        }
    }
}
