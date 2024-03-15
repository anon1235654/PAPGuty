using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Xml.Linq;
using EntityClasses;


namespace DataAccess
{
    public static class UserDBHelper
    {
        private static string conn = "Server=mssqlstud.fhict.local;Database=dbi522197_dealership;User Id=dbi522197_dealership;Password=sebastiao522197;Encrypt=False";
        private static int userCount;

        
        private static bool CheckUser(string email) //For Registration
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    string queryString = "SELECT COUNT(ID) FROM users WHERE Email = @Email";
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        userCount = (int) command.ExecuteScalar();
                        if(userCount != 0)
                        {
                            return true;
                        } 
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally 
                {
                    connection.Close();
                }
                return false;
            }
        }
        private static byte[] GetSalt(string email) 
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    string queryString = "SELECT PasswordSalt FROM users WHERE Email = @Email";
                    

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            SqlBinary bin = reader.GetSqlBinary(reader.GetOrdinal("PasswordSalt"));
                            return bin.Value;
                        }
                        else return null;

                    }
                }
                catch(Exception ex) 
                {
                    return null;
                }finally 
                { connection.Close(); }
            }
        }
        private static bool CheckUser(string email, string password) //To Login
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    string queryString = "SELECT COUNT(ID) FROM users WHERE Email = @Email AND PasswordHash = @PasswordHash";
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        var passwordhashed = PasswordHasher.HashPassword(password, GetSalt(email));                        
                        command.Parameters.AddWithValue("@PasswordHash", passwordhashed); //I compare the hashed password with the salt that was used at the specific time of this registered account
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            userCount = Convert.ToInt32(reader[0]);
                        }
                        
                        
                        if (userCount != 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return false;
            }
        }
        public static bool RegisterUser(User user) 
        {
            bool check = CheckUser(user.Email);
            string stmt = "INSERT INTO users (Name, Email, PasswordHash, PasswordSalt, admin, premium) VALUES (@Name, @Email, @PasswordHash, @PasswordSalt, 0, 0)";
            if (!check)
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(stmt, connection))
                        {
                            var salt = PasswordHasher.PasswordSalt();
                            command.Parameters.AddWithValue("@Name", user.Name);
                            command.Parameters.AddWithValue("@Email", user.Email);
                            command.Parameters.AddWithValue("@PasswordHash", PasswordHasher.HashPassword(user.Password, salt));
                            command.Parameters.AddWithValue("@PasswordSalt", salt);

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
            else
            {
                return false;
            }
        }
        
        public static User GetUser(User user)
        {
            bool check = CheckUser(user.Email, user.Password);
            User userToRetrieve = null;
            string stmt = "SELECT ID, Name, Email, premium FROM users WHERE Email = @Email";

            if (check)
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {

                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(stmt, connection))
                        {
                            command.Parameters.AddWithValue("@Email", user.Email);

                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                userToRetrieve = new User(Convert.ToInt32(reader["ID"]), reader["Name"].ToString().Trim(), reader["Email"].ToString().Trim());
                            }
                            return userToRetrieve;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.OpenStandardOutput();
                        Console.WriteLine($"Index out of range ex: {ex.Message}");
                    }
                    finally { connection.Close(); }
                }
            }
            return userToRetrieve;
        }
        public static User GetUser(int? id)
        {
            
            User userToRetrieve = null;
            string stmt = "SELECT ID, Name, Email, premium FROM users WHERE ID = @Id";
                using (SqlConnection connection = new SqlConnection(conn))
                {

                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(stmt, connection))
                        {
                            command.Parameters.AddWithValue("@Id", id);

                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                userToRetrieve = new User(Convert.ToInt32(reader["ID"]), reader["Name"].ToString().Trim(), reader["Email"].ToString().Trim(), Convert.ToBoolean(reader["premium"]));
                            }
                            return userToRetrieve;
                        }

                    }
                    catch (Exception ex)
                    {
                        return null;
                        throw ex;
                    }
                    finally { connection.Close(); }
                }
            
            return userToRetrieve;
        }
        public static bool CheckPermissions(User user)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                
                connection.Open();
                try
                {
                    string stmt = "SELECT admin FROM users WHERE email = @email";
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        command.Parameters.AddWithValue("@email", user.Email);
                        return Convert.ToBoolean(command.ExecuteScalar());
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                } finally { connection.Close(); }
            }
            return false;
        }
        public static bool CheckPremium(int? id)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {

                connection.Open();
                try
                {
                    string stmt = "SELECT premium FROM users WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        return Convert.ToBoolean(command.ExecuteScalar());
                    }
                }
                catch (NullReferenceException ex)
                {
                    return false;
                    throw ex;
                }
                finally { connection.Close(); }
            }
            return false;
        }
        public static List<Customer> GetUsers() 
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string stmt = "SELECT * FROM users";
                try
                {
                    List<Customer> users = new List<Customer>();
                    using(SqlCommand command = new SqlCommand(stmt, connection)) 
                    {
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while(sqlDataReader.Read())
                        {
                            users.Add(new Customer(Convert.ToInt32(sqlDataReader["ID"]), Convert.ToString(sqlDataReader["Name"]), Convert.ToString(sqlDataReader["Email"]), Convert.ToBoolean(sqlDataReader["admin"]), Convert.ToBoolean(sqlDataReader["premium"])));
                        }
                        return users;
                    }
                }
                catch(Exception ex) 
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static bool DeleteUser(int id) 
        {
            using(SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string stmt = "DELETE FROM users WHERE ID = @userId";
                try
                {
                    using (SqlCommand command = new SqlCommand(stmt, connection)) 
                    {
                        command.Parameters.AddWithValue("@userId", id);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }catch(Exception ex) 
                {
                    return false;
                    throw new Exception(ex.Message);
                }
            } 
        }
        public static bool MakeUserPremium(int? id)
        {
            
            string stmt = "UPDATE users SET premium = 1 WHERE ID = @id";
            
                using (SqlConnection connection = new SqlConnection(conn))
                {

                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(stmt, connection))
                        {
                            var salt = PasswordHasher.PasswordSalt();
                            command.Parameters.AddWithValue("@id", id);
                            

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
        public static bool UpdateUserEmail(int? id, string email)
        {

            string stmt = "UPDATE users SET Email = @email WHERE ID = @id";

            using (SqlConnection connection = new SqlConnection(conn))
            {

                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        var salt = PasswordHasher.PasswordSalt();
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@email", email);


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
        public static bool UpdateUserPassword(int? id, string password)
        {

            string stmt = "UPDATE users SET PasswordHash = @Hash, PasswordSalt = @Salt WHERE ID = @id";

            using (SqlConnection connection = new SqlConnection(conn))
            {

                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        var salt = PasswordHasher.PasswordSalt();
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@Hash", PasswordHasher.HashPassword(password, salt));
                        command.Parameters.AddWithValue("@Salt", salt);


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

