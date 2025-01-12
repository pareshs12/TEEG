namespace TestGuestApp.Application.DTOs
{
    public class GuestDTO
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
}
