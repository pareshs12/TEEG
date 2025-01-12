using MediatR;

namespace TestGuestApp.Application.Commands.AddPhone
{
    public class AddPhoneCommand : IRequest<bool>
    {
        public Guid GuestId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
