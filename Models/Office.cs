using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtTop.Models
{[Table("Office")]
    public class Office
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "ServiceId")]
        public int? ServiceId { get; set; }
        [Display(Name = "Service")]
        [ForeignKey("ServiceId")]
        public Service? Service { get; set; }

        [Display(Name = "Office Sub Services")]
        public List<OfficeSubServices>? OfficeSubServices { get; set; }

        [Display(Name = "Arabic Title")]
        [Required(ErrorMessage = "Required *")]
        public string ArabicTitle { get; set; } = "";
        [Display(Name = "English Title")]
        [Required(ErrorMessage = "Required *")]
        public string EnglishTitle { get; set; } = "";

        [Display(Name = "Arabic Manager Name")]
        [Required(ErrorMessage = "Required *")]
        public string ArabicManagerName { get; set; } = "";
        [Display(Name = "English Manager Name")]
        [Required(ErrorMessage = "Required *")]
        public string ManagerName { get; set; } = "";

        [Display(Name = "Arabic About Title")]
        [Required(ErrorMessage = "Required *")]
        public string ArabicAboutTitle { get; set; } = "";
        [Display(Name = "English About Title")]
        [Required(ErrorMessage = "Required *")]
        public string EnglishAboutTitle { get; set; } = "";

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
        [Display(Name = "Icon")]
        public string? Icon { get; set; }


        [Display(Name = "Arabic Contact Title")]
        [Required(ErrorMessage = "Required *")]
        public string ArabicContactTitle { get; set; } = "";
        [Display(Name = "English Contact Title")]
        [Required(ErrorMessage = "Required *")]
        public string EnglishContactTitle { get; set; } = "";


        [Display(Name = "Arabic Address ")]
        [Required(ErrorMessage = "Required *")]
        public string ArabicAddress { get; set; } = "";
        [Display(Name = "English Address")]
        [Required(ErrorMessage = "Required *")]
        public string EnglishAddress { get; set; } = "";

        [Display(Name = " Phone")]
        [Required(ErrorMessage = "Required *")]
        public string Phone { get; set; } = "";

        [Display(Name = "Working Hours")]
        [Required(ErrorMessage = "Required *")]
        public string WorkingHours { get; set; } = "";
        [Display(Name = "Working Hours Ar")]
        [Required(ErrorMessage = "Required *")]
        public string WorkingHoursAr { get; set; } = "";

        [Display(Name = "Weekend")]
        [Required(ErrorMessage = "Required *")]
        public string Weekend { get; set; } = "";
        [Display(Name = "Weekend Ar")]
        [Required(ErrorMessage = "Required *")]
        public string WeekendAr { get; set; } = "";


        [Display(Name = "Mission Counter Title Arabic")]
        [Required(ErrorMessage = "Required *")]
        public string MissionAR { get; set; }

        [Display(Name = "Mission Counter Title English")]
        [Required(ErrorMessage = "Required *")]
        public string MissionEn { get; set; }
        [Display(Name = "Mission Counter ")]
        [Required(ErrorMessage = "Required *")]
        public int Mission { get; set; }





        [Display(Name = "Client Counter Title Arabic")]
        [Required(ErrorMessage = "Required *")]
        public string ClientAR { get; set; }
        [Display(Name = "Client Counter Title English")]
        [Required(ErrorMessage = "Required *")]
        public string ClientEn { get; set; }
        [Display(Name = "Client Counter ")]
        [Required(ErrorMessage = "Required *")]
        public int Client { get; set; }






        [Display(Name = "Worker Counter Title Arabic")]
        [Required(ErrorMessage = "Required *")]
        public string WorkerAR { get; set; }
        [Display(Name = "Worker Counter Title English")]
        [Required(ErrorMessage = "Required *")]
        public string WorkerEn { get; set; }
        [Display(Name = "Worker Counter ")]
        [Required(ErrorMessage = "Required *")]
        public int Worker { get; set; }


        [Display(Name = "Experience Counter Title Arabic")]
        [Required(ErrorMessage = "Required *")]
        public string ExperienceAR { get; set; }
        [Display(Name = "Experience Counter Title English")]
        [Required(ErrorMessage = "Required *")]
        public string ExperienceEn { get; set; }
        [Display(Name = "Experience Counter ")]
        [Required(ErrorMessage = "Required *")]
        public int Experience { get; set; }


        [Display(Name = "Location On Map")]
       
        public string Location { get; set; }

    }

    [Table("OfficeSubServices")]
    public class OfficeSubServices {
        [Key]
        public int Id { get; set; }
        public int? OfficeId { get; set; }
        [ForeignKey("OfficeId")]
        public Office? Office{get;set;}    

        public int? SubSeviceId { get; set; }
        [ForeignKey("SubSeviceId")]
        public SubService? SubService { get; set; }
    }
}
