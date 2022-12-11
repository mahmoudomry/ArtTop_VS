using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtTop.Models
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "ServiceId")]
        public int? ServiceId { get; set; }
        [Display(Name = "Service")]
        [ForeignKey("ServiceId")]
        public Service? Service { get; set; }

        [Display(Name = "Sub Services")]
        public List<DoctorSubServices>? SubServices { get; set; }

        public int? OfficeId { get; set; }
        [Display(Name = "Office")]
        [ForeignKey("OfficeId")]
        public Office? Office { get; set; }

        [Display(Name = "Arabic Title")]
        [Required(ErrorMessage = "Required *")]
        public string ArabicTitle { get; set; } = "";
        [Display(Name = "English Title")]
        [Required(ErrorMessage = "Required *")]
        public string EnglishTitle { get; set; } = "";

        [Display(Name = "Arabic  Name")]
        [Required(ErrorMessage = "Required *")]
        public string ?ArabicName { get; set; } = "";
        [Display(Name = "English  Name")]
        [Required(ErrorMessage = "Required *")]
        public string? EnglisName { get; set; } = "";

        [Display(Name = "Arabic About Title")]
        [Required(ErrorMessage = "Required *")]
        public string? ArabicAboutTitle { get; set; } = "";
        [Display(Name = "English About Title")]
        [Required(ErrorMessage = "Required *")]
        public string? EnglishAboutTitle { get; set; } = "";

        [Display(Name = "Arabic Details")]
        public string? ArabicDetails { get; set; } = "";
        [Display(Name = "English Details")]
        public string? EnglishDetails { get; set; } = "";
        [Display(Name = "Cover Image  En")]
        public string? CoverImage { get; set; }
        [Display(Name = "Cover Image  Ar")]
        public string? CoverImageArabic { get; set; }
        [Display(Name = "Profile Image")]
        public string? ProfileImage { get; set; }
        [Display(Name = "Profile Image Arabic")]
        public string? ProfileImageAr { get; set; }
       


        [Display(Name = "Arabic Contact Title")]
        [Required(ErrorMessage = "Required *")]
        public string? ArabicContactTitle { get; set; } = "";
        [Display(Name = "English Contact Title")]
        [Required(ErrorMessage = "Required *")]
        public string? EnglishContactTitle { get; set; } = "";


        [Display(Name = "Arabic Address ")]
        [Required(ErrorMessage = "Required *")]
        public string? ArabicAddress { get; set; } = "";
        [Display(Name = "English Address")]
        [Required(ErrorMessage = "Required *")]
        public string? EnglishAddress { get; set; } = "";

        [Display(Name = " Phone")]
        [Required(ErrorMessage = "Required *")]
        public string? Phone { get; set; } = "";

        [Display(Name = "Working Hours")]
        [Required(ErrorMessage = "Required *")]
        public string? WorkingHours { get; set; } = "";
        [Display(Name = "Working Hours Ar")]
        [Required(ErrorMessage = "Required *")]
        public string? WorkingHoursAr { get; set; } = "";

        [Display(Name = "Weekend")]
        [Required(ErrorMessage = "Required *")]
        public string ?Weekend { get; set; } = "";
        [Display(Name = "Weekend Ar")]
        [Required(ErrorMessage = "Required *")]
        public string? WeekendAr { get; set; } = "";

        [Display(Name = "Location On Map")]

        public string? Location { get; set; }

    }

    [Table("DoctorSubServices")]
    public class DoctorSubServices
    {
        [Key]
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }

        public int? SubSeviceId { get; set; }
        [ForeignKey("SubSeviceId")]
        public SubService? SubService { get; set; }
    }
}

