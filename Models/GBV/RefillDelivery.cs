using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models.GBV
{
    public class RefillDelivery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //search patient by email to see address

        public string PatientEmail { get; set; }
        [Required]
        //search patient by email to see address

        public string DeliverName { get; set; }

        [Required]
        //search patient by email to see address

        public string DeliverLastName { get; set; }
        [Required]
        //search patient by email to see address
        public string DeliveryDepartment { get; set; }
        public DateTime DepartDate { get; set; }
        [Required]
        //search patient by email to see address


        public DateTime DeliveryArrival { get; set; }
        public string PHCName { get; set; }
        [Required]
        //search patient by email to see address

        public string DoctorApprover { get; set; }
        [Required]
        //search patient by email to see address

        public string DeliverYesNo { get; set; }
    }
}
