using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExerciseAssiatant.Models
{
    public class UserExercise
    {
        public int Id { get; set; }
        [Display(Name = "Ejercicio")]
        public int ExerciseId { get; set; }
        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }
        [Required]
        [Display(Name="Duracion")]
        public TimeSpan Duration { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }
        public Cliente Cliente { get; set; }

       
    }
}