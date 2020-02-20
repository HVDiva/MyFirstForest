using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forest.Data;
using Forest.Services;
using Forest.Services.Service;
using Forest.Services.IService;

namespace Forest.Controllers
{
    public abstract class ApplicationController : Controller
    {
        public IGenreService _genreService;
        public ApplicationController()
        {
            _genreService = new GenreService();
            ViewBag.genres = _genreService.GetGenres();
        }
        // GET: Application
        public ActionResult Index()
        {
            return View();
        }
    }
}