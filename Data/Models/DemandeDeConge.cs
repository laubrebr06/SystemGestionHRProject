namespace SystemGestionHR.Data.Models
{
    public class DemandeDeConge
    {
        public int DemandeDeCongeId { get; set; }
        public int EmployeId { get; set; }
        public bool? Status { get; set; }
        public int TypeCongeId { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string? CommentaireEmploye { get; set; }
        public string? CommentaireManager { get; set; }
        public TypeConge? TypeConge { get; set; }
        public Employe? Employe { get; set; }
    }
}