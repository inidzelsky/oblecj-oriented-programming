using System;
using System.Data;
using Npgsql;

namespace Post
{
    public class UpdateController
    {
        public static void UpdateDistrict(NpgsqlConnection connection, int districtId, string districtName,
            string postman)
        {
            try
            {
                connection.Open();

                string sql =
                    "update districts set district_name = @district_name, postman = @postman where district_id = @district_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter districtIdParam = new NpgsqlParameter("@district_id", districtId);
                command.Parameters.Add(districtIdParam);

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

        public static void UpdateStreet(NpgsqlConnection connection, int streetId, int districtId, string streetName)
        {
            try
            {
                connection.Open();

                string sql =
                    "update streets set district_id=@district_id, street_name=@street_name _where street_id=@street_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter streetIdParam = new NpgsqlParameter("@street_id", streetId);
                command.Parameters.Add(streetIdParam);

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

        public static void UpdateAddress(NpgsqlConnection connection, int addressId, int streetId, string number)
        {
            try
            {
                connection.Open();

                string sql = "update addresses set street_id=@street_id, number=@number where address_id=@address_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter addressIdParam = new NpgsqlParameter("@address_id", addressId);
                command.Parameters.Add(addressIdParam);

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

        public static void UpdateSubscriber(NpgsqlConnection connection, int subscriberId, int addressId,
            string fullName)
        {
            try
            {
                connection.Open();

                string sql =
                    "update subscribers set address_id=@address_id, full_name=@full_name where subscriber_id=@subscriber_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter subscriberIdParam = new NpgsqlParameter("@subscriber_id", subscriberId);
                command.Parameters.Add(subscriberIdParam);

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

        public static void UpdatePaper(NpgsqlConnection connection, string paperCipher, string name, int cost)
        {
            try
            {
                connection.Open();

                string sql = "update papers set name=@name, cost=@cost where paper_cipher=@paper_cipher";
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
    }
}