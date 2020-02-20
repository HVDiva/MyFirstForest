using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest.Data;
using Forest.Data.DAO;
using Forest.Data.IDAO;
using Forest.Services.IService;

namespace Forest.Services.Service
{
    public class GenreService : IGenreService
    {
        private IGenreDAO _dao;
        public GenreService()
        {
            _dao = new GenreDAO();
        }
        public IList<Genre> GetGenres()
        {
            return _dao.GetGenres();
        }
        public Genre GetGenre(int id)
        {
            return _dao.GetGenre(id);
        }
    }
}
