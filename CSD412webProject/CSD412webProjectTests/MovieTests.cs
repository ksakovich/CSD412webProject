using CSD412webProject.Models;
using System;
using Xunit;

namespace CSD412webProjectTests
{
    public class MovieTests
    {
        [Fact]
        public void DefaultTitle()
        {
            Movie movie = new Movie();
            Assert.True(movie.Title == "Default");
        }

        [Fact]
        public void BooleanAdult()
        {
            Movie adult = new Movie();
            Assert.True(adult.Adult == false);
        }

        [Fact]
        public void IntYear()
        {
            Movie year = new Movie();
            Assert.True(year.ReleaseYear == -1);
        }
    }
}
