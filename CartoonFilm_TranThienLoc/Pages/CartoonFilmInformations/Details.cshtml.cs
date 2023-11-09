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
    public class DetailsModel : PageModel
    {
        private readonly ICartoonFilmInformationRepository _cartoonFilmInformationRepository;

        public DetailsModel(ICartoonFilmInformationRepository cartoonFilmInformationRepository)
        {
            _cartoonFilmInformationRepository = cartoonFilmInformationRepository;
        }

      public CartoonFilmInformation CartoonFilmInformation { get; set; } = default!; 

        public IActionResult OnGet(int? id)
        {
            if (id == null || _cartoonFilmInformationRepository.GetAll() == null)
            {
                return NotFound();
            }

            var cartoonfilminformation = _cartoonFilmInformationRepository.Get((int) id);
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
    }
}
