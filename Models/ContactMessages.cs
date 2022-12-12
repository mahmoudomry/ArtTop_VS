using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtTop.Models
{
    [Table("ContactMessages")]
    public class ContactMessages
    {

        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required,Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required,EmailAddress, Display(Name = "Email")]
        public string Email { get; set; }
        [Required, Display(Name = "Subject")]
        public string Subject { get; set; }
        [Required, Display(Name = "Message")]
        public string Message { get; set; }
        [Display(Name = "Inserted_at")]
        public DateTime Inserted_at { get; set; } = DateTime.Now;
        [Display(Name = "IsRead")]
        public bool IsRead { get; set; } = false;
    }
}
