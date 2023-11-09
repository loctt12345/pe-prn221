using BussinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Repository;

namespace CartoonFilm_TranThienLoc.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly IMemberAccountRepository _memberAccountRepository;

        public IndexModel(IMemberAccountRepository memberAccountRepository)
        {
            _memberAccountRepository = memberAccountRepository;
        }


        public void OnGet(int? error)
        {
            if (error != null)
            {
                if (error == 1)
                {
                    ErrorString = "You do not have permission to do this function";
                }
                if (error == 2)
                {
                    ErrorString = "Wrong email or password";
                }
            }
        }


        [BindProperty]
        public MemberAccount Account { get; set; } = default!;
        [BindProperty]
        public string ErrorString { get; set; } = "";
        public IActionResult OnPost()
        {
            if (Account != null)
            {
                string email = Account.Email;
                string pwd = Account.Password;
                var account = _memberAccountRepository.GetAll().Where(a => a.Email == email).FirstOrDefault();
                if (account != null)
                {
                    if (account.Password == pwd)
                    {
                        HttpContext.Session.SetString("ACCOUNT", JsonConvert.SerializeObject(account));
                        return RedirectToPage("/CartoonFilmInformations/Index");
                    }
                }
            }
            return RedirectToPage("/Login/Index", new { error = 2});
        }
    }
}
