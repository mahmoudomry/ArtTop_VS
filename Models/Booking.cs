using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ArtTop.Models
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required, Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required, EmailAddress, Display(Name = "Email")]
        public string Email { get; set; }
        //[ Display(Name = "Subject")]
        //public string? Subject { get; set; }
        //[ Display(Name = "Message")]
        //public string? Message { get; set; }
        [Display(Name = "Date"),DataType(DataType.Date)]
        public DateOnly Date { get; set; }
        [Display(Name = "Time"), DataType(DataType.Time)]
        public TimeOnly Time { get; set; }
        [Display(Name = "DoctorId")]
        public int? DoctorId { get; set; }
        [Display(Name = "Doctor")]
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }
        [Display(Name = "Service")]
        public int? ServiceId { get; set; }
        [Display(Name = "Service"), ForeignKey("ServiceId")]
        public Service? Service { get; set; }
        /// <summary>
        /// Type=1 for office 
        /// Type=2 for doctor
        /// </summary>
        [Display(Name = "Type")]
        public int? Type { get; set; }
        [Display(Name = "OfficeId")]
        public int? OfficeId { get; set; }
        [Display(Name = "Office")]
        [ForeignKey("OfficeId")]
        public Office? Office { get; set; }
        [Display(Name = "IsRead")]
        public bool? IsRead { get; set; }

        [Display(Name = "IsCome")]
        public bool? IsDone { get; set; }

        [Display(Name = "Notes")]
        public string? Notes { get; set; }
    }
}
