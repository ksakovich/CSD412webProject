using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSD412webProject.Models
{
    public class MovieList
    {
        [Key] public int MovieListId { get; set; }
        public string MovieListName { get; set; }
        public string MovieListLink { get; set; }
        public bool IsPublic { get; set; }
        public List<Movie> Movies { get; set; }
        [ForeignKey("ListOfMovieLists")]
        public int ListOfMovieListsId { get; set; }
        public ListOfMovieLists ListOfMovieLists { get; set; }
        public MovieList()
        {
            ListOfMovieLists = null;
            //MovieListName = "Default";
            IsPublic = false;
            //MovieListLink = "Default";
            Movies = new List<Movie>();
        }

        public MovieList(ListOfMovieLists list, string name, bool isPublic)
        {
            ListOfMovieLists = list;
            MovieListName = name;
            IsPublic = isPublic;
            MovieListLink = null;
            Movies = new List<Movie>();
            ListOfMovieListsId = list.Id;
        }

        public void AddMovie(Movie movie)
        {
            if (Movies.Contains(movie))
            {
                throw new Exception("This movie is already in the list");
            }
            else
            {
                Movies.Add(movie);
            }
        }

        public void RemoveMovie(Movie movie)
        {
            if (!Movies.Contains(movie))
            {
                throw new Exception("Movie not found");
            }
            else
            {
                Movies.Remove(movie);
            }
        }
    }
}
