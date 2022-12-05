using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtTop.Models
{
 
        [Table("OfficeSocialMedia")]
        public class OfficeSocialMedia
        {
            [Key]
            public int Id { get; set; }

        [Display(Name = "OfficeId")]
        public int? OfficeId { get; set; }
        [Display(Name = "Office")]
        [ForeignKey("OfficeId")]
        public Office? Office { get; set; }


        [Required, Display(Name = "Arabic Title")]
            public string ArabicTitle { get; set; }

            [Required, Display(Name = "English Title")]
            public string EnglishTitle { get; set; }

            [Display(Name = "Link")]
            public string? Link { get; set; }
            [Display(Name = "Icon")]
            public string? Icon { get; set; }
            [Display(Name = "Order")]
            public int Order { get; set; }
        }
    
}
