using Dealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using AdminClasses;
using EntityClasses;
namespace Dealership.Pages
{
    public class LoginModel : PageModel
    {
        private UserManager _userManager = new UserManager();
        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        [Required]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "Enter your E-mail")]
        public string Email { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }

        public LoginModel()
        {
            
        }
        public ActionResult OnGet()
        {
            if(HttpContext.Session.GetInt32("UserId") != null)
            {
                return RedirectToPage("Account");
            }
            return Page();
        }

        

        
        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["EmptyCredentials"] = true;
                return Page();
            }

            var user = User;
            var email = Email.Trim();
            var password = Password.Trim();
            var name = Name;

            user.Email = email;
            user.Password = password;
            user.Name = name;

            User userToLogin = _userManager.Login(user);
            if (userToLogin != null)
            {
                user = userToLogin;
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserEmail", user.Email);
                return RedirectToAction("/Account");
            }
            else
            {
                ViewData["IncorrectCredentials"] = true;
                return Page();
            }
        }
    }
}
