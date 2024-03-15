using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClasses
{
    public abstract class Appointment //Method Factory/Virtual Constructor D.P. -- UserAppointments is for the website and the AdminAppointments for the appointments done by the admins
    {
        private int _id;
        private DateTime _date;
        private int? _customerId;
        private int? _bikeId;
        private string _status;
        private string _timePreference;
        public int ID { get { return _id; } }
        public DateTime Date { get { return _date; } }
        public int? CustomerId { get { return _customerId; } }
        public int? BikeId { get { return _bikeId; } }
        public string Status { get { return _status; } }
        public string TimePreference { get { return _timePreference; } }

        public Appointment(int? customerId, int? bikeId, DateTime date, string timePreference)
        {
            _date = date;
            _timePreference = timePreference;
            _customerId = customerId;
            _bikeId = bikeId;
            _status = "Pending";
        }
        public Appointment(int id, int? customerId, int? bikeId, DateTime date, string timePreference, string status)
        {
            _id = id;
            _date = date;
            _timePreference = timePreference;
            _customerId = customerId;
            _bikeId = bikeId;
            _status = status;
        }
    }
}
