using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPrueba.Services;
using WebApiPrueba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPrueba.Request;

namespace WebApiPrueba.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class personaController : ControllerBase
    {
        private IpersonaServices _personaServices;
        //creamos el contructor
        public personaController(IpersonaServices personaServices)
        {
            _personaServices = personaServices;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_personaServices.Listar());
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] personaInsertarRequest per)
        {
            if (string.IsNullOrEmpty(per.codigo))
            {
                return BadRequest("Debe llenar el codigo");
            }

            return Ok(_personaServices.Insertar(per.PasarPersona()));
        }
    }
}
