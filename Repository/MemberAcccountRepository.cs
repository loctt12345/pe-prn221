using BussinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMemberAccountRepository
    {
        public ICollection<MemberAccount> GetAll();
        public void Create(MemberAccount Customer);
        public void Update(MemberAccount Customer);
        public void Delete(MemberAccount Customer);
        public MemberAccount Get(int id);
    }
    public class MemberAccountRepository : IMemberAccountRepository
    {
        private IMemberAccountDAO MemberAccountDAO;

        public MemberAccountRepository(IMemberAccountDAO cartoonFilmInformationDAO)
        {
            MemberAccountDAO = cartoonFilmInformationDAO;
        }

        public ICollection<MemberAccount> GetAll()
        {
            return MemberAccountDAO.GetAll();
        }

        public void Create(MemberAccount MemberAccount)
        {
            MemberAccountDAO.Create(MemberAccount);
        }

        public void Update(MemberAccount MemberAccount)
        {
            MemberAccountDAO.Update(MemberAccount);
        }

        public void Delete(MemberAccount MemberAccount)
        {
            MemberAccountDAO.Delete(MemberAccount);
        }

        public MemberAccount Get(int id)
        {
            return MemberAccountDAO.Get(id);
        }
    }
}
