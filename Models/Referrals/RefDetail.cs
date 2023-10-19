using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace E_NompiloPhc.Models.Referrals
{
    public class RefDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("RefHeader")]
        public int RefId { get; set; }
        //public virtual RefHeader RefHeader { get; private set; }

        [Required]
        //[ForeignKey("MedicalSupply")]
        [MaxLength(6)]
        public string MedicalSupplyCode { get; set; }
        public virtual MedicalSupply MedicalSupply { get; private set; }

        [Column(TypeName = "smallmoney")]
        [Required]
        [Range(1, 1000, ErrorMessage = "Quantity should be greater than 0 and less than 1000")]
        public decimal Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.000}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "smallmoney")]
        [Range(1, 1000, ErrorMessage = "ForeignPrice should be greater than 0 and less than 1000")]
        [Required]
        public decimal ForeignPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.000}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "smallmoney")]
        [Required]
        public decimal PriceInBaseCurr { get; set; }

        [MaxLength(75)]
        [NotMapped]
        public string Description { get; set; } = "";

        [MaxLength(25)]
        [NotMapped]
        public string UnitName { get; set; } = "";

        [NotMapped]
        public bool IsDeleted { get; set; } = false;

        [NotMapped]
        public decimal Total { get; set; }
    }
}
