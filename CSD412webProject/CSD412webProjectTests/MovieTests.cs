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
        [Theory]
        [InlineData("MyMovie", "MyMovie")]
        [InlineData("SuperMovie", "SuperMovie")]
        [InlineData("Best movie ever", "Best movie ever")]
        public void TestMovieTheoryName(string title,  string expected)
        {
           
            Movie movie  = new Movie(543,
            1313,
             title,
             2001,
            false,
            "sdfgjlfsjdgldfsjgjdfsl;gj;lsfdjg",
            "http//ajsdghfskjghkljfaghkjfdhsakl.jpg",
           "http//ajsdghfskjghkljfaghkjfdsdfgsdfgfdsgsdfhsakl.jpg",
            9,
             "https//ajsdghfskjghkljfaghkjfdsdfgsdfgfdsgsdfhsakl.jpg",
           null);

            Assert.True( movie.Title== expected);
        }
    }
}
