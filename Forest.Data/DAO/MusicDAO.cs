using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest.Data.IDAO;

namespace Forest.Data.DAO
{
    public class MusicDAO : IMusicDAO
    {
        private ForestContext _context;
        public MusicDAO()
        {
            _context = new ForestContext();
        }
        public IList<Music> GetMusics(int genreId)
        {
            Genre genre;
            genre = _context.Genre.Find(genreId);
            return _context.Music.ToList();
        }
        public Music GetMusic(int id)
        {
            Music music = _context.Music.Find(id);
            return music;
        }
        public IList<Music> GetAllMusics()
        {
            IList<Music> musiclist = _context.Music.ToList();
            return musiclist;
        }
        public void UpdateMusic(Music music)
        {
            Music _music = GetMusic(music.ID);
            _music.Title = music.Title;
            _music.num_track = music.num_track;
            _music.duration = music.duration;
            _music.DateReleased = music.DateReleased;
            _music.Artist_ID = music.Artist_ID;
            _music.Genre_ID = music.Genre_ID;
            _music.User_ID = music.User_ID;
            _music.Artist = music.Artist;
            _music.Genre = music.Genre;
            _music.User = music.User;
            _context.SaveChanges();
        }
        public void AddMusic(Music music)
        {
            _context.Music.Add(music);
            _context.SaveChanges();
        }
        public void DeleteMusic(Music music)
        {
            _context.Music.Remove(music);
            _context.SaveChanges();
        }
    }
}


