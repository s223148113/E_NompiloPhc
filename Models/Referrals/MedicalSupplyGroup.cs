using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace E_NompiloPhc.Models.Referrals
{
    public class MedicalSupplyGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string Description { get; set; }
    }
}
