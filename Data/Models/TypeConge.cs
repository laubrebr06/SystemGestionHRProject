namespace SystemGestionHR.Data.Models
{
    public class TypeConge
    {
        public int TypeCongeId { get; set; }
        public string Nom { get; set; }
        public int ValeurInitiale { get; set; }
        public List<DemandeDeConge> DemandesDeConge { get; set; }

        public TypeConge()
        {
            DemandesDeConge = new List<DemandeDeConge>();
        }
    }
}