using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lpeliculas.Models
{
    public class IndexViewModel:BaseModelo
    {
        public List<pelicula> peliculas { get; set; }
    }
}