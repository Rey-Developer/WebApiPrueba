using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPrueba.Models;
using WebApiPrueba.Request;
using WebApiPrueba.Services;
using WebApiPrueba.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using WebApiPrueba.Config;

namespace WebApiPrueba.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private JWTConfig _jwtConfig;
        private readonly IUsuarioServices _usuarioServices;
        public AuthController(
            IOptions<JWTConfig> jwtConfig,
            IUsuarioServices usuarioServices)
        {
            _jwtConfig = jwtConfig.Value;
            _usuarioServices = usuarioServices;
        }

        [HttpPost]
        public IActionResult PedirToken([FromBody]AuthRequest request)
        {

            if (string.IsNullOrEmpty(request.usuario)
                || string.IsNullOrEmpty(request.clave))
            {
                return BadRequest("Debe enviar usuario / clave");
            }
            //esto deberia validarse contra la tabla de usuarios
             BEUsuario user = _usuarioServices.Autenticar(request.usuario, request.clave);
            //if (!(request.usuario == "jperez" && request.clave == "123456"))
            if (user == null)
            {
                return BadRequest("Credenciales invalidad");
            }

            //Generando la semilla
            string clave = _jwtConfig.JWTKey;
            byte[] claveEnByte = Encoding.UTF8.GetBytes(clave);
            SymmetricSecurityKey key = new SymmetricSecurityKey(claveEnByte);

            //Generando el algoritmo
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Creando el Payload
            var claims = new[] {
                new Claim("user", user.Credencial),
                new Claim("rol", user.Rol)
            };

            //creando un generador de token
            JwtSecurityToken generador = new JwtSecurityToken(
                issuer: _jwtConfig.JWTIssuer,
                audience: _jwtConfig.JWTAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: cred
                );

            string token = new JwtSecurityTokenHandler().WriteToken(generador);
            AuthResponse resp = new AuthResponse() { Token = token };
            return Ok(resp);
        }
    }
}
