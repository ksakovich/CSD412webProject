using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;



namespace CSD412webProject.Models
{
    public class User
    {
        public enum Roles
        {
            Admin,
            Customer,
        };

        private static int IdCounter = 0;
        [Key] public int Id { get; }
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Roles UserRole { get; set; }
        public List<int> MovieListsIds { get; }
        public List<int> FriendsIds { get; }


        public User(string name, string lastname, string username,string email, bool admin)
        {
            this.Id = IdCounter++;
            this.Name = name;
            this.LastName = lastname;
            Username = username;
            this.Email = email;
            if (admin) 
            {
                UserRole = Roles.Admin;
            }
            else
            {
                UserRole = Roles.Customer;
            }
        }

        public void AddFriendId(int friendId)
        {
            if (FriendsIds.Contains(friendId))
            {
                throw new Exception("This friend ID is already in the list");
            }
            if (friendId < 0)
            {
                throw new Exception("Friend's ID cannot be negative");
            }
            else
            {
                FriendsIds.Add(friendId);
            }
        }

        public void RemoveFriendId(int friendId)
        {
            if (!FriendsIds.Contains(friendId))
            {
                throw new Exception("Friend with this ID was not found");
            }
            else
            {
                FriendsIds.Remove(friendId);
            }
        }

        public void AddMovieListId(int movieListId)
        {
            if (MovieListsIds.Contains(movieListId))
            {
                throw new Exception("This movie list ID is already in the list");
            }
            if (movieListId < 0)
            {
                throw new Exception("Movie list's ID cannot be negative");
            }
            else
            {
                MovieListsIds.Add(movieListId);
            }
        }

        public void RemoveMovieListId(int movieListId)
        {
            if (!MovieListsIds.Contains(movieListId))
            {
                throw new Exception("Movie list with this ID was not found");
            }
            else
            {
                MovieListsIds.Remove(movieListId);
            }
        }
    }
}
