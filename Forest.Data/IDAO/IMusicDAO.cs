using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Data.IDAO
{
    public interface IMusicDAO
    {
        IList<Music> GetMusics(int genreId);
        Music GetMusic(int id);
        IList<Music> GetAllMusics();
        void UpdateMusic(Music music);
        void AddMusic(Music music);
        void DeleteMusic(Music music);
    }
}
