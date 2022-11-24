using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtTop.Models
{
    [Table("Feature")]
    public class Feature
    {

        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Arabic Title")]
        [Required]
        public string ArabicTitle { get; set; } = "";
        [Display(Name = "English Title")]
        [Required]
        public string EnglishTitle { get; set; } = "";
  
        [Display(Name = "Icon")]
        public string? Icon { get; set; }
    }
}
