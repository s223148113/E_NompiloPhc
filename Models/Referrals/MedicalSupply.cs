using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace E_NompiloPhc.Models.Referrals
{
    public class MedicalSupply
    {
        [Remote("IsProductCodeValid", "MedicalSupply", AdditionalFields = "Name", ErrorMessage = "MedicalSupply Code Exists Already")]
        [Key]
        [StringLength(6)]
        public string Code { get; set; }

        [Remote("IsProductNameValid", "MedicalSupply", AdditionalFields = "Code", ErrorMessage = "MedicalSupply Name Exists Already")]
        [Required]
        [StringLength(85)]
        public String Name { get; set; }

        [Required]
        [StringLength(255)]
        public String Description { get; set; }

        [Required]
        [Column(TypeName = "smallmoney")]
        public decimal Cost { get; set; }

        [Required]
        [Column(TypeName = "smallmoney")]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("Units")]
        [Display(Name = "Unit")]
        public int UnitId { get; set; }
        public virtual Unit Units { get; set; }



        [ForeignKey("Brands")]
        [Display(Name = "Brand")]
        public int? BrandId { get; set; }
        public virtual Brand Brands { get; set; }


        [ForeignKey("Categories")]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public virtual Category Categories { get; set; }

        [ForeignKey("MedicalSupplyGroups")]
        [Display(Name = "MedicalSupplyGroup")]
        public int? MedicalSupplyGroupId { get; set; }
        public virtual MedicalSupplyGroup MedicalSupplyGroups { get; set; }


        [ForeignKey("MedicalSupplyProfiles")]
        [Display(Name = "MedicalSupplyProfile")]
        public int? MedicalSupplyProfileId { get; set; }
        public virtual MedicalSupplyProfile MedicalSupplyProfiles { get; set; }

        public string PhotoUrl { get; set; } = "noimage.png";

        [Display(Name = "MedicalSupply Photo")]
        [NotMapped]
        public IFormFile MedicalSupplyPhoto { get; set; }

        [NotMapped]
        public string BreifPhotoName { get; set; }
    }
}
