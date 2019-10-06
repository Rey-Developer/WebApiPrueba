using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiPrueba.Contexto;
using WebApiPrueba.Services;
using WebApiPrueba.Config;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApiPrueba
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //inyeccion de dependencia
            services.AddTransient<IpersonaServices, personaServices>();
            services.AddTransient<IUsuarioServices, usuarioServices>();

            services.Configure<JWTConfig>(Configuration.GetSection("JWTConfig"));

            //Conectarnos a la Base de datos
            services.AddDbContext<webApiDbContext>(
                options => {
                    options.UseSqlServer(
                        Configuration.GetConnectionString("CnnWebApi")
                     );
             });

            //configura la seguridad

            string clave = Configuration.GetSection("JWTConfig")["JWTKey"];
            byte[] claveEnByte = Encoding.UTF8.GetBytes(clave);
            SymmetricSecurityKey key = new SymmetricSecurityKey(claveEnByte);
            //configura cors
            services.AddCors(options =>
            {
                options.AddPolicy("Todos",
                    builder =>
                    {
                        builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowCredentials();

                    });

            }

                );

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidIssuer = "demo.com",
                        ValidAudience = "demo.com",
                        IssuerSigningKey = key
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("Todos");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
