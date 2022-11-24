using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ArtTop.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "TitleEn")]
        public string TitleEn { get; set; }
        [Required, Display(Name = "TitleAr")]
        public string TitleAr { get; set; }
        [Display(Name = "Link")]
        public string? Link { get; set; }
        [Display(Name = "Image")]
        public string? Image { get; set; }
    }
}
