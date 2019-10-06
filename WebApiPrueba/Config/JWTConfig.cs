using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApiPrueba.Config
{
    public class JWTConfig
    {
        public string JWTKey { get; set; }
        public string JWTIssuer { get; set; }
        public string JWTAudience { get; set; }
    }
}
