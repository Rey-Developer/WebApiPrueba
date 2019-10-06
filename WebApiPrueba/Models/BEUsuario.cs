using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApiPrueba.Models
{
    public class BEUsuario
    {
        public int Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public string Credencial { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
    }
}
