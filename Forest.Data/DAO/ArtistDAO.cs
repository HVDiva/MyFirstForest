using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest.Data.IDAO;

namespace Forest.Data.DAO
{
    public class ArtistDAO : IArtistDAO
    {
        private ForestContext _context;
        public ArtistDAO()
        {
            _context = new ForestContext();
        }
        public IList<Artist> GetArtists()
        {
            return _context.Artist.ToList();
        }
    }
}
