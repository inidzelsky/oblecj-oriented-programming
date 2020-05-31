using System;
using System.Data;
using Npgsql;

namespace Post
{
    public class CreateController
    {
        public static void CreateDistrict(NpgsqlConnection connection, string districtName, string postman)
        {
            try
            {
                connection.Open();

                string sql = "insert into districts (district_name, postman) values (@district_name, @postman)";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter districtNameParam = new NpgsqlParameter("@district_name", districtName);
                command.Parameters.Add(districtNameParam);

                NpgsqlParameter postmanParam = new NpgsqlParameter("@postman", postman);
                command.Parameters.Add(postmanParam);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
        public static void CreateStreet(NpgsqlConnection connection, int districtId, string streetName)
        {
            try
            {
                connection.Open();

                string sql = "insert into streets (district_id, street_name) values (@district_id, @street_name)";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter districtIdParam = new NpgsqlParameter("@district_id", districtId);
                command.Parameters.Add(districtIdParam);

                NpgsqlParameter streetNameParam = new NpgsqlParameter("@street_name", streetName);
                command.Parameters.Add(streetNameParam);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
        public static void CreateAddress(NpgsqlConnection connection, int streetId, string number)
        {
            try
            {
                connection.Open();

                string sql = "insert into addresses (street_id, number) values (@street_id, @number)";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter streetIdParam = new NpgsqlParameter("@street_id", streetId);
                command.Parameters.Add(streetIdParam);

                NpgsqlParameter numberParam = new NpgsqlParameter("@number", number);
                command.Parameters.Add(numberParam);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
        public static void CreateSubscriber(NpgsqlConnection connection, int addressId, string fullName)
        {
            try
            {
                connection.Open();

                string sql = "insert into subscribers (address_id, full_name) values (@address_id, @full_name)";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter addressIdParam = new NpgsqlParameter("@address_id", addressId);
                command.Parameters.Add(addressIdParam);

                NpgsqlParameter fullNameParam = new NpgsqlParameter("@full_name", fullName);
                command.Parameters.Add(fullNameParam);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void CreatePaper(NpgsqlConnection connection, string paperCipher, string name, int cost)
        {
            try
            {
                connection.Open();

                string sql = "insert into papers (paper_cipher, name, cost) values (@paper_cipher, @name, @cost)";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter paperCipherParam = new NpgsqlParameter("@paper_cipher", paperCipher);
                command.Parameters.Add(paperCipherParam);

                NpgsqlParameter nameParam = new NpgsqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                
                NpgsqlParameter costParam = new NpgsqlParameter("@cost", cost);
                command.Parameters.Add(costParam);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
        public static void CreateSubscription(NpgsqlConnection connection, string paperCipher, int subscriberId)
        {
            try
            {
                connection.Open();

                string sql = "insert into subscriptions (paper_cipher, subscriber_id) values (@paper_cipher, @subscriber_id)";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter paperCipherParam = new NpgsqlParameter("@paper_cipher", paperCipher);
                command.Parameters.Add(paperCipherParam);

                NpgsqlParameter subscriberIdParam = new NpgsqlParameter("@subscriber_id", subscriberId);
                command.Parameters.Add(subscriberIdParam);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
    }
}