using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPrueba.Models;

namespace WebApiPrueba.Services
{
    public interface IUsuarioServices
    {
        List<BEUsuario> Listar();

        BEUsuario Recuperar(int id);
        BEUsuario Autenticar(string codigo, string clave);
    }
}
