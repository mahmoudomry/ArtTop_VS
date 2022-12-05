using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtTop.Models
{
    
        [Table("OfficeSlider")]
        public class OfficeSlider
        {
            [Key]
            [Display(Name = "Id")]
            public int Id { get; set; }
            [Display(Name = "Cover Image")]
            public string? CoverImage { get; set; } = "";
        [Display(Name = "Cover Image Ar")]
        public string? CoverImageAr { get; set; } = "";
        [Display(Name = "IsActive")]
            [Required(ErrorMessage = "Required *")]
            public bool IsActive { get; set; } = false;
            [Display(Name = "Order")]
            [Required(ErrorMessage = "Required *")]
            public int Order { get; set; }
            [Display(Name = "OfficeId")]
            public int? OfficeId { get; set; }
            [Display(Name = "Office")]
            [ForeignKey("OfficeId")]
            public Office? Office { get; set; }
        }
    
}
