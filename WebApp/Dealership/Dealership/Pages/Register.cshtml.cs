using Dealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using EntityClasses;
using AdminClasses;
using Microsoft.AspNetCore.Identity;
using System;

namespace Dealership.Pages
{
    public class RegisterModel : PageModel
    {
        private UserManager _userManager = new UserManager();
        [BindProperty]
        [Required]
        public Customer User { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Enter your E-mail")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }
        public RegisterModel()
        {
            
        }
        public ActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                return RedirectToPage("Account");
            }
            
            return Page();
        }
        
        
        public ActionResult OnPost()
        {
            var user = User;
            var name = Name;
            var email = Email;
            var password = Password;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Processing and assigning the inputs
            user.Name = name.Trim();
            user.Email = email.Trim();
            user.Password = password.Trim();

            //Verifying regular expressions
            if (RegularExpressions.CheckCredentials(user.Email, user.Password))
            {
                //Verifying the Existence of the E-mail in the DB
                if (!_userManager.RegisterUser(user))
                {
                    ViewData["UserExists"] = true;
                    return Page();
                }
                else
                {
                    return RedirectToPage("Login");
                }
            }
            else
            {
                ViewData["NotRegularExpression"] = true;
                return Page();
            }
        }
    }
}
