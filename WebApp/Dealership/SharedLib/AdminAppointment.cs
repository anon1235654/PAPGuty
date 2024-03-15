using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntityClasses
{
    public class AdminAppointment:Appointment
    {
        public AdminAppointment(int? customerId, int? bikeId, DateTime date, string timePreference):base(customerId, bikeId, date, timePreference)
        {
            
        }
        public AdminAppointment(int id, int? customerId, int? bikeId, DateTime date, string timePreference, string status) : base(id, customerId, bikeId, date, timePreference, status)
        {
            
        }
    }
}
