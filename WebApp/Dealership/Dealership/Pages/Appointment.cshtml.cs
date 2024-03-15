using AdminClasses;
using Dealership.Models;
using EntityClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Pages
{
    public class AppointmentModel : PageModel
    {
        private IAppointmentManager _appointmentManager = new AppointmentManager();
        private IBikeManager _bikeManager;
        private string _minDate;

        
        [BindProperty]
        [DateRange(ErrorMessage = "Invalid Date.")]
        public DateTime Date { get; set; }

        [BindProperty]
        public string TimePref { get; set; }

        public ActionResult OnGet()
        {
            
            _bikeManager = new BikeManager();
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToPage("Login");
            }

            if(HttpContext.Session.GetInt32("IDBikeToAppoint") == null)
            {
                return RedirectToPage("Bikes");
            }
            return Page();
        }

        public ActionResult OnPost()
        {
                

            if (!ModelState.IsValid)
            {
                ViewData["invalidDate"] = true;
                return Page();
            }

            string timePref = TimePref;
            if (_appointmentManager.CheckTimeSlot(Date, timePref))
            {
                if(_appointmentManager.CheckUserAppointment(Convert.ToInt32(HttpContext.Session.GetInt32("UserId"))) == true)
                {
                    try
                    {
                        _appointmentManager.CreateAppointment(new UserAppointment(HttpContext.Session.GetInt32("UserId"), HttpContext.Session.GetInt32("IDBikeToAppoint"), Date, timePref));
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                else
                {
                    ViewData["userAppointmentExists"] = true;
                    return Page();
                }
            }
            else
            {
                ViewData["busyDate"] = true;
                return Page();
            }
            return RedirectToPage("Account");
            
        }
    }
}
