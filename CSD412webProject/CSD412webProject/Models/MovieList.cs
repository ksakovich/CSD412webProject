using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD412webProject.Models
{
    public class MovieList
    {
        private static int IdCounter = 1;
        public int MovieListId { get; }
        public int UserId { get; }
        public string MovieListName { get; set; }
        public string MovieListLink { get; set; }
        public bool IsPublic { get; set; }

        public MovieList(int userId, string name, bool isPublic)
        {
            MovieListId = IdCounter++;
            MovieListName = name;
            IsPublic = isPublic;
            MovieListLink = null;
        }
    }
}
