using Forest.Data;
using Forest.Data.DAO;
using Forest.Data.IDAO;
using Forest.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.Service
{
    public class ArtistService : IArtistService
    {
        private IArtistDAO _dao;
        public ArtistService()
        {
            _dao = new ArtistDAO();
        }
        public IList<Artist> GetArtists()
        {
            return _dao.GetArtists();
        }
    }
}
