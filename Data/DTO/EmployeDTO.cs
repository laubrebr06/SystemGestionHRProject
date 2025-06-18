namespace SystemGestionHR.Data.DTO
{
    public class EmployeDTO
    {
        public int EmployeId { get; set; }
        public string NomComplet { get; set; }
        public string Email { get; set; }
        public DateTime DateNaissante { get; set; }
        public int GenreId { get; set; }
        public string? Genre { get; set; }
        public int RoleId { get; set; }
        public string? Role { get; set; }

        public EmployeDTO()
        {

        }
    }
}