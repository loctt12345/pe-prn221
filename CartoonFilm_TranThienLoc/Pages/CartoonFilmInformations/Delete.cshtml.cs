using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using Repository;

namespace CartoonFilm_TranThienLoc.Pages.CartoonFilmInformations
{
    public class DeleteModel : PageModel
    {
        private readonly ICartoonFilmInformationRepository _cartoonFilmInformationRepository;

        public DeleteModel(ICartoonFilmInformationRepository cartoonFilmInformationRepository)
        {
            _cartoonFilmInformationRepository = cartoonFilmInformationRepository;
        }

        [BindProperty]
        public CartoonFilmInformation CartoonFilmInformation { get; set; } = default!;

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null || _cartoonFilmInformationRepository.GetAll() == null)
            {
                return NotFound();
            }

            var cartoonfilminformation = _cartoonFilmInformationRepository.Get((int)id);

            if (cartoonfilminformation == null)
            {
                return NotFound();
            }
            else
            {
                CartoonFilmInformation = cartoonfilminformation;
            }
            return Page();
        }

        public IActionResult OnPostAsync(int? id)
        {
            if (id == null || _cartoonFilmInformationRepository.GetAll() == null)
            {
                return NotFound();
            }
            var cartoonfilminformation = _cartoonFilmInformationRepository.Get((int)id);

            if (cartoonfilminformation != null)
            {
                CartoonFilmInformation = cartoonfilminformation;
                _cartoonFilmInformationRepository.Delete(CartoonFilmInformation);
            }

            return RedirectToPage("./Index");
        }
    }
}
