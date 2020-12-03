using CSD412webProject.Models;
using System;
using Xunit;

namespace CSD412webProjectTests
{
    public class GenreTests
    {
        [Fact]
        public void DefaultName()
        {
            Genre genre = new Genre();
            Assert.True(genre.Name == "Default");
        }

        [Fact]
        public void IntID()
        {
            Genre idGenre = new Genre();
            Assert.True(idGenre.Id == 0);
        }

        [Theory]
        [InlineData("Horror", "Horror")]
        [InlineData("Aventure", "Aventure")]
        [InlineData("Anime", "Anime")]
        public void TestGenreTheoryName(string title, string expected)
        {
            Genre g = new Genre(1, title);

            Assert.True(g.Name == expected);
        }
    }
}
