using System.ComponentModel.DataAnnotations;
using TestGuestApp.Core.Enums;

namespace TestGuestApp.Core.Entities
{
    public class Guest
    {
        [Key]
        public Guid Id { get; set; }

        public Title Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<string> PhoneNumbers { get; set; } = new List<string>();

        public Guest()
        {
            Id = Guid.NewGuid();
        }
    }
}
