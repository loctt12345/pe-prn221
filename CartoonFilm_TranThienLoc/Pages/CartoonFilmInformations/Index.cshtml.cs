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
    public class IndexModel : PageModel
    {
        private readonly ICartoonFilmInformationRepository _cartoonFilmInformationRepository;

        public IndexModel(ICartoonFilmInformationRepository cartoonFilmInformationRepository)
        {
            _cartoonFilmInformationRepository = cartoonFilmInformationRepository;
        }

        [BindProperty]
        public IList<CartoonFilmInformation> CartoonFilmInformation { get; set; } = default!;
        [BindProperty]
        public decimal NumPage { get; set; }

        public void OnGet(int? pageIndex, int? searchDurationValue, int? searchReleaseYearValue)
        {
            int pageSize = 3;
            if (pageIndex == null) pageIndex = 1;
            var list = _cartoonFilmInformationRepository.GetAll();
            if (searchDurationValue != null)
            {
                list = list.Where(c => c.Duration == searchDurationValue).ToList();
            }
            if (searchReleaseYearValue != null)
            {
                list = list.Where(c => c.ReleaseYear == searchReleaseYearValue).ToList();
            }
            CartoonFilmInformation = list.Skip(((int)pageIndex - 1) * pageSize).Take(pageSize).ToList();
            NumPage = Math.Ceiling((decimal) list.Count / (decimal) pageSize);
        }
    }
}
