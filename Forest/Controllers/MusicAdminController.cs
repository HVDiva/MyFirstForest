using Forest.Data;
using Forest.Services.IService;
using Forest.Services.Service;
using System.Web.Mvc;

namespace Forest.Controllers
{
    public class MusicAdminController : Controller
    {
        private IMusicService _musicService;
        private IArtistService _artistService;
        private IGenreService _genreService;
        private IUserService _userService;
        public MusicAdminController()
        {
            _musicService = new MusicService();
            _artistService = new ArtistService();
            _genreService = new GenreService();
            _userService = new UserService();
        }
        [HttpGet]

        public ActionResult UpdateMusic(int id)
        {
            Music music = _musicService.GetMusic(id);
            ViewBag.Artist_ID = new SelectList(_artistService.GetArtists(), "ID", "Name", music.Artist_ID);
            ViewBag.Genre_ID = new SelectList(_genreService.GetGenres(), "ID", "Name", music.Genre_ID);
            ViewBag.User_ID = new SelectList(_userService.GetUsers(), "ID", "Name", music.User_ID);
            return View(music);
        }
        [HttpPost]
        public ActionResult UpdateMusic(int id, Music music)
        {
                //call the appropriate method of the service object, passing music object
                _musicService.UpdateMusic(music);
                //return a RedirectToAction
                //redirect to GetMusic action in MusicController, passing ID of music object
                return RedirectToAction("GetMusic", "Music", new { id = music.ID, Controller = "MusicController" });

            
        }
        // GET: MusicAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: MusicAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusicAdmin/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddMusic()
        {
            ViewBag.Artist_ID = new SelectList(_artistService.GetArtists(), "ID", "Name");
            ViewBag.Genre_ID = new SelectList(_genreService.GetGenres(), "ID", "Name");
            ViewBag.User_ID = new SelectList(_userService.GetUsers(), "ID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult AddMusic(Music music)
        {
            //call the appropriate method of the service object, passing music object
            _musicService.AddMusic(music);
            //return a RedirectToAction
            //redirect to GetMusic action in MusicController, passing ID of music object
            return RedirectToAction("GetMusic", "Music", new { id = music.ID, Controller = "MusicController" });
        }

        // POST: MusicAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MusicAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MusicAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MusicAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MusicAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult DeleteMusic(int id)
        {
            return View(_musicService.GetMusic(id));
        }
        [HttpPost]
        public ActionResult DeleteMusic(int id, Music music)
        {
            Music _music = _musicService.GetMusic(id);
            //call the appropriate method of the service object, passing music object
            _musicService.DeleteMusic(_music);
            //return a RedirectToAction
            //redirect to GetMusic action in MusicController, passing ID of music object
            return RedirectToAction("GetAllMusics", "Music", new { id = music.ID, Controller = "MusicController" });
        }
    }
}
