using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtTop.Models
{
    [Table("About")]
    public class About
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Arabic Title")]
        public string ArabicTitle { get; set; }
        [Required, Display(Name = "English Title")]
        public string EnglishTitle { get; set; }
        [Required, Display(Name = "know us Title Arabic")]
        public string knowus_TitleArabic { get; set; }
        [Required, Display(Name = "know us Title English")]
        public string knowus_TitleEnglish { get; set; }
        [Required, Display(Name = "know us Desc Arabic")]
        public string knowus_DescArabic { get; set; }
        [Required, Display(Name = "know us Desc English")]
        public string knowus_DescEnglish { get; set; }
        [Display(Name = "know us image 1")]
        public string? knowus_img1 { get; set; }
        [Display(Name = "know us image 2")]
        public string? knowus_img2 { get; set; }

        [Display(Name = "Vision Icon")]
        public string ?VisionIcon { get; set; }
        [Required, Display(Name = "Vision Title Arabic")]
        public string VisionTitleArabic { get; set; }
        [Required, Display(Name = "Vision Title English")]
        public string VisionTitleEnglish { get; set; }
        [Required, Display(Name = "Vision Desc Arabic")]
        public string VisionDesceArabic { get; set; }
        [Required, Display(Name = "Vision Desc English")]
        public string VisionDescEnglish { get; set; }


        [ Display(Name = "Mission Icon")]
        public string? MissionIcon { get; set; }
        [Required, Display(Name = "Mission Title Arabic")]
        public string MissionTitleArabic { get; set; }
        [Required, Display(Name = "Mission Title English")]
        public string MissionTitleEnglish { get; set; }
        [Required, Display(Name = "Mission Desc Arabic")]
        public string MissionDescArabic { get; set; }
        [Required, Display(Name = "Mission Desc English")]
        public string MissionDescEnglish { get; set; }

        [Required, Display(Name = "Goles English Title")]
        public string GolesEnglishTitle { get; set; }
        [Required, Display(Name = "Goles Arabic Title")]
        public string GolesArabicTitle { get; set; }

    }
}
