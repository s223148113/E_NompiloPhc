namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class Feedback
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string FeedbackText { get; set; }
        public int Rating { get; set; }
    }
}
