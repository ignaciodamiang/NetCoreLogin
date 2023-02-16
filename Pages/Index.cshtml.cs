using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetCoreLogin.Services.Interfaces;
using System.Threading.Tasks;

namespace NetCoreLogin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IApiService _apiService;

        public IndexModel(IApiService apiService)
        {
            _apiService = apiService;
        }
        
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            // Validate the email entered by the user
            if (string.IsNullOrEmpty(Email))
            {
                ModelState.AddModelError("Email", "The Email field is required");
            }
            else if (!await _apiService.ValidateUserAsync(Email, Password))
            {
                ModelState.AddModelError("Email", "Invalid email or password");
            }

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