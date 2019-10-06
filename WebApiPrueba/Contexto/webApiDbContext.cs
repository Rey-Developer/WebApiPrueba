using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPrueba.Models;

namespace WebApiPrueba.Contexto
{
    public class webApiDbContext : DbContext
    {
        //Agregamos el constructor
        public webApiDbContext(DbContextOptions<webApiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (EntityEntry item in ChangeTracker.Entries())
            {
                if (item.State == EntityState.Added)
                {

                }
            }
            return base.SaveChanges();
        }
        public DbSet<BEPersona> Persona { get; set; }
        public DbSet<BEUsuario> Usuario { get; set; }
    }
}
