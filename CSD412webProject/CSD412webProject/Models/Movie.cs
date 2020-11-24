using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD412webProject.Models
{
    public class Movie
    {
        [Key] public int Id { get; set; }
        public int MovieListId { get; set; }
        public string Title { get; set;  }
        public int ReleaseYear { get; set; }
        public bool Adult { get; set; }
        public string Description { get; set; }
        public string PosterPath { get; set; }
        public string BackDropPath { get; set; }
        public float Rating { get; set; }
        public string VideoLink { get; set; }
        public string Director { get; set; }

        public List<int> GenreIds { get; set; }
        public List<int> ActorsIds { get; set; }
        public List<string> GenreNames { get; set; }

        public Movie()
        {
            this.Id = 0;
            this.MovieListId = 0;
            this.Title = "Default";
            this.ReleaseYear = -1;
            this.Adult = false;
            this.Description = "Default";
            this.PosterPath = "Default"; 
            this.BackDropPath = "Default";
            this.Rating = -1;
            this.VideoLink = "Default";
            this.GenreIds = new List<int>();
            this.ActorsIds = new List<int>();
            this.GenreNames = new List<string>();
        }

        public Movie(
            int id,
            int listId,
            string title,
            int year,
            bool adult,
            string description,
            string poster,
            string backdrop,
            float rating,
            string link,
            List<int> ids
            )
        {
            if(id <= 0)
            {
                throw new Exception("ERROR: Illegal ID");
            }
            this.Id = id;
            this.MovieListId = listId;
            this.Title = title;
            if(year < -1 || year > DateTime.Now.AddYears(5).Year)
            {
                throw new Exception($"Illegal movie year = {year}");
            }
            else
            {
                this.ReleaseYear = year;
            }

            if(adult)
            {
                this.Adult = true;
            }
            else
            {
                Adult = false;
            }
            this.Description = description;
            this.PosterPath = poster;
            this.BackDropPath = backdrop;
            this.Rating = rating;
            this.VideoLink = link;
            this.Director = null;
            this.GenreIds = ids;
            this.ActorsIds = new List<int>();
        }
        public void AddGenreId(int genreId)
        {
            if(GenreIds.Contains(genreId))
            {
                throw new Exception("This genre ID is already in the list");
            }
            if( genreId < 0)
            {
                throw new Exception("Genre ID cannot be negative");
            }
            else
            {
                GenreIds.Add(genreId);
            }
        }

        public void RemoveGenreId(int genreId)
        {
            if (!GenreIds.Contains(genreId))
            {
                throw new Exception("Genre ID was not found");
            }
            else
            {
                GenreIds.Remove(genreId);
            }
        }

        public void AddActorId(int actorId)
        {
            if (ActorsIds.Contains(actorId))
            {
                throw new Exception("This actor ID is already in the list");
            }
            if (actorId < 0)
            {
                throw new Exception("Actor's ID cannot be negative");
            }
            else
            {
                GenreIds.Add(actorId);
            }
        }
        public void RemoveActorId(int actorId)
        {
            if (!GenreIds.Contains(actorId))
            {
                throw new Exception("Actor with this ID was not found");
            }
            else
            {
                GenreIds.Remove(actorId);
            }
        }

        public void AddGenreName(string genreName)
        {
            if (GenreNames.Contains(genreName))
            {
                throw new Exception("This genre name is already in the list");
            }
            if (genreName == null)
            {
                throw new Exception("Genre name cannot be null");
            }
            else
            {
                GenreNames.Add(genreName);
            }
        }

        public void AssignGenreList(List<string> genres)
        {
            this.GenreNames = genres;
        }
    }
}
