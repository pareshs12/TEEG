using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TestGuestApp.Application.DTOs;
using TestGuestApp.Application.Queries.GetAllGuests;
using TestGuestApp.Core.Interfaces;

namespace TestGuestApp.Application.Queries.GetGuestById
{
    public class GetGuestByIdQueryHandler : IRequestHandler<GetGuestByIdQuery, GuestDTO>
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetGuestByIdQueryHandler> _logger;

        public GetGuestByIdQueryHandler(IGuestRepository guestRepository, IMapper mapper, ILogger<GetGuestByIdQueryHandler> logger)
        {
            _guestRepository = guestRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GuestDTO> Handle(GetGuestByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Starting to handle GetGuestByIdQueryHandler.");

                var guest = await _guestRepository.GetByIdAsync(request.Id);

                if (guest == null)
                {
                    _logger.LogWarning("No guest found for Id : {Id}", request.Id);
                    return null;
                }

                var guestDTO = _mapper.Map<GuestDTO>(guest);

                _logger.LogInformation("Successfully handled GetGuestByIdQueryHandler.");

                return guestDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling GetGuestByIdQueryHandler.");
                throw;
            }
        }
    }
}
