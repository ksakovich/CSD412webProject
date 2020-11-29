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
    }
}
