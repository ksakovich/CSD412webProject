using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSD412webProject.Models
{
    public class ListOfMovieLists
    {
        [Key] public int Id { get; set; }
        [InverseProperty("ListOfMovieLists")]
        public List<MovieList> MovieLists { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public ListOfMovieLists()
        {
            User = null;
            MovieLists = new List<MovieList>();
        }

        public ListOfMovieLists(User user)
        {
            User = user;
            UserId = user.Id;
            MovieLists = new List<MovieList>();
        }

        public void AddMovieList(MovieList ml)
        {
            if (MovieLists == null)
            {
                throw new Exception("List of MovieLists is null");
            }
            if (MovieLists.Contains(ml))
            {
                throw new Exception("User already has this list of movies in their library");
            }
            else
            {
                MovieLists.Add(ml);
            }
        }

        public void RemoveMovieList(MovieList ml)
        {
            if (MovieLists == null)
            {
                throw new Exception("List of MovieLists is null");
            }
            if (!MovieLists.Contains(ml))
            {
                throw new Exception("Movie list was not found");
            }
            else
            {
                MovieLists.Remove(ml);
            }
        }
    }
}
