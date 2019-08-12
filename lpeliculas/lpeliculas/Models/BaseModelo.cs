using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace lpeliculas.Models
{
    public class BaseModelo
    {
        public int PaginaActual { get; set; }
        public int Totalregistros { get; set; }
        public int RegistrosporPagina { get; set; }
        public RouteValueDictionary ValorqueryString { get; set; }
    }
}