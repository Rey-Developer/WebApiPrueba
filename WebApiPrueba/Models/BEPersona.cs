using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApiPrueba.Models
{
    public class BEPersona
    {
        [Key]
        [Required]
        public int idPersona { get; set; }
        [Required]
        public string codigo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string nombre { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string apellidos { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string correo { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string cargo { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string nombreEmpresa { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string pais { get; set; }
    }
}
