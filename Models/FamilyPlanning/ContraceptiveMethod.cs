namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class ContraceptiveMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double EffectivenessRate { get; set; }
        public string SideEffects { get; set; }
        public string EligibilityCriteria { get; set; }
    }
    
}
