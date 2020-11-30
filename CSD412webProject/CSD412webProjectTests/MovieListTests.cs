using CSD412webProject.Models;
using System;
using Xunit;

namespace CSD412webProjectTests
{
    public class MovieListTests
    {
        [Fact]
        public void DefaultName()
        {
            MovieList movieLname = new MovieList();
            Assert.True(movieLname.MovieListName == "Default");
        }

        [Fact]
        public void CheckBool()
        {
            MovieList movieLboolean = new MovieList();
            Assert.True(movieLboolean.IsPublic == false);
        }

        [Fact]
        public void CheckTypes()
        {
            MovieList mLType = new MovieList();
            Assert.IsType<String>(mLType.MovieListName);
        }
    }
}
