using Forest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.IService
{
    public interface IArtistService
    {
        IList<Artist> GetArtists();
    }
}
