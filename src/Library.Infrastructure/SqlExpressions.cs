namespace Library.Infrastructure
{
    public class SqlExpressions
    {
        public static string CreateItemExpression = "INSERT INTO {0} ({1}) VALUES ({2})";
        public static string DeleteItemExpression = "DELETE FROM {0} WHERE Id = @{1}";
        public static string SelectExpression = "SELECT {0} FROM {1} {2}";
        public static string UpdateItemExpression = "UPDATE {0} SET {1} {2}";
    }
}
