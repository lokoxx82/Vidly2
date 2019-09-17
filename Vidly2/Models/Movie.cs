using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Models
{
    public class Movie
    {
        public Movie()
        {
            //NumberInStock = 0;
            //ReleaseDate = DateTime.MinValue;
        }
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public GenreTypes Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }
        
    }
}