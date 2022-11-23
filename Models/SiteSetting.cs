using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ArtTop.Models
{
    [Table("SiteSetting")]
    public class SiteSetting
    {

        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Home Header Logo")]
        public string HomeHeaderLogo { get; set; }
        [Required, Display(Name = "Header Logo")]
        public string HeaderLogo { get; set; }
        [Required, Display(Name = "Site Title meta")]
        public string SiteTitle { get; set; }
        [Required, Display(Name = "Site Desc meta")]
        public string SiteDesc { get; set; }
        [Required, Display(Name = "Service Home Title ")]
        public string ServiceTitle { get; set; }
        [Required, Display(Name = "Service Home Desc")]
        public string ServiceDesc { get; set; }
        [Required, Display(Name = "Solutions Title")]
        public string SolutionsTitle { get; set; }

        [Required, Display(Name = "Solutions Desc")]
        public string SolutionsDesc { get; set; }

        [Required, Display(Name = "Projects Title")]
        public string ProjectsTitle { get; set; }

        [Required, Display(Name = "Projects Desc")]
        public string ProjectsDesc { get; set; }

        [Required, Display(Name = "Industries Title")]
        public string IndustriesTitle { get; set; }

        [Required, Display(Name = "Industries Desc")]
        public string IndustriesDesc { get; set; }

        [Required, Display(Name = "Partners Title")]
        public string PartnersTitle { get; set; }

        [Required, Display(Name = "Partners Desc")]
        public string PartnersDesc { get; set; }

        [Required, Display(Name = "Client Title")]
        public string ClientTitle { get; set; }

        [Required, Display(Name = "Client Desc")]
        public string ClientDesc { get; set; }

        [Required, Display(Name = "Subscribe Title")]
        public string SubscribeTitle { get; set; }
        [Required, Display(Name = "Footer Desc")]
        public string FooterDesc { get; set; }

        [Required, Display(Name = "CopyRight Text")]
        public string CopyRight { get; set; }


        [Required, Display(Name = "Footer Logo")]
        public string FooterLogo { get; set; }


        [Required, Display(Name = "Partner Page Title")]
        public string PartnerPageTitle { get; set; }
        [Required, Display(Name = "Partner Page Desc")]
        public string PartnerPageDesc { get; set; }

        [Required, Display(Name = "Contact Title ")]
        public string ContactTitle { get; set; }

        [Required, Display(Name = "Contact Title2")]
        public string ContactTitle2 { get; set; }
        [Display(Name = "Members Title")]
        public string MemberTitle { get; set; }
        [Display(Name = "Member Desc")]
        public string MemberDesc { get; set; }
    }
}
