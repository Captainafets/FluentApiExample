using System.Data;
using System.Data.SqlClient;

namespace FluentApiExample
{
    public class FluentSqlConnection :
        IServerSelectionStage,
        IDatabaseSelectionStage,
        IUserSelectionStage,
        IPasswordSelectionStage,
        IConnectionInitializerStage
    {
        private string _server = null!;
        private string _database = null!;
        private string _user = null!;
        private string _password = null!;

        private FluentSqlConnection()
        {
        }

        public static IServerSelectionStage CreateConnection()
        {
            return new FluentSqlConnection();
        }

        public IDatabaseSelectionStage ForServer(string server)
        {
            _server = server;
            return this;
        }

        public IUserSelectionStage AndDatabase(string database)
        {
            _database = database;
            return this;
        }

        public IPasswordSelectionStage AsUser(string user)
        {
            _user = user;
            return this;
        }

        public IConnectionInitializerStage WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public IDbConnection Connect()
        {
            var connection =
                new SqlConnection($"Server={_server};Database={_database};User Id={_user};Password={_password};");

            connection.Open();

            return connection;
        }
    }

    public interface IServerSelectionStage
    {
        public IDatabaseSelectionStage ForServer(string server);
    }

    public interface IDatabaseSelectionStage
    {
        public IUserSelectionStage AndDatabase(string database);
    }

    public interface IUserSelectionStage
    {
        public IPasswordSelectionStage AsUser(string user);
    }

    public interface IPasswordSelectionStage
    {
        public IConnectionInitializerStage WithPassword(string password);
    }

    public interface IConnectionInitializerStage
    {
        public IDbConnection Connect();
    }
}