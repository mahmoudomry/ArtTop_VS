using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtTop.Models
{
    [Table("SubService")]
    public class SubService
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
        public string ?ArabicDetails { get; set; } = "";
        [Display(Name = "English Details")]
        public string? EnglishDetails { get; set; } = "";
        [Display(Name = "Cover Image")]
        public string? CoverImage { get; set; }
        [Display(Name = "Icon")]
        public string? Icon { get; set; }
        [Display(Name = "ServiceId")]
        public int? ServiceId { get; set; }
        [Display(Name = "Service")]
        [ForeignKey("ServiceId")]
        public Service? Service { get; set; }
    }
}
