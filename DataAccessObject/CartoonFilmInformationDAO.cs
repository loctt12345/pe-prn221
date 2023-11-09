using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject
{
    public interface ICartoonFilmInformationDAO
    {
        public ICollection<CartoonFilmInformation> GetAll();
        public void Create(CartoonFilmInformation CartoonFilmInformation);
        public void Update(CartoonFilmInformation CartoonFilmInformation);
        public void Delete(CartoonFilmInformation CartoonFilmInformation);
        public CartoonFilmInformation Get(int id);
    }

    public class CartoonFilmInformationDAO : ICartoonFilmInformationDAO
    {
        private CartoonFilm2023DbContext _context;

        public CartoonFilmInformationDAO(CartoonFilm2023DbContext context)
        {
            _context = context;
        }

        public ICollection<CartoonFilmInformation> GetAll()
        {
            return _context.CartoonFilmInformations.Include(c => c.Producer).ToList();
        }
        public void Create(CartoonFilmInformation CartoonFilmInformation)
        {
            var tracker = _context.CartoonFilmInformations.Add(CartoonFilmInformation);
            _context.SaveChanges();
            tracker.State = EntityState.Detached;
        }

        public void Update(CartoonFilmInformation CartoonFilmInformation)
        {
            var tracker = _context.Attach(CartoonFilmInformation);
            tracker.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(CartoonFilmInformation CartoonFilmInformation)
        {
            _context.Remove(CartoonFilmInformation);
            _context.SaveChanges();
        }

        public CartoonFilmInformation Get(int id)
        {
            return _context.CartoonFilmInformations.Where(p => p.CartoonFilmId.Equals(id)).FirstOrDefault();
        }
    }
}
