using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject
{
    public interface IProducerDAO
    {
        public ICollection<Producer> GetAll();
        public void Create(Producer Producer);
        public void Update(Producer Producer);
        public void Delete(Producer Producer);
        public Producer Get(int id);
    }

    public class ProducerDAO : IProducerDAO
    {
        private CartoonFilm2023DbContext _context;

        public ProducerDAO(CartoonFilm2023DbContext context)
        {
            _context = context;
        }

        public ICollection<Producer> GetAll()
        {
            return _context.Producers.ToList();
        }
        public void Create(Producer Producer)
        {
            var tracker = _context.Producers.Add(Producer);
            _context.SaveChanges();
            tracker.State = EntityState.Detached;
        }

        public void Update(Producer Producer)
        {
            var tracker = _context.Attach(Producer);
            tracker.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Producer Producer)
        {
            _context.Remove(Producer);
            _context.SaveChanges();
        }

        public Producer Get(int id)
        {
            return _context.Producers.Where(p => p.ProducerId.Equals(id)).FirstOrDefault();
        }
    }
}
