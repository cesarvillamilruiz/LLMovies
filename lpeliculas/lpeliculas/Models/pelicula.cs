using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lpeliculas.Models
{
    public class pelicula
    {
        [Key]
        public int PeliculaId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Este campo es  requerido")]
        public string Nombre { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Este campo es  requerido")]
        public string Duracion { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Este campo es  requerido")]
        public string Genero { get; set; }


        [Required(ErrorMessage = "Este campo es  requerido")]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de estreno")]
        public DateTime FechaDeEstreno { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Este campo es  requerido")]
        public string Sinopsis { get; set; }

        [Required(ErrorMessage = "Este campo es  requerido")]
        public string Protagonista { get; set; }
    }
}