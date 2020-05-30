using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExerciseAssiatant.Models
{
    public class UserExercise
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Date { get; set; }
    }
}