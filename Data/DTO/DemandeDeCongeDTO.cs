namespace SystemGestionHR.Data.DTO
{
    public class DemandeDeCongeDTO
    {
        public int DemandeDeCongeId { get; set; }
        public string? NomComplet { get; set; }
        public int EmployeId { get; set; }
        public bool? Status { get; set; }
        public string? TypeConge { get; set; }
        public int TypeCongeId { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string? CommentaireEmploye { get; set; }
        public string? CommentaireManager { get; set; }

    }
}