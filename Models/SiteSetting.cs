using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ArtTop.Models
{
    [Table("SiteSetting")]
    public class SiteSetting
    {

        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Header Logo")]
        public string HeaderLogo { get; set; }
        [Required, Display(Name = "Site Title meta English")]
        public string SiteTitleEn { get; set; }
        [Required, Display(Name = "Site Title meta Arabic")]
        public string SiteTitleAr { get; set; }

        [Required, Display(Name = "Site Desc meta")]
        public string SiteDescEn { get; set; }

        [Required, Display(Name = "Site Desc meta Ar")]
        public string SiteDescAr { get; set; }


        [Required, Display(Name = "Service Title English")]
        public string ServiceTitleEn { get; set; }
        [Required, Display(Name = "Service  Title Arabic ")]
        public string ServiceTitleAr { get; set; }


        [ Display(Name = "Service Desc En")]
        public string? ServiceDescEn { get; set; }
        [Display(Name = "Service Desc Ar")]
        public string? ServiceDescAr { get; set; }



        [Required, Display(Name = "Feature Title En")]
        public string FeatureTitleEn { get; set; }
        [Required, Display(Name = "Feature Title Ar")]
        public string FeatureTitleAr { get; set; }
        [Required, Display(Name = "Feature Desc En")]
        public string FeatureDescEn { get; set; }
        [Required, Display(Name = "Feature Title Ar")]
        public string FeatureDescAr { get; set; }
        [Required, Display(Name = "Feature img1 ")]
        public string? FeatureImg1 { get; set; }
        [Required, Display(Name = "Feature img2 ")]
        public string ?FeatureImg2 { get; set; }



        [Required, Display(Name = "Project Title En")]
        public string ProjectTitleEn { get; set; }

        [Required, Display(Name = "Project Title Ar")]
        public string ProjectTitleAr { get; set; }



        [Required, Display(Name = "Booking Title En")]
        public string BookingTitleEn { get; set; }

        [Required, Display(Name = "Booking Title Ar")]
        public string BookingTitleAr { get; set; }

        [Required, Display(Name = "Booking Desc En")]
        public string BookingDescEn { get; set; }

        [Required, Display(Name = "Booking Desc Ar")]
        public string BookingDescAr { get; set; }

        [ Display(Name = "Maaroof logo ")]
        public string? Maarooflogo { get; set; }

        [Display(Name = "vat logo ")]
        public string? VATlogo { get; set; }


        [Required, Display(Name = "CopyRight Text")]
        public string CopyRight { get; set; }

    }
}
