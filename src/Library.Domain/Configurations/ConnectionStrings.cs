namespace Library.Domain.Configurations
{
    /// <summary>
    /// Class contains connection to databases strings
    /// </summary>
    public class ConnectionStrings
    {
        public static string MSSQLConnectionString => @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}\Library.Infrastructure\Data\LibraryDb.mdf;Integrated Security=True";
    }
}
