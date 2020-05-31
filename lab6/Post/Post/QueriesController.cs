using System;
using System.Data;
using Npgsql;

namespace Post
{
    public class DatabaseController
    {
        private readonly NpgsqlConnection _connection;

        public DatabaseController(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        
        // #1
        public DataSet MurzilkaSubscribers()
        {
            try
            {
                _connection.Open();
                
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = _connection;
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
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        // #2
        public int DistrictsCount()
        {
            try
            {
                _connection.Open();

                NpgsqlCommand command = new NpgsqlCommand(
                    "select count(*) from districts",
                    _connection);

                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
        
        // #3
        public DataSet StreetsInDistrict()
        {
            try
            {
                _connection.Open();

                string sql =
                    "select district_name as district, count(street_id) as streets_count " +
                    "from districts d " +
                    "inner join streets s " +
                    "on d.district_id = s.district_id " +
                    "group by d.district_id";
                
                NpgsqlCommand command = new NpgsqlCommand(sql, _connection);
                
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                
                return ds;
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
        
        // #4
        public decimal AvgCost()
        {
            try
            {
                _connection.Open();

                NpgsqlCommand command = new NpgsqlCommand();
                command.CommandText = "select avg(cast(cost as decimal)) from papers";
                command.Connection = _connection;

                return (decimal) command.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
        
        // #5
        public DataSet SubscriptionsCount()
        {
            try
            {
                _connection.Open();

                string sql =
                    "select full_name as subscriber, count(subscriptions.paper_cipher) as subscriptions_count " +
                    "from subscribers " +
                    "full join subscriptions " +
                    "on subscribers.subscriber_id = subscriptions.subscriber_id " +
                    "group by subscribers.subscriber_id " +
                    "order by subscriptions_count;";

                NpgsqlCommand command = new NpgsqlCommand(sql, _connection);

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
        
        // #6
        public DataSet DistrictAndPostmen()
        {
            try
            {
                _connection.Open();

                string sql =
                    "select full_name, district_name, postman " +
                    "from subscribers " +
                    "inner join addresses " +
                    "on subscribers.subscriber_id = addresses.address_id " +
                    "inner join streets " +
                    "on addresses.street_id = streets.street_id " +
                    "inner join districts " +
                    "on streets.district_id = districts.district_id;";
                
                NpgsqlCommand command = new NpgsqlCommand(sql, _connection);
                
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
        
        // #7

        public DataSet AddressesAndPapers()
        {
            try
            {
                _connection.Open();

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
                
                NpgsqlCommand command = new NpgsqlCommand(sql, _connection);
                
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
        

        // #8
        public decimal GetBill(int sId)
        {
            try
            {
                _connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("get_bill", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("s_id", sId);

                var result = command.ExecuteScalar();
                if (result.GetType() == Type.GetType("System.DBNull"))
                    return 0;

                return Convert.ToDecimal(result);
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
            
        }

        // #9
        public DataSet PaperSubscribers(string pCipher)
        {
            try
            {
                _connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("get_subs", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("p_cipher", pCipher);

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        // #10
        public DataSet IncreaseCost()
        {
            try
            {
                _connection.Open();
                var transaction = _connection.BeginTransaction();

                NpgsqlCommand command1 = new NpgsqlCommand("update papers set cost = cost + cast (5 as money)", _connection);
                command1.Transaction = transaction;
                command1.ExecuteNonQuery();

                NpgsqlCommand command2 = new NpgsqlCommand("select * from papers", _connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command2);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                transaction.Rollback(); // #TODO Change the transaction call on .Commit()

                return ds;
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}