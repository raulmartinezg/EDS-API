using EDS_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Data.Configurations
{
    public class ConcesionarioRutaConfiguration : IEntityTypeConfiguration<ConcesionarioRutum>
    {
        public void Configure(EntityTypeBuilder<ConcesionarioRutum> builder)
        {
            
            builder.HasNoKey();

            builder.ToView("ConcesionarioRuta");

            builder.Property(e => e.c).HasColumnName("ClaveFolioViaje");

            builder.Property(e => e.f)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FolioViaje");

            builder.Property(e => e.n).HasMaxLength(50).IsUnicode(false).HasColumnName("NumeroConcCte");

            builder.Property(e => e.r).HasMaxLength(255).IsUnicode(false).HasColumnName("RazonSocial");

        }
    }
}
