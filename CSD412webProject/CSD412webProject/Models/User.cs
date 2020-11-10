using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD412webProject.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth => DateOfBirth.Date;
        public string Role { get; set; }

        public User()
        {
            this.Name = "Default";
            this.LastName = "Default";
            this.Email = "Default";
            this.Role = "Default";
        }
    }
}
