using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtTop.Models
{
    [Table("ServiceSlider")]
    public class ServiceSlider
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Cover Image")]
        public string? CoverImage { get; set; } = "";
        [Display(Name = "IsActive")]
        [Required(ErrorMessage = "Required *")]
        public bool IsActive { get; set; } = false;
        [Display(Name = "Order")]
        [Required(ErrorMessage = "Required *")]
        public int Order { get; set; }
        [Display(Name = "ServiceId")]
        public int? ServiceId { get; set; }
        [Display(Name = "Service")]
        [ForeignKey("ServiceId")]
        public Service? Service { get; set; }
    }
}
