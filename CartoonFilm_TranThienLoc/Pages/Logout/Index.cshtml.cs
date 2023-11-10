using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CartoonFilm_TranThienLoc.Pages.Logout
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("ACCOUNT");
            return RedirectToPage("/Login/Index");
        }
    }
}
