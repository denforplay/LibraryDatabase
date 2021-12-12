namespace Library.Domain.Configurations
{
    /// <summary>
    /// Class contains connection to databases strings
    /// </summary>
    public class ConnectionStrings
    {
        public static string MSSQLConnectionString => "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True";
    }
}
