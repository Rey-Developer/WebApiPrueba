using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPrueba.Models;

namespace WebApiPrueba.Request
{
    public class personaInsertarRequest
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public string cargo { get; set; }
        public string nombreEmpresa { get; set; }
        public string pais { get; set; }

        public BEPersona PasarPersona()
        {

            BEPersona p = new BEPersona();
            p.codigo = codigo;
            p.nombre = nombre;
            p.apellidos = apellidos;
            p.correo = correo;
            p.cargo = cargo;
            p.nombreEmpresa = nombreEmpresa;
            p.pais = pais;

            return p;

        }
    }
}
