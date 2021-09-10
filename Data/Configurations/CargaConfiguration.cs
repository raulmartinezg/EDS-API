using EDS_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDS_API.Data.Configurations
{
    public class CargaConfiguration : IEntityTypeConfiguration<TbhisContenidoViajeSae>
    {
        public void Configure(EntityTypeBuilder<TbhisContenidoViajeSae> builder)
        {
            builder.HasKey(e => e.ClaveFolioViaje);

            builder.ToTable("TBHIS_ContenidoViajeSAE", "SAE");

            builder.Property(e => e.ClaveFolioViaje).HasColumnName("ClaveFolioViaje");

            builder.Property(e => e.Json)
                .HasColumnName("Json")
                .IsUnicode(false);

            builder.Property(e => e.FechaCaptura)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
        }
    }
}
