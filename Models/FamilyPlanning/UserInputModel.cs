using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class UserInputModel
    {
        [Key] // Specify that this property is the primary key
        public int Id { get; set; }
        public int Age { get; set; } // User's age
        public string Gender { get; set; } // User's gender (male, female, etc.)
        public bool HasChildren { get; set; } // Whether the user has children (true/false)
        public bool Smokes { get; set; } // Whether the user smokes (true/false)
        public bool HasMedicalCondition { get; set; } // Whether the user has a medical condition (true/false)
        public string MedicalHistory { get; set; } // Brief description of the user's medical history
        public string PreferredContraceptiveMethod { get; set; } // User's preferred contraceptive method (if any)
                                                                 // Add more properties as needed to capture other relevant user preferences and medical history
    }
}
