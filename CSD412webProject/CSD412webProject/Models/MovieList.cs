using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD412webProject.Models
{
    public class MovieList
    {
        private static int _idCounter = 1;
        [Key] public int MovieListId { get; set; }
        public int UserId { get; }
        public string MovieListName { get; set; }
        public string MovieListLink { get; set; }
        public bool IsPublic { get; set; }
        public List<int> MovieIds { get; }

        public MovieList()
        {
            MovieListId = _idCounter++;
            MovieListName = "Default";
            IsPublic = false;
            MovieListLink = "Default";
            MovieIds = new List<int>();
        }

        public MovieList(int userId, string name, bool isPublic)
        {
            MovieListId = _idCounter++;
            MovieListName = name;
            IsPublic = isPublic;
            MovieListLink = null;
            MovieIds = new List<int>();
        }

        public void AddMovieId(int movieId)
        {
            if (MovieIds.Contains(movieId))
            {
                throw new Exception("This movie ID is already in the list");
            }
            if (movieId < 0)
            {
                throw new Exception("movie's ID cannot be negative");
            }
            else
            {
                MovieIds.Add(movieId);
            }
        }

        public void RemoveMovieId(int movieId)
        {
            if (!MovieIds.Contains(movieId))
            {
                throw new Exception("Movie with this ID was not found");
            }
            else
            {
                MovieIds.Remove(movieId);
            }
        }
    }
}
