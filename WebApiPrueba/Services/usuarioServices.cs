using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPrueba.Contexto;
using WebApiPrueba.Models;

namespace WebApiPrueba.Services
{
    public class usuarioServices : IUsuarioServices
    {
        private readonly webApiDbContext _context;
        public usuarioServices(webApiDbContext context)
        {
            _context = context;
        }
        public BEUsuario Autenticar(string codigo, string clave)
        {
            return _context.Usuario
                .FirstOrDefault
                (t => t.Credencial.ToUpper() == codigo.ToUpper()
                && t.Clave == clave);
        }

        public List<BEUsuario> Listar()
        {
            return _context.Usuario.ToList();
        }

        public BEUsuario Recuperar(int id)
        {
            return _context.Usuario.Find(id);
        }




    }
}
