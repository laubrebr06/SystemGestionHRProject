namespace SystemGestionHR.Data.Models
{
    public class Employe
    {
        public int EmployeId { get; set; }
        public string NomComplet { get; set; }
        public string Email { get; set; }
        public DateTime DateNaissance { get; set; }
        public int GenreId { get; set; }
        public int RoleId { get; set; }
        public Genre Genre { get; set; }

        public Role Role { get; set; }
        public List<DemandeDeConge> DemandesConge { get; set; }

        public Employe()
        {
            DemandesConge = new List<DemandeDeConge>();
        }
    }
}