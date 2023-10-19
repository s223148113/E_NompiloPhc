namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class UserPreference
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ChosenContraceptiveId { get; set; }
        public DateTime DateOfChoice { get; set; }
        public string Notes { get; set; }
        // Add more properties as needed.
    }
}
