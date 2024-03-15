using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;
namespace DataAccess
{
    public static class RatingDBHelper
    {
        private static string conn = "Server=mssqlstud.fhict.local;Database=dbi522197_dealership;User Id=dbi522197_dealership;Password=sebastiao522197;Encrypt=False";
        
        public static bool AddRating(Rating rating)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "INSERT INTO ratings (Rate, UserID, BikeID) VALUES (@Rate, @UserId, @BikeId)";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@Rate", rating.Rate);
                        command.Parameters.AddWithValue("@UserId", rating.UserID);
                        command.Parameters.AddWithValue("@BikeId", rating.BikeID);
                        
                        

                        command.ExecuteNonQuery();
                        return true;
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
        public static bool UpdateRating(Rating rating)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "UPDATE r SET r.Rate = @Rate FROM ratings r INNER JOIN users AS u ON u.ID = r.UserID INNER JOIN bikes AS b ON b.BikeID = r.BikeID WHERE r.UserID = @UserId AND r.BikeID = @BikeId";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@Rate", rating.Rate);
                        command.Parameters.AddWithValue("@UserId", rating.UserID);
                        command.Parameters.AddWithValue("@BikeId", rating.BikeID);


                        command.ExecuteNonQuery();
                        return true;
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
        public static bool CheckExistenceRating(Rating rating)
        {
            //FALSE = EXISTS, TRUE = DOESN'T EXIST
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "SELECT COUNT(r.Rate) FROM ratings AS r INNER JOIN users AS u ON r.UserID = u.ID AND r.UserID = @UserId INNER JOIN bikes AS b ON r.BikeID = b.BikeID WHERE r.UserID = @UserId AND r.BikeID = @BikeId"; //ASK GPT HOW TO DO A DOUBLE INNER JOIN FROM THE FIRST ROOT TABLE
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@Rate", rating.Rate);
                        command.Parameters.AddWithValue("@UserId", rating.UserID);
                        command.Parameters.AddWithValue("@BikeId", rating.BikeID);


                        int result = (int)command.ExecuteScalar();
                        if(result > 0)
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
        

        public static List<Rating> GetRatingsperBike(int id)
        {
            List<Rating> rates = new List<Rating>();
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "SELECT r.Rate, r.UserID, r.BikeID FROM ratings AS r INNER JOIN bikes AS b ON r.BikeID = b.BikeID INNER JOIN users AS u ON r.UserID = u.ID WHERE r.BikeID = @BikeId";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@BikeId", id);

                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            rates.Add(new Rating(Convert.ToDouble(reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2])));
                        }
                        return rates;
                    }
                }
                catch (SqlException exception)
                {
                    throw exception;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally { sqlConnection.Close(); }
            }
        }
    }
}
