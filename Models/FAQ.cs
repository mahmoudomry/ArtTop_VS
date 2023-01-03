using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtTop.Models
{
    [Table("FAQ")]
    public class FAQ
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Arabic Title")]
        public string ArabicTitle { get; set; }
        [Required, Display(Name = "English Title")]
        public string EnglishTitle { get; set; }
        [Required, Display(Name = "Arabic Details")]
        public string ArabicDetails { get; set; }
        [Required, Display(Name = "English Details")]
        public string EnglishDetails { get; set; }
    }
}
