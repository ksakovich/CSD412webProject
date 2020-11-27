using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CSD412webProject.Models
{
    public class User : IdentityUser
    {
        public enum Roles
        {
            Admin,
            Customer,
        };

        [PersonalData]
        public DateTime DateOfBirth { get; set; }
        [PersonalData]
        public Roles UserRole { get; set; }
         [InverseProperty("User")]
        public ListOfMovieLists ListOfMovieLists { get; set; }
        public string Name { get; internal set; }

        public User()
        {
            this.UserRole = Roles.Customer;
        }
        public User( bool admin)
        {
            if (admin) 
            {
                UserRole = Roles.Admin;
            }
            else
            {
                UserRole = Roles.Customer;
            }
        }
    }
}
