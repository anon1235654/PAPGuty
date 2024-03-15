using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;
namespace DataAccess
{
    public static class BikeDBHelper
    {
        private static string conn = "Server=mssqlstud.fhict.local;Database=dbi522197_dealership;User Id=dbi522197_dealership;Password=sebastiao522197;Encrypt=False";

        public static List<Bike> GetBikes()
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string stmt = "SELECT * FROM bikes";
                try
                {
                    List<Bike> bikes = new List<Bike>();
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            bikes.Add(new Bike(Convert.ToInt32(sqlDataReader["BikeID"]), Convert.ToString(sqlDataReader["Model"]), Convert.ToString(sqlDataReader["Brand"]), Convert.ToString(sqlDataReader["AddedBy"]), Convert.ToString(sqlDataReader["ImageURL"]), Convert.ToDouble(sqlDataReader["Price"])));
                        }
                        return bikes;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        } 
        public static Bike GetBike(int? id)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string stmt = "SELECT BikeID, Model, Brand, AddedBy, Price FROM bikes WHERE BikeID = @BikeId";
                try
                {
                    List<Bike> bikes = new List<Bike>();
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        command.Parameters.AddWithValue("@BikeId", id);
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        if (sqlDataReader.Read())
                        {
                            return new Bike(Convert.ToInt32(sqlDataReader[0]), Convert.ToString(sqlDataReader[1]), Convert.ToString(sqlDataReader[2]), Convert.ToString(sqlDataReader[3]), Convert.ToDouble(sqlDataReader[4]));
                        }

                        return null;
                    }
                }
                catch (Exception ex)
                {

                    return null;
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        
        public static void AddBike(Bike bike)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    if (bike.Image == null)
                    {
                        string stmt = "INSERT INTO bikes (Brand, Model, AddedBy, Price) VALUES (@Brand, @Model, @AddedBy, @Price)";

                        using (SqlCommand command = new SqlCommand(stmt, connection))
                        {
                            command.Parameters.AddWithValue("@Brand", bike.Brand.Trim());
                            command.Parameters.AddWithValue("@Model", bike.Model.Trim());
                            command.Parameters.AddWithValue("@AddedBy", bike.AddedBy.Trim());
                            command.Parameters.AddWithValue("@Price", bike.Price);
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string stmt = "INSERT INTO bikes (Brand, Model, AddedBy, ImageURL, Price) VALUES (@Brand, @Model, @AddedBy, @ImageURL, @Price)";

                        using (SqlCommand command = new SqlCommand(stmt, connection))
                        {
                            command.Parameters.AddWithValue("@Brand", bike.Brand.Trim());
                            command.Parameters.AddWithValue("@Model", bike.Model.Trim());
                            command.Parameters.AddWithValue("@AddedBy", bike.AddedBy.Trim());
                            command.Parameters.AddWithValue("@ImageURL", bike.Image.Trim());
                            command.Parameters.AddWithValue("@Price", bike.Price);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally { connection.Close(); }
            }
        }
        public static bool DeleteBike(int id)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string stmt = "DELETE FROM dbo.bikes WHERE BikeID = @BikeId";
                try
                {
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        command.Parameters.AddWithValue("@BikeId", id);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception(ex.Message);
                }
            }
        }
        public static bool UpdateBikeModel(Bike bike, string model)
        {
            string stmt = "UPDATE bikes SET Model = @model WHERE  BikeID = @id";

            using (SqlConnection connection = new SqlConnection(conn))
            {

                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        var salt = PasswordHasher.PasswordSalt();
                        command.Parameters.AddWithValue("@id", bike.Id);
                        command.Parameters.AddWithValue("@model", model);

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
        public static bool UpdateBikeBrand(Bike bike, string brand)

        {
            string stmt = "UPDATE bikes SET Brand = @brand WHERE BikeID = @id";

            using (SqlConnection connection = new SqlConnection(conn))
            {

                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        var salt = PasswordHasher.PasswordSalt();
                        command.Parameters.AddWithValue("@id", bike.Id);
                        command.Parameters.AddWithValue("@brand", brand);

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
        public static bool UpdateBikePrice(Bike bike, double price)
        {
            string stmt = "UPDATE bikes SET Price = @price WHERE BikeID = @id";

            using (SqlConnection connection = new SqlConnection(conn))
            {

                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        var salt = PasswordHasher.PasswordSalt();
                        command.Parameters.AddWithValue("@id", bike.Id);
                        command.Parameters.AddWithValue("@price", price);

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
        public static bool UpdateBikeImageURL(Bike bike, string imageUrl)
        {
            string stmt = "UPDATE bikes SET ImageURL = @imgurl WHERE BikeID = @id";

            using (SqlConnection connection = new SqlConnection(conn))
            {

                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        var salt = PasswordHasher.PasswordSalt();
                        command.Parameters.AddWithValue("@id", bike.Id);
                        command.Parameters.AddWithValue("@imgurl", imageUrl);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                    throw ex;
                }
                finally { connection.Close(); }
            }
        }
    }
}
