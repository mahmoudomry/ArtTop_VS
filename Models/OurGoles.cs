using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtTop.Models
{
    [Table("OurGoles")]
    public class OurGoles
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Arabic Title")]
        public string ArabicTitle { get; set; }
        [Required, Display(Name = "English Title")]
        public string EnglishTitle { get; set; }
        [Display(Name = " Icon")]
        public string? Icon { get; set; }
        [Display(Name = "Order")]
        public int? Order { get; set; }
    }
}
