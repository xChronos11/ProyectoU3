using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseAssiatant.Models
{
    public class User
    {
        public int Id { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Male { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public float BMI { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}