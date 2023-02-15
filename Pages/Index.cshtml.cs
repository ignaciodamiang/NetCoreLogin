using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetCoreLogin.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPostLoginAsync()
        {
            // Validate the email entered by the user
            if (string.IsNullOrEmpty(Email))
                ModelState.AddModelError("Email", "The Email field is required");
            else if (Email != "test@test.com")
                ModelState.AddModelError("Email", "Invalid email");
            // Validate the password entered by the user
            else if (string.IsNullOrEmpty(Password))
                ModelState.AddModelError("Password", "The password field is required");
            else if (Password != "123456789")
                ModelState.AddModelError("Password", "Invalid password");

            // If there are any validation errors, redisplay the form
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // If the email and password are valid
            return RedirectToPage("/Dashboard");
    }
}
}