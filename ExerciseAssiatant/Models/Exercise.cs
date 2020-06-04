using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExerciseAssiatant.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Nombre")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Calorias por hora")]
        public float Cal4Hour { get; set; }
    }
}