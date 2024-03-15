using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;

namespace DataAccess
{
    public static class AppointmentDBHelper
    {
        private static string conn = "Server=mssqlstud.fhict.local;Database=dbi522197_dealership;User Id=dbi522197_dealership;Password=sebastiao522197;Encrypt=False";

        public static bool CreateAppointment(Appointment appointment)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "INSERT INTO appointments (BikeID, UserID, Date, TimePreference, Status) VALUES (@BikeID, @UserID, @Date, @TimePreference, @Status)";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@BikeID", appointment.BikeId);
                        command.Parameters.AddWithValue("@UserID", appointment.CustomerId);
                        command.Parameters.AddWithValue("@Date", appointment.Date);
                        command.Parameters.AddWithValue("@TimePreference", appointment.TimePreference);
                        command.Parameters.AddWithValue("@Status", appointment.Status);

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
        public static List<UserAppointment> GetAppointmentsByUser(int? id)
        {
            List<UserAppointment> list = new List<UserAppointment>();
            using (SqlConnection sqlconnection = new SqlConnection(conn))
            {
                try
                {
                    sqlconnection.Open();
                    string query = $"SELECT * FROM appointments AS a WHERE a.UserID = @UserId";
                    using (SqlCommand command = new SqlCommand(query, sqlconnection))
                    {
                        command.Parameters.AddWithValue("UserId", id);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(new UserAppointment(Convert.ToInt32(reader["ID"]), Convert.ToInt32(reader["UserID"]), Convert.ToInt32(reader["BikeID"]), Convert.ToDateTime(reader["Date"]), Convert.ToString(reader["TimePreference"]), Convert.ToString(reader["Status"])));
                        }
                        return list;
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally { sqlconnection.Close(); }
            }
        }
        public static List<UserAppointment> GetAppointments()
        {
            List<UserAppointment> list = new List<UserAppointment>();
            using (SqlConnection sqlconnection = new SqlConnection(conn))
            {
                try
                {
                    sqlconnection.Open();
                    string query = $"SELECT * FROM appointments";
                    using (SqlCommand command = new SqlCommand(query, sqlconnection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(new UserAppointment(Convert.ToInt32(reader["ID"]), Convert.ToInt32(reader["UserID"]), Convert.ToInt32(reader["BikeID"]), Convert.ToDateTime(reader["Date"]), Convert.ToString(reader["TimePreference"]), Convert.ToString(reader["Status"])));
                        }
                        return list;
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally { sqlconnection.Close(); }
            }
        }
        public static string GetAppointment(string status)
        {
            throw new NotImplementedException();
            //FOREACH LISTBOX IMPLEMENT WITH "Pending" "Accepted" "Done" "Cancelled"
        }
        public static void ChangeStatus(int id, string status)
        {
            using (SqlConnection sqlconnection = new SqlConnection(conn))
            {
                try
                {
                    sqlconnection.Open();
                    string query = $"UPDATE appointments SET Status = @status WHERE ID = @id";
                    using (SqlCommand command = new SqlCommand(query, sqlconnection))
                    {
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally { sqlconnection.Close(); }
            }
        }
        public static bool CheckTimeSlot(DateTime date, string timeSlot)
        {
            //FALSE = EXISTS , TRUE = DOESN'T EXIST
            using (SqlConnection sqlconnection = new SqlConnection(conn))
            {
                try
                {
                    sqlconnection.Open();
                    string query = $"SELECT COUNT(ID) FROM appointments WHERE Date = @date AND TimePreference = @timePref AND Status = 'Accepted'";
                    using (SqlCommand command = new SqlCommand(query, sqlconnection))
                    {
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@timePref", timeSlot);

                        var result = command.ExecuteScalar();
                        if(Convert.ToInt32(result) > 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    return false;
                    throw ex;
                }
                finally { sqlconnection.Close(); }
            }
        }
        public static bool CheckUserAppointments(int id) // Each user cannot have more than one appointment set to "pending" nor "accepted"
        {
            //FALSE = EXISTS , TRUE = DOESN'T EXIST
            using (SqlConnection sqlconnection = new SqlConnection(conn))
            {
                try
                {
                    sqlconnection.Open();
                    string query = $"SELECT COUNT(a.ID) FROM appointments AS a INNER JOIN users AS u ON a.UserID = u.ID WHERE a.UserID = @userId AND a.Status = 'Pending' OR a.UserID = @userId AND a.Status = 'Accepted' GROUP BY a.UserID";
                    using (SqlCommand command = new SqlCommand(query, sqlconnection))
                    {
                        command.Parameters.AddWithValue("@userId", id);
                        

                        var result = command.ExecuteScalar();
                        if(Convert.ToInt32(result) > 0) 
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    return false;
                    throw ex;
                }
                finally { sqlconnection.Close(); }
            }
        }
    }
}
