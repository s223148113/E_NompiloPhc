using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_NompiloPhc.Models.GBV
{
    public class StaffLogTime
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]

        public string Department { get; set; }
        [Required]
        public string Vacation { get; set; }
        [Required]
        public string Sick { get; set; }
        [Required]
        public string Regular { get; set; }
        [Required]

        //start time & date
        [Display(Name = "Start Date/Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Start { get; set; }

        [Display(Name = "End Date/Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? End { get; set; }
    }
}
