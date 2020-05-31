using System;
using System.Data;
using Npgsql;

namespace Post
{
    public class DeleteController
    {
        public static void DeleteDistrict(NpgsqlConnection connection, int districtId)
        {
            try
            {
                connection.Open();

                string sql = "delete from districts where district_id = @district_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter districtIdParam = new NpgsqlParameter("@district_id", districtId);
                command.Parameters.Add(districtIdParam);

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

        public static void DeleteStreet(NpgsqlConnection connection, int streetId)
        {
            try
            {
                connection.Open();

                string sql = "delete from streets where street_id = @street_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter streetIdParam = new NpgsqlParameter("@street_id", streetId);
                command.Parameters.Add(streetIdParam);

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

        public static void DeleteAddress(NpgsqlConnection connection, int addressId)
        {
            try
            {
                connection.Open();

                string sql = "delete from addresses where address_id = @address_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter addressIdParam = new NpgsqlParameter("@address_id", addressId);
                command.Parameters.Add(addressIdParam);

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

        public static void DeleteSubscriber(NpgsqlConnection connection, int subscriberId)
        {
            try
            {
                connection.Open();

                string sql = "delete from subscribers where subscriber_id = @subscriber_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

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

        public static void DeletePaper(NpgsqlConnection connection, string paperCipher)
        {
            try
            {
                connection.Open();

                string sql = "delete from papers where paper_cipher = @paper_cipher";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                NpgsqlParameter paperCipherParam = new NpgsqlParameter("@paper_cipher", paperCipher);
                command.Parameters.Add(paperCipherParam);

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

        public static void DeleteSubscription(NpgsqlConnection connection, string paperCipher, int subscriberId)
        {
            try
            {
                connection.Open();

                string sql =
                    "delete from subscriptions where (paper_cipher=@paper_cipher and subscriber_id= @subscriber_id)";
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