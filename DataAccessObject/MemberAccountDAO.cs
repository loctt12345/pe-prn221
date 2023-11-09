using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject
{
    public interface IMemberAccountDAO
    {
        public ICollection<MemberAccount> GetAll();
        public void Create(MemberAccount MemberAccount);
        public void Update(MemberAccount MemberAccount);
        public void Delete(MemberAccount MemberAccount);
        public MemberAccount Get(int id);
    }

    public class MemberAccountDAO : IMemberAccountDAO
    {
        private CartoonFilm2023DbContext _context;

        public MemberAccountDAO(CartoonFilm2023DbContext context)
        {
            _context = context;
        }

        public ICollection<MemberAccount> GetAll()
        {
            return _context.MemberAccounts.ToList();
        }
        public void Create(MemberAccount MemberAccount)
        {
            var tracker = _context.MemberAccounts.Add(MemberAccount);
            _context.SaveChanges();
            tracker.State = EntityState.Detached;
        }

        public void Update(MemberAccount MemberAccount)
        {
            var tracker = _context.Attach(MemberAccount);
            tracker.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(MemberAccount MemberAccount)
        {
            _context.Remove(MemberAccount);
            _context.SaveChanges();
        }

        public MemberAccount Get(int id)
        {
            return _context.MemberAccounts.Where(p => p.MemberId.Equals(id)).FirstOrDefault();
        }
    }
}
