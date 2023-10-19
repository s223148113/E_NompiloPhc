using E_NompiloPhc.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        // Add more properties as needed.

    }
}
