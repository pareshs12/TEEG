using MediatR;
using TestGuestApp.Application.DTOs;
using TestGuestApp.Core.Entities;

namespace TestGuestApp.Application.Queries.GetAllGuests
{
    public record GetAllGuestsQuery : IRequest<IEnumerable<GuestDTO>>
    {
    }
}
