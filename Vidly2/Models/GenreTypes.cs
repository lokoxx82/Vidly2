﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class GenreTypes
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}