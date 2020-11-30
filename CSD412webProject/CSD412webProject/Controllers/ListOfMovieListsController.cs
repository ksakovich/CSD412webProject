using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSD412webProject.Data;
using CSD412webProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;



namespace CSD412webProject.Controllers
{
    public class ListOfMovieListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListOfMovieListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ListOfMovieLists
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfMovieLists.Include(l => l.User).Where(l => l.UserId == User.Identity.GetUserId()).Include(l=>l.MovieLists);
            return View(await applicationDbContext.FirstAsync());
        }

        // GET: ListOfMovieLists/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMovieLists = await _context.ListOfMovieLists
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfMovieLists == null)
            {
                return NotFound();
            }

            return View(listOfMovieLists);
        }

        // GET: ListOfMovieLists/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: ListOfMovieLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId")] ListOfMovieLists listOfMovieLists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfMovieLists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", listOfMovieLists.UserId);
            return View(listOfMovieLists);
        }

        // GET: ListOfMovieLists/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMovieLists = await _context.ListOfMovieLists.FindAsync(id);
            if (listOfMovieLists == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", listOfMovieLists.UserId);
            return View(listOfMovieLists);
        }

        // POST: ListOfMovieLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId")] ListOfMovieLists listOfMovieLists)
        {
            if (id != listOfMovieLists.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfMovieLists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfMovieListsExists(listOfMovieLists.Id))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", listOfMovieLists.UserId);
            return View(listOfMovieLists);
        }

        // GET: ListOfMovieLists/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMovieLists = await _context.ListOfMovieLists
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfMovieLists == null)
            {
                return NotFound();
            }

            return View(listOfMovieLists);
        }

        // POST: ListOfMovieLists/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfMovieLists = await _context.ListOfMovieLists.FindAsync(id);
            _context.ListOfMovieLists.Remove(listOfMovieLists);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfMovieListsExists(int id)
        {
            return _context.ListOfMovieLists.Any(e => e.Id == id);
        }
    }
}
