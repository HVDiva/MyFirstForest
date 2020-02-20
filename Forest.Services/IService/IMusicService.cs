using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest.Data;

namespace Forest.Services.IService
{
    public interface IMusicService
    {
        IList<Music> GetMusics(int genreId);
        Music GetMusic(int id);
        IList<Music> GetAllMusics();
        void UpdateMusic(Music music);
        void AddMusic(Music music);
        void DeleteMusic(Music music);
    }
}
