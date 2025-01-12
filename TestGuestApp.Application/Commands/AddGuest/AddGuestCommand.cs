using MediatR;
using TestGuestApp.Core.Entities;

namespace TestGuestApp.Application.Commands.AddGuest
{
    public class AddGuestCommand : IRequest<Guest>
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
}
