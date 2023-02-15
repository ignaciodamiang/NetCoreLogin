using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetCoreLogin.Pages
{
    public class DashboardModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Welcome to your dashboard!";
        }
    }
}
