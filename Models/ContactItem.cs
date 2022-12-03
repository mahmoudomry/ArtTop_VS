using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtTop.Models
{ [Table("ContactItem")]
    public class ContactItem
    {
       
        
            [Key]
            public int Id { get; set; }

            [Display(Name = "English Value")]
            public string EnglishValue { get; set; }
        [Display(Name = "Arabic Value")]
        public string ArabicValue { get; set; }
        [Display(Name = "Icon")]
            public string? Icon { get; set; }
            [Display(Name = "Order")]
            public int Order { get; set; }
        [Display(Name = "Show in Home Footer")]
        public bool ShowInHome { get; set; }


    }
}
