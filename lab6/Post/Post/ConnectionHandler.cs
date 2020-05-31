using System;
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
            {
                string connectionString = ConfigReader.ReadConnectionString();

                _connectionHandler = new ConnectionHandler(connectionString);
            }

            return _connectionHandler._connection;
        }
    }
}