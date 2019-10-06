using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPrueba.Models;

namespace WebApiPrueba.Services
{
    public interface IpersonaServices
    {
        List<BEPersona> Listar();
        BEPersona Insertar(BEPersona usuario);
        BEPersona Actualizar(int Id);
        int Eliminar(int Id);
    }
}
