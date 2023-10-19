using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace E_NompiloPhc.Models.Referrals
{
    public class HealthProvider
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(6)]
        public string Code { get; set; } = "";

        [Required]
        [MaxLength(75)]
        public string Name { get; set; } = "";


        [Remote("IsEmailExists", "HealthProvider", AdditionalFields = "Id", ErrorMessage = "Email Id Already Exists")]
        [Required]
        [MaxLength(75)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-Mail is not Valid")]
        public string EmailId { get; set; } = "";

        [MaxLength(75)]
        public string Address { get; set; } = "";

        [MaxLength(75)]
        public string PhoneNo { get; set; } = "";
    }
}
