﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseAssiatant.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleName { get; set; }
    }
}