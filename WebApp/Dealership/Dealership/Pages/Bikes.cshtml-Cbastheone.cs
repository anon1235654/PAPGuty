using AdminClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EntityClasses;
namespace Dealership.Pages
{
    public class BikesModel : PageModel
    {
        private IBikeManager bikeManager = new BikeManager();
        private IRatingManager ratingManager = new RatingManager();
        private IUserSettingsManager userSettingsManager = new UserSettingsManager();
        private IUserManager userManager = new UserManager();
        [BindProperty]
        public List<Bike> BikeList { get; set; }
        [BindProperty]
        public Dictionary<int, double> BikeRate { get; set; }
        
        [BindProperty]
        public string BikeIdToAppoint { get; set; }
        [BindProperty]
        public string BikeBrandToAppoint { get; set; }
        [BindProperty]
        public string BikeModelToAppoint { get; set; }
        [BindProperty]
        public List<Bike> BikeSuggestions { get; set; }
        [BindProperty]
        public UserSettings? UserSettings { get; set; }
        public void OnGet()
        {     
           BikeList = bikeManager.GetBikes();
           BikeRate = ratingManager.GetRatingList();
           BikeSuggestions = new List<Bike>();
           if (HttpContext.Session.GetInt32("UserId") != null){
                UserSettings = userSettingsManager.GetSettings(userManager.GetUser(HttpContext.Session.GetInt32("UserId")));
                if (UserSettings != null){
                    foreach (Bike bike in BikeList)
                    {
                        if (bike.Brand.Trim() == UserSettings.PrefBrand.Trim() && bike.Price > UserSettings.MinPrice && bike.Price < UserSettings.MaxPrice)
                        {
                            BikeSuggestions.Add(bike);
                        }
                    }
                }
           }
            
           foreach(int rate in BikeRate.Values)
           {
                Console.WriteLine(rate);
           } 
           
           
        }

        public ActionResult OnPostSendBikeToAppoint()
        {
            

            if (int.TryParse(BikeIdToAppoint, out int bikeId))
            {
                if(BikeBrandToAppoint != null && BikeModelToAppoint != null && BikeIdToAppoint != null)
                {
                    HttpContext.Session.SetInt32("IDBikeToAppoint", bikeId);
                    HttpContext.Session.SetString("NameBikeToAppoint", $"{BikeBrandToAppoint} {BikeModelToAppoint}");
                    return RedirectToPage("Appointment");
                }
                return Page(); 
            }
            else
            {
                // Handle the case where BikeIdToAppoint is not a valid integer
                ModelState.AddModelError("BikeIdToAppoint", "Invalid bike ID format");
                return Page();
            }

            // return RedirectToPage("Appointment");
        }
    }
}
