namespace FluentApiExample
{
    public static class Program
    {
        public static void Main()
        {
            var connection = FluentSqlConnection.CreateConnection()
                .ForServer("myServer")
                .AndDatabase("myDatabase")
                .AsUser("user")
                .WithPassword("password")
                .Connect();
        }
    }
}