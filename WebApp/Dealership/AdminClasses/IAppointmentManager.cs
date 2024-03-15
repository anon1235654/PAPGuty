using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;

namespace AdminClasses
{
    public interface IAppointmentManager
    {
        bool CreateAppointment(Appointment appointment);
        
        List<UserAppointment> GetAppointmentByUser(int? id);
        List<UserAppointment> GetAppointments();
        void ChangeStatus(int id, string status);
        bool CheckTimeSlot(DateTime date, string timeSlot);
        bool CheckUserAppointment(int id);
    }
}
