using System;
using System.Data;
using Npgsql;


namespace Post
{
    public class DatabaseController
    {
        private string _connectionString;

        public DatabaseController(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        // #1
        public DataSet MurzilkaSubscribers()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = connection;
                command.CommandText = 
                    "select subscribers.subscriber_id, full_name " + 
                    "from subscribers, subscriptions "  +
                    "where subscribers.subscriber_id = subscriptions.subscriber_id " +
                    "and subscriptions.paper_cipher = " +
                        "(select paper_cipher from papers where name='Murzilka')";

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                
                return ds;
            }
        }

        // #2
        public int DistrictsCount()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                
                NpgsqlCommand command = new NpgsqlCommand(
                    "select count(*) from districts;", 
                    connection);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        
        public DataSet StreetsInDistrict()
        {
            var connection = new NpgsqlConnection(_connectionString);
            DataSet ds = new DataSet();
            try
            {
                connection.Open();

                string sql =
                    "select district_name as district, count(street_id) as streets_count " +
                    "from districts d " +
                    "inner join streets s " +
                    "on d.district_id = s.district_id " +
                    "group by d.district_id";
                
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                adapter.Fill(ds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }
            
            return ds;
        }
        
        public decimal AvgCost()
        {
            var connection = new NpgsqlConnection(_connectionString);
            decimal result;
            try
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand();
                command.CommandText = "select avg(cast(cost as decimal)) from papers";
                command.Connection = connection;

                result = (decimal) command.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }
            
            return result;
        }
        
        // #3
        public DataSet SubscriptionsCount()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string sql =
                    "select full_name as subscriber, count(subscriptions.paper_cipher) as subscriptions_count " +
                    "from subscribers " +
                    "full join subscriptions " +
                    "on subscribers.subscriber_id = subscriptions.subscriber_id " +
                    "group by subscribers.subscriber_id " +
                    "order by subscriptions_count;";
                
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
        }
        
        // #4
        public DataSet DistrictAndPostmen()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string sql =
                    "select full_name, district_name, postman " +
                    "from subscribers " +
                    "inner join addresses " +
                    "on subscribers.subscriber_id = addresses.address_id " +
                    "inner join streets " +
                    "on addresses.street_id = streets.street_id " +
                    "inner join districts " +
                    "on streets.district_id = districts.district_id;";
                
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
        }
        
        // #5

        public DataSet AddressesAndPapers()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string sql =
                    "select street_name || ' ' || a.number as Address, papers.name as Paper " +
                    "from papers " +
                    "inner join subscriptions s " +
                    "on papers.paper_cipher = s.paper_cipher " +
                    "inner join subscribers s2  " +
                    "on s.subscriber_id = s2.subscriber_id " +
                    "inner join addresses a " +
                    "on s2.address_id = a.address_id " +
                    "inner join streets s3 " +
                    "on a.street_id = s3.street_id;";
                
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
        }
        
        



        // #6
        public decimal GetBill(int sId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("get_bill", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("s_id", sId);
                
                var result = command.ExecuteScalar();
                if (result.GetType() == Type.GetType("System.DBNull"))
                    return 0;
                
                return Convert.ToDecimal(result);
            }
        }

        // #7
        public DataSet PaperSubscribers(string pCipher)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("get_subs", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("p_cipher", pCipher);
                
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                
                return ds;
            }
        }

        // #8
        public DataSet IncreaseCost()
        {
            var connection = new NpgsqlConnection(_connectionString);
            DataSet ds = new DataSet();
            
            try
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                NpgsqlCommand command1 = new NpgsqlCommand("update papers set cost = cost + cast (5 as money)", connection);
                command1.Transaction = transaction;
                command1.ExecuteNonQuery();

                NpgsqlCommand command2 = new NpgsqlCommand("select * from papers", connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command2);
                adapter.Fill(ds);

                transaction.Rollback();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            
            return ds;
        }
    }
}