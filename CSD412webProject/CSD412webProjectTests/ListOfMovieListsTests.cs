using CSD412webProject.Models;
using System;
using Xunit;

namespace CSD412webProjectTests
{
    public class ListOfMovieListsTests
    {
        [Fact]
        public void DefaultUser()
        {
            ListOfMovieLists user = new ListOfMovieLists();
            Assert.True(user.User == null);
        }

        [Fact]
        public void CheckType()
        {
            ListOfMovieLists mList = new ListOfMovieLists();
            Assert.IsType<int>(mList.Id);
        }

        [Fact]
        public void Checklists()
        {
            ListOfMovieLists moList = new ListOfMovieLists(new User());
            Assert.NotNull(moList.MovieLists);
        }
    }
}
