using Npgsql;

namespace Post
{
    public class ConnectionHandler
    {
        private static ConnectionHandler _connectionHandler;
        private readonly NpgsqlConnection _connection;

        private ConnectionHandler(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }

        public static NpgsqlConnection GetInstance()
        {
            if (_connectionHandler == null)
                _connectionHandler = new ConnectionHandler("Host=localhost;Database=post;Username=postgres;Password=123456;Port=5432");

            return _connectionHandler._connection;
        }
    }
}