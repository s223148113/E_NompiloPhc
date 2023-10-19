using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models.Referrals
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
