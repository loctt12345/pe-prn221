using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Models;
using Repository;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace CartoonFilm_TranThienLoc.Pages.CartoonFilmInformations
{
    public class CreateModel : PageModel
    {
        private readonly ICartoonFilmInformationRepository _cartoonFilmInformationRepository;
        private readonly IProducerRepository _producerRepository;


        public CreateModel(ICartoonFilmInformationRepository cartoonFilmInformationRepository, IProducerRepository producerRepository)
        {
            _cartoonFilmInformationRepository = cartoonFilmInformationRepository;
            _producerRepository = producerRepository;
        }

        public IActionResult OnGet(int? error)
        {
            ViewData["ProducerId"] = new SelectList(_producerRepository.GetAll(), "ProducerId", "ProducerName");
            //if (error != null)
            //{
            //    if (error == 1)
            //    {
            //        ErrorString = "Id is existed!!!";
            //    }
            //    if (error == 2)
            //    {
            //        ErrorString = "Each word of name must begin with the capital letter";
            //    }
            //}
            return Page();
        }

        [BindProperty]
        public CartoonFilmInformation CartoonFilmInformation { get; set; } = default!;
        public string ErrorString { get; set; } = "";


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            var item = _cartoonFilmInformationRepository.Get(CartoonFilmInformation.CartoonFilmId);
            if (item != null)
            {
                ModelState.AddModelError("CartoonFilmInformation.CartoonFilmId", "Id is existed!!!");
                //return RedirectToPage("./Create", new { error = 1 });
            }

            string name = CartoonFilmInformation.CartoonFilmName;
            string[] words = name.Split(' ');
            for (int i = 0; i < words.Length; ++i)
            {
                if (!Char.IsLetter(words[i][0]) || Char.IsLower(words[i][0]))
                {
                    ModelState.AddModelError("CartoonFilmInformation.CartoonFilmName", "Each word of name must begin with the capital letter");
                    //return RedirectToPage("./Create", new { error = 2 });
                }
            }

            if (!ModelState.IsValid || _cartoonFilmInformationRepository.GetAll() == null || CartoonFilmInformation == null)
            {
                return Page();
            }

            CartoonFilmInformation.CreatedDate = DateTime.Now;
            _cartoonFilmInformationRepository.Create(CartoonFilmInformation);

            return RedirectToPage("./Index");
        }
    }
}
