using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExerciseAssiatant.Models
{
    public class Post
    {
        public int Id { get; set; }
        [DisplayName("Titulo")]
        [Required]
        public string title { get; set; }
        [DisplayName("Contenido")]
        [Required]
        public string text { get; set; }
        [DisplayName("Imagen")]
        [Required]
        public string imgUrl { get; set; }
    }
}