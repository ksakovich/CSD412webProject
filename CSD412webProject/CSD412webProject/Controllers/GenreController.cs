using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CSD412webProject.Models;
using CSD412webProject.Data;
using Microsoft.EntityFrameworkCore;

namespace CSD412webProject.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GenreController
        public ActionResult Index()
        {
            Genre action = new Genre(28, "Action");
            Genre adventure = new Genre(12, "Adventure");
            Genre animation = new Genre(16, "Animation");
            Genre comedy = new Genre(35, "Comedy");
            Genre crime = new Genre(80, "Crime");
            Genre documentary = new Genre(99, "Documentary");
            Genre drama = new Genre(18, "Drama");
            Genre family = new Genre(10751, "Family");
            Genre fantasy = new Genre(14, "Fantasy");
            Genre history = new Genre(36, "History");
            Genre horror = new Genre(27, "Horror");
            Genre music = new Genre(10402, "Music");
            Genre mystery = new Genre(9648, "Mystery");
            Genre romance = new Genre(10749, "Romance");
            Genre scienceFiction = new Genre(878, "Science Fiction");
            Genre tvMovie = new Genre(10770, "TV Movie");
            Genre thriller = new Genre(53, "Thriller");
            Genre war = new Genre(10752, "War");
            Genre western = new Genre(37, "Western");
            List<Genre> Genreslist = new List<Genre>();
            Genreslist.Add(action);
            Genreslist.Add(adventure);
            Genreslist.Add(animation);
            Genreslist.Add(comedy);
            Genreslist.Add(crime);
            Genreslist.Add(documentary);
            Genreslist.Add(drama);
            Genreslist.Add(family);
            Genreslist.Add(fantasy);
            Genreslist.Add(history);
            Genreslist.Add(horror);
            Genreslist.Add(music);
            Genreslist.Add(mystery);
            Genreslist.Add(romance);
            Genreslist.Add(scienceFiction);
            Genreslist.Add(tvMovie);
            Genreslist.Add(thriller);
            Genreslist.Add(war);
            Genreslist.Add(western);
            try
            {
                _context.Database.OpenConnection();
                
            }
            finally
            {

            }
            return View();
        }

        // GET: GenreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
