using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CSD412webProject.Models;
using CSD412webProject.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            List<Genre> genres = new List<Genre>();
            var jsonGenres = Searcher.SearchForGenres();
            if (jsonGenres.Result == null || jsonGenres == null)
            {
                throw new Exception("Genres are empty");
            }
            dynamic genresArray = JsonConvert.DeserializeObject(jsonGenres.Result);
            var genresResults = genresArray.GetValue("genres");

            foreach (var genre in genresResults)
            {
                var rawGenreId = genre.GetValue("id");
                int genreId = (int)rawGenreId;
                var rawGenreName = genre.GetValue("name");
                string genreName = (string)rawGenreName;
                Genre tempGenre = new Genre(genreId, genreName);
                genres.Add(tempGenre);
                
            }
            return View(genres);
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
