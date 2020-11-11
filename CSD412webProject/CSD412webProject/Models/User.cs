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
        private static int IdCounter = 0;
        [Key] public int Id { get; }
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth => DateOfBirth.Date;
        public Enum Role { get; set; }


        public User()
        {
            this.Id = IdCounter++;
            this.Name = "Default";
            this.LastName = "Default";
            this.Email = "default@email.com";

        }



    }
}
