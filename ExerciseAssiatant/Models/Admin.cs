using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseAssiatant.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}