using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;
namespace DataAccess
{
    public static class UserSettingsDBHelper
    {
        private static string conn = "Server=mssqlstud.fhict.local;Database=dbi522197_dealership;User Id=dbi522197_dealership;Password=sebastiao522197;Encrypt=False";
        public static bool AddSettings(User user, UserSettings settings)
        {
            string stmt = "INSERT INTO userSettings (UserID, Brand, MinPrice, MaxPrice) VALUES (@userID, @brand, @minPrice, @maxPrice)";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        var salt = PasswordHasher.PasswordSalt();
                        command.Parameters.AddWithValue("@userID", user.Id);
                        command.Parameters.AddWithValue("@brand", settings.PrefBrand);
                        command.Parameters.AddWithValue("@minPrice", settings.MinPrice);
                        command.Parameters.AddWithValue("@maxPrice", settings.MaxPrice);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally { connection.Close(); }
            }
        }

        public static bool CheckSettingExistence(User user)
        {
            //FALSE = EXISTS, TRUE = DOESN'T EXIST
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "SELECT COUNT(s.UserID) FROM userSettings AS s INNER JOIN users AS u ON s.UserID = u.ID AND s.UserID = @UserId WHERE s.UserID = @UserId"; //ASK GPT HOW TO DO A DOUBLE INNER JOIN FROM THE FIRST ROOT TABLE
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        
                        command.Parameters.AddWithValue("@UserId", user.Id);

                        int result = (int)command.ExecuteScalar();
                        if (result > 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                catch (SqlException exception)
                {
                    return false;
                    throw exception;
                }
                finally { sqlConnection.Close(); }
            }
        }

        public static UserSettings? GetSettings(User user)
        {
            bool check = CheckSettingExistence(user);
            string stmt = "SELECT s.Brand, s.MinPrice, s.MaxPrice FROM userSettings AS s INNER JOIN users AS u ON s.UserID = u.ID WHERE s.UserID = @userId";
            UserSettings settingsToRetrieve = null;
            if (!check)
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {

                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(stmt, connection))
                        {
                            command.Parameters.AddWithValue("@userId", user.Id);

                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                settingsToRetrieve = new UserSettings(
                                Convert.ToString(reader[0]),
                                Convert.ToDouble(reader[1]),
                                Convert.ToDouble(reader[2])
                                );
                            }
                            return settingsToRetrieve;
                        }

                    }
                    catch (SqlException ex)
                    {

                        throw ex;

                    }
                    finally { connection.Close(); }
                }

            }
            return null;
        }
        public static bool UpdateSettings(User user, UserSettings settings)
        {
         string stmt = "UPDATE s SET s.Brand = @brand, s.MinPrice = @min, s.MaxPrice = @max FROM userSettings s INNER JOIN users u ON u.ID = s.UserID WHERE s.UserID = @id;";

            using (SqlConnection connection = new SqlConnection(conn))
            {

                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        var salt = PasswordHasher.PasswordSalt();
                        command.Parameters.AddWithValue("@id", user.Id);
                        command.Parameters.AddWithValue("@brand", settings.PrefBrand);
                        command.Parameters.AddWithValue("@min", settings.MinPrice);
                        command.Parameters.AddWithValue("@max", settings.MaxPrice);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }

                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally { connection.Close(); }
            }
                
        }
        
    }   
}
