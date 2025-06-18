namespace SystemGestionHR.Data.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Nom{ get; set; }
        public List<Employe> Employes { get; set; }

        public Role()
        {
            Employes = new List<Employe>();
        }
    }
}