using BussinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CartoonFilm_TranThienLoc.Pages.CartoonFilmInformations
{
    public class EditModel : PageModel
    {
        private readonly ICartoonFilmInformationRepository _cartoonFilmInformationRepository;
        private readonly IProducerRepository _producerRepository;

        public EditModel(ICartoonFilmInformationRepository cartoonFilmInformationRepository, IProducerRepository producerRepository)
        {
            _cartoonFilmInformationRepository = cartoonFilmInformationRepository;
            _producerRepository = producerRepository;
        }

        [BindProperty]
        public CartoonFilmInformation CartoonFilmInformation { get; set; } = default!;
        public string ErrorString { get; set; } = "";


        public IActionResult OnGet(int? id, int? error)
        {
            if (id == null || _cartoonFilmInformationRepository.GetAll() == null)
            {
                return NotFound();
            }
            if (error != null)
            {
                if (error == 1)
                {
                    ErrorString = "Id is existed!!!";
                }
                if (error == 2)
                {
                    ErrorString = "Each word of name must begin with the capital letter";
                }
            }

            var cartoonfilminformation = _cartoonFilmInformationRepository.Get((int) id);
            if (cartoonfilminformation == null)
            {
                return NotFound();
            }
            CartoonFilmInformation = cartoonfilminformation;
           ViewData["ProducerId"] = new SelectList(_producerRepository.GetAll(), "ProducerId", "ProducerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _cartoonFilmInformationRepository.Update(CartoonFilmInformation);
                string name = CartoonFilmInformation.CartoonFilmName;
                string[] words = name.Split(' ');
                for (int i = 0; i < words.Length; ++i)
                {
                    if (!Char.IsLetter(words[i][0]) || Char.IsLower(words[i][0]))
                    {
                        return RedirectToPage("./Edit", new { error = 2 });
                    }
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartoonFilmInformationExists(CartoonFilmInformation.CartoonFilmId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CartoonFilmInformationExists(int id)
        {
          return (_cartoonFilmInformationRepository.GetAll()?.Any(e => e.CartoonFilmId == id)).GetValueOrDefault();
        }
    }
}
