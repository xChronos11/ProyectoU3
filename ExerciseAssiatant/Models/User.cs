using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExerciseAssiatant.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime Birthdate { get; set; }
        public bool Male { get; set; }
        [Required]
        [Display(Name = "Altura")]
        public float Height { get; set; }
        [Required]
        [Display(Name = "Peso")]
        public float Weight { get; set; }
        [Required]
        [Display(Name="Indice de masa corporal")]
        public float BMI { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}