namespace SystemGestionHR.Data.Models{  
    public class Genre
    {
        public int GenreId { get; set; }
        public string Nom { get; set; }
        public List<Employe> Employes { get; set; }
        public Genre()
        {
            Employes = new List<Employe>();
        }
    }
}