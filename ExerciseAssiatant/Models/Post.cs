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
        public string Title { get; set; }
        [DisplayName("Contenido")]
        [Required]
        public string Text { get; set; }
        [DisplayName("Imagen")]
        [Required]
        public string ImgUrl { get; set; }
    }
}