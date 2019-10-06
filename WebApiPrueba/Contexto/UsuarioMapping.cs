using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPrueba.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApiPrueba.Contexto
{
    public class UsuarioMapping : IEntityTypeConfiguration<BEUsuario>
    {
        public void Configure(EntityTypeBuilder<BEUsuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(c => c.Codigo);
            builder.Property(t => t.Codigo).HasColumnName("IdUsuario");
        }
    }
}
