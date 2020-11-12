using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD412webProject.Models
{
    public class Movie
    {
        [Key] public int Id { get; }
        public string Title { get; }
        public int ReleaseYear { get; }
        public Boolean Adult { get; set; }
        public string Description { get; set; }
        public string PosterPath { get; set; }
        public string BackDropPath { get; set; }
        public float Rating { get; set; }
        public string VideoLink { get; set; }
        public List<int> GenreIds { get; }
        public List<int> ActorsIds { get; }

        public Movie(
            int id,
            string title,
            int year,
            bool adult,
            string description,
            string poster,
            string backdrop,
            float rating,
            string link)
        {
            if(id <= 0)
            {
                throw new Exception("ERROR: Illegal ID");
            }
            Id = id;
            Title = title;
            if(year < 1888 || year > DateTime.Now.Year)
            {
                throw new Exception("Illegal movie year");
            }
            else
            {
                ReleaseYear = year;
            }

            if(adult)
            {
                Adult = true;
            }
            else
            {
                Adult = false;
            }
            Description = description;
            PosterPath = poster;
            BackDropPath = backdrop;
            Rating = rating;
            VideoLink = link;
            GenreIds = new List<int>();
            ActorsIds = new List<int>();
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
    }
}
