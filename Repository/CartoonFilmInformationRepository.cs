using BussinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICartoonFilmInformationRepository
    {
        public ICollection<CartoonFilmInformation> GetAll();
        public void Create(CartoonFilmInformation Customer);
        public void Update(CartoonFilmInformation Customer);
        public void Delete(CartoonFilmInformation Customer);
        public CartoonFilmInformation Get(int id);
    }
    public class CartoonFilmInformationRepository : ICartoonFilmInformationRepository
    {
        private ICartoonFilmInformationDAO CartoonFilmInformationDAO;

        public CartoonFilmInformationRepository(ICartoonFilmInformationDAO cartoonFilmInformationDAO)
        {
            CartoonFilmInformationDAO = cartoonFilmInformationDAO;
        }

        public ICollection<CartoonFilmInformation> GetAll()
        {
            return CartoonFilmInformationDAO.GetAll();
        }

        public void Create(CartoonFilmInformation CartoonFilmInformation)
        {
            CartoonFilmInformationDAO.Create(CartoonFilmInformation);
        }

        public void Update(CartoonFilmInformation CartoonFilmInformation)
        {
            CartoonFilmInformationDAO.Update(CartoonFilmInformation);
        }

        public void Delete(CartoonFilmInformation CartoonFilmInformation)
        {
            CartoonFilmInformationDAO.Delete(CartoonFilmInformation);
        }

        public CartoonFilmInformation Get(int id)
        {
            return CartoonFilmInformationDAO.Get(id);
        }
    }
}
