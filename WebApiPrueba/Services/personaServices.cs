using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPrueba.Models;
using WebApiPrueba.Contexto;

namespace WebApiPrueba.Services
{
    public class personaServices : IpersonaServices
    {
        private readonly webApiDbContext contexto;

        public personaServices(webApiDbContext _contexto)
        {
            contexto = _contexto;
        }

        public List<BEPersona> Listar()
        {
            return contexto.Persona.ToList();
        }

        public BEPersona Insertar(BEPersona persona)
        {
            contexto.Persona.Add(persona);
            contexto.SaveChanges();

            return persona;
        }
        public BEPersona Actualizar(int Id)
        {
            return contexto.Persona.FirstOrDefault(x => x.idPersona == Id);
        }

        public int Eliminar(int Id)
        {
            BEPersona pe = contexto.Persona.Find(Id);
            contexto.Persona.Remove(pe);
            return contexto.SaveChanges();
        }

      
    }
}
