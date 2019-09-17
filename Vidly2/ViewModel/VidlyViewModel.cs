using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class VidlyViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
    public class CustomersModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
    public class MoviesModel
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}