using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD412webProject.Models
{
    public class Genre
    {
        [Key] public int Id { get; set; }
        public string Name { get; set;  }
        public Genre()
        {
            this.Id = 0;
            this.Name = "Default";
        }
        public Genre(int id, string name)
        {
            if (id <= 0)
            {
                throw new Exception($"Illegal movie Genre ID = {id}");
            }
            this.Id = id;
            this.Name = name;
        }
    }
}


