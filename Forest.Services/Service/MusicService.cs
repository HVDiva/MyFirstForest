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
    public class MusicService : IMusicService
    {
        private IMusicDAO _dao;
        public MusicService()
        {
            _dao = new MusicDAO();
        }
        public IList<Music> GetMusics(int genreId)
        {
            return _dao.GetMusics(genreId);
        }
        public Music GetMusic(int id)
        {
            return _dao.GetMusic(id);
        }
        public IList<Music> GetAllMusics()
        {
            IList<Music> musiclist = _dao.GetAllMusics();
            return musiclist;
        }
        public void UpdateMusic(Music music)
        {
            _dao.UpdateMusic(music);
        }
        public void AddMusic(Music music)
        {
            _dao.AddMusic(music);
        }
        public void DeleteMusic(Music music)
        {
            _dao.DeleteMusic(music);
        }
    }
}
