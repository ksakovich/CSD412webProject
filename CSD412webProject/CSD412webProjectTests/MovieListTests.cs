using CSD412webProject.Models;
using System;
using Xunit;

namespace CSD412webProjectTests
{
    public class MovieListTests
    {
        [Fact]
        public void DefaultNameINull()
        {
            MovieList movieLname = new MovieList();
            Assert.True(movieLname.MovieListName == null);
        }

        [Fact]
        public void CheckBool()
        {
            MovieList movieLboolean = new MovieList();
            Assert.True(movieLboolean.IsPublic == false);
        }

        [Fact]
        public void CustomName()
        {
            MovieList ml = new MovieList(new ListOfMovieLists() , "Horror", false);
            Assert.True(ml.MovieListName == "Horror");
        }

        [Theory]
        [InlineData("Horror", "Horror")]
        [InlineData("Aventure", "Aventure")]
        [InlineData("Anime", "Anime")]
        public void TestListOfMovieLisTheoryName(string title, string expected)
        {
            MovieList ml = new MovieList(new ListOfMovieLists(), title, false);

            Assert.True(ml.MovieListName == expected);
        }
    }
}
