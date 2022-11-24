using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ArtTop.Models
{
    [Table("NewsLetter")]
    public class NewsLetter
    {
        [Key]
        [Required, Display(Name = "Email")]
        public string Email { get; set; }

        public DateTime Created_at { get; set; }
    }
}
