using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ArtTop.Models
{
    [Table("Service")]
    public class Service
    {

        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Arabic Title")]
        [Required(ErrorMessage = "Required *")]
        public string ArabicTitle { get; set; } = "";
        [Display(Name = "English Title")]
        [Required(ErrorMessage = "Required *")]
        public string EnglishTitle { get; set; } = "";
        [Display(Name = "Arabic Details")]
        [Required(ErrorMessage = "Required *")]
        public string ArabicDetails { get; set; } = "";
        [Display(Name = "English Details")]
        [Required(ErrorMessage = "Required *")]
        public string EnglishDetails { get; set; } = "";
        [Display(Name = "Cover Image")]
        public string? CoverImage { get; set; }
        [Display(Name = "Icon")]
        public string? Icon { get; set; }

        [Display(Name = "Our Office Arabic")]
        public string? OurOfficeArabic { get; set; }
        [Display(Name = "Our Office English")]
        public string? OurOfficeEnglish { get; set; }

        [Display(Name = "Meet Our Workers Arabic")]
        public string? MeetOurWorkersArabic { get; set; }
        [Display(Name = "Meet Our Workers English")]
        public string? MeetOurWorkersEnglish { get; set; }
    }
}
