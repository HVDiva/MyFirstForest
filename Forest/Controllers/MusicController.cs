using Forest.Data;
using Forest.Services.IService;
using Forest.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forest.Controllers
{
    public class MusicController : Controller
    {
        private IMusicService _service;
        public MusicController()
        {
            _service = new MusicService();
        }
        public ActionResult GetAllMusics()
        {
            IList<Music> musiclist;
            musiclist = _service.GetAllMusics();
            return View("GetAllMusics", musiclist);
        }
        public ActionResult GetMusic(int id)
        {
            Music music;
            music = _service.GetMusic(id);
            return View("GetMusic", music);
        }
        public ActionResult GetMusics(int genreId)
        {
            IList<Music> list;
            list = _service.GetMusics(genreId);
            return View("GetMusics", list);
        }
        // GET: Music
        public ActionResult Index()
        {
            return View();
        }

        // GET: Music/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Music/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Music/Create
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

        // GET: Music/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Music/Edit/5
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

        // GET: Music/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Music/Delete/5
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
    }
}
