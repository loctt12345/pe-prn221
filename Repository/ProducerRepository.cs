using BussinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProducerRepository
    {
        public ICollection<Producer> GetAll();
        public void Create(Producer Customer);
        public void Update(Producer Customer);
        public void Delete(Producer Customer);
        public Producer Get(int id);
    }
    public class ProducerRepository : IProducerRepository
    {
        private IProducerDAO ProducerDAO;

        public ProducerRepository(IProducerDAO cartoonFilmInformationDAO)
        {
            ProducerDAO = cartoonFilmInformationDAO;
        }

        public ICollection<Producer> GetAll()
        {
            return ProducerDAO.GetAll();
        }

        public void Create(Producer Producer)
        {
            ProducerDAO.Create(Producer);
        }

        public void Update(Producer Producer)
        {
            ProducerDAO.Update(Producer);
        }

        public void Delete(Producer Producer)
        {
            ProducerDAO.Delete(Producer);
        }

        public Producer Get(int id)
        {
            return ProducerDAO.Get(id);
        }
    }
}
