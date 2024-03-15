using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using EntityClasses;
using AdminClasses;

namespace Dealership.Pages
{
    public class AccountModel : PageModel
    {
        private IAppointmentManager _appointmentManager = new AppointmentManager();
        private IBikeManager _bikeManager = new BikeManager();
        private IRatingManager _ratingManager = new RatingManager();
        private IUserManager _userManager = new UserManager();
        private IUserSettingsManager _userSettingsManager = new UserSettingsManager();
        private IRatingStrategy _ratingStrategy;
        private Rating rating;
        [BindProperty]
        public string UserName{ get; set; }
        [BindProperty]
        public int? UserId { get; set; }
        [BindProperty]
        public string UserEmail { get; set; }
        [BindProperty]
        public bool UserPremium { get; set; }
        [BindProperty]
        public List<UserAppointment> UserAppointments {  get; set; }
        [BindProperty]
        public List<Bike> BikesAppointed {  get; set; }
        [BindProperty]
        public double Rate { get; set; }
        [BindProperty]
        public int RateUserID { get; set; }
        [BindProperty]
        public int RateBikeID { get; set; }
        [BindProperty]
        public UserSettings? UserSettings { get; set; }
        [BindProperty]
        public string PrefBrand{ get; set; }
        [BindProperty]
        public double  MinPrice { get; set; }
        [BindProperty]
        public double MaxPrice { get; set; }
       [BindProperty]
        public List<string> BikeBrands { get; set; }

        private void SetStrategy(IRatingStrategy strategy) 
        {
            _ratingStrategy = strategy;
        }

        
        public ActionResult OnGet()
        {
            Console.WriteLine("Entering OnGet");
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToPage("Login");
            }
            BikesAppointed = new List<Bike>();
            UserAppointments = new List<UserAppointment>();
            BikeBrands = new List<string>();
           foreach (Bike bike in _bikeManager.GetBikes())
            {
                if (!BikeBrands.Contains(bike.Brand))
                {
                    BikeBrands.Add(bike.Brand);
                }
            }

            UserId = HttpContext.Session.GetInt32("UserId");
            UserName = HttpContext.Session.GetString("UserName");
            UserEmail = HttpContext.Session.GetString("UserEmail");

            UserPremium = _userManager.CheckPremium(UserId);

            UserAppointments = _appointmentManager.GetAppointmentByUser(UserId);

            
            foreach(Appointment appoint in UserAppointments) 
            {
                BikesAppointed.Add(_bikeManager.GetBike(appoint.BikeId));
            }
            ViewData["UserId"] = UserId.ToString();

            UserSettings = _userSettingsManager.GetSettings(_userManager.GetUser(UserId));
            if (UserSettings != null)
            {
                ViewData["UserSettingsExistence"] = true;
            }
            else
            {
                ViewData["UserSettingsExistence"] = false;
            }
            Console.WriteLine("Exitting OnGet");
            return Page();
        }

        public ActionResult OnPostRatingForm()
        {
            rating = new Rating(Rate, RateUserID, RateBikeID);
              
            if (_ratingManager.CheckExistenceRating(rating) == true)
            {
                _ratingManager.AddRating(rating);
                return Page();
            }
            else 
            {
                var updateRate = _ratingManager.UpdateRating(rating);
                if(updateRate == true)
                {
                    ViewData["rateUpdated"] = true;
                    return Page();
                }
                else
                {
                    ViewData["rateUpdated"] = false;
                    return Page();
                } 
            } 
        }

        public ActionResult OnPostBecomePremium()
        {
            _userManager.MakeUserPremium(HttpContext.Session.GetInt32("UserId"));
            return Page();
        }

        public ActionResult OnPostSettingsForm()
        {
            if(MinPrice > MaxPrice)
            {
                ViewData["MinPriceBigger"] = true;
                return Page();
                
            }
            UserSettings UserSettingsToUpdate = new UserSettings(PrefBrand, MinPrice, MaxPrice);
            User userToUpdate = _userManager.GetUser(HttpContext.Session.GetInt32("UserId"));
            if (UserSettings != null){
                if (_userSettingsManager.AddSettings(userToUpdate, UserSettingsToUpdate))
                {
                    ViewData["SettingsAdded"] = true;
                    return Page();
                }
                else
                {
                    ViewData["SettingsAdded"] = false;
                    return Page();
                }
            }
            else
            {
                
                if (_userSettingsManager.UpdateSettings(userToUpdate, UserSettingsToUpdate))
                {
                    ViewData["SettingsAdded"] = true;
                }
                else
                {
                    ViewData["SettingsAdded"] = true;
                }
                return Page();
            }
            
        }
    }
}
