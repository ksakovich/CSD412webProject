﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSD412webProject.Data;
using CSD412webProject.Models;
using Newtonsoft.Json;

namespace CSD412webProject.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieListId,Adult,Description,PosterPath,BackDropPath,Rating,VideoLink,Director")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieListId,Adult,Description,PosterPath,BackDropPath,Rating,VideoLink,Director")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult MovieSearchResults(string userInput)
        {
            if (userInput == null || userInput == "")
            {
                throw new Exception("Cannot process null or empty sting request");
            }
            string movieTitle = userInput;
            List<Movie> tempMovieList = new List<Movie>();
            var json = Searcher.SearchMovieByTitle(movieTitle);
            dynamic array = JsonConvert.DeserializeObject(json.Result);
            var results = array.GetValue("results");
            foreach (var movieTemplate in results)
            {
                var obj = movieTemplate;
                string postePath = obj.GetValue("poster_path");
                if (string.IsNullOrEmpty(postePath))
                {
                    continue;
                }
                int id = obj.GetValue("id");
                string title = obj.GetValue("title");
                
                string backDropPath = obj.GetValue("backdrop_path");
                float rating = obj.GetValue("vote_average");
                string description = obj.GetValue("overview");
                bool adult = obj.GetValue("adult");
                var ids = obj.GetValue("genre_ids");
                int[] genreIds = new int[ids.Count];
                int counter = 0;
                foreach (var num in ids)
                {
                    genreIds[counter] = num;
                    counter++;
                }

                string date = obj.GetValue("release_date");

                int releaseYear = -1;
                if (date != null && date.Length >=5)
                {
                    string year = date.Substring(0, 4);
                    releaseYear = Int32.Parse(year);
                }

                List<int> genres = genreIds.OfType<int>().ToList();

                Movie tmpMovie = new Movie(id, -1, title, releaseYear, adult, description, postePath, backDropPath, rating, null, genres);
                tempMovieList.Add(tmpMovie);
            }

            foreach (Movie movie in tempMovieList)
            {
                
                var jsonFIle = Searcher.SearchMovieById(movie.Id);
                
                if(jsonFIle.Result == null || jsonFIle == null)
                {
                    continue;
                }
                dynamic dynamicArray = JsonConvert.DeserializeObject(jsonFIle.Result);
                var videoResults = dynamicArray.GetValue("results");
                if (videoResults.Count >= 1)
                {
                    var firstVideoObject = videoResults[0];
                    string videoLink = firstVideoObject.GetValue("key");
                    movie.VideoLink = videoLink;
                }
                else
                {
                    continue;
                }
            }
            return View(tempMovieList);
        }

        public IActionResult MovieInfo(Movie movie)
        {
            return View(movie);
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
