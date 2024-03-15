using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dealership.Pages
{
    public class LogoutModel : PageModel
    {
        public ActionResult OnGet()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("Login");
        }
    }
}
