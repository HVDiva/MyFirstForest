using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest.Data.IDAO;

namespace Forest.Data.DAO
{
    public class GenreDAO : IGenreDAO
    {
        private ForestContext _context;
        public GenreDAO()
        {
            _context = new ForestContext();
        }
        public IList<Genre> GetGenres()
        {
            return _context.Genre.ToList();
        }
        public Genre GetGenre(int id)
        {
            return _context.Genre.Find(id);
        }

        

    }
}
