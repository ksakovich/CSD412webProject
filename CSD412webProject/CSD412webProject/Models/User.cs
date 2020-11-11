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
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Roles UserRole { get; set; }


        public User(string name, string lastname, string email, bool admin)
        {
            this.Id = IdCounter++;
            this.Name = name;
            this.LastName = lastname;
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
    }
}
