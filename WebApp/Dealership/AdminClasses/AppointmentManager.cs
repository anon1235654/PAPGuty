using EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace AdminClasses
{
    public class AppointmentManager:IAppointmentManager
    {
        
        public AppointmentManager() { }

        public bool CreateAppointment(Appointment appointment)
        {
            return AppointmentDBHelper.CreateAppointment(appointment);
        }

        public void DeleteAppointment(Appointment appointment) 
        {
            throw new NotImplementedException();
        }

        public List<UserAppointment> GetAppointmentByUser(int? id) 
        {
            return AppointmentDBHelper.GetAppointmentsByUser(id);
        }
        public List<UserAppointment> GetAppointments()
        {
            return AppointmentDBHelper.GetAppointments();
        }
        public void ChangeStatus(int id, string status)
        {
            AppointmentDBHelper.ChangeStatus(id, status);
        }
        public bool CheckTimeSlot(DateTime date, string timeSlot)
        {
            return AppointmentDBHelper.CheckTimeSlot(date, timeSlot);
        }
        public bool CheckUserAppointment(int id)
        { 
            return AppointmentDBHelper.CheckUserAppointments(id);
        }
    }
}
