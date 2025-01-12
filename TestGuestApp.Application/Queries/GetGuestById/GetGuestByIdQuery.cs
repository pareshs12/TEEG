using MediatR;
using TestGuestApp.Application.DTOs;
using TestGuestApp.Core.Entities;

namespace TestGuestApp.Application.Queries.GetGuestById
{
    public record GetGuestByIdQuery(Guid Id) : IRequest<GuestDTO>
    {
    }
}
