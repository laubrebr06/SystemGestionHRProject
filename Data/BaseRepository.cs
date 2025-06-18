namespace SystemGestionHR.Data
{
    public abstract class BaseRepository: IBaseRepository
    {
        private readonly EmployeDB _employeDb;
        public BaseRepository(EmployeDB employeDB)
        {
            _employeDb = employeDB;
        }

        public void SaveChanges()
        {
            _employeDb.SaveChanges();
        }
    }
}
