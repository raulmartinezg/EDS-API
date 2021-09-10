using EDS_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDS_API.Data.Configurations
{
    public class FoliosConfiguration : IEntityTypeConfiguration<FolioViajeGeneral>
    {
        public void Configure(EntityTypeBuilder<FolioViajeGeneral> builder)
        {
                builder.HasNoKey();

                builder.ToView("FolioViajeGeneral");

                builder.Property(e => e.ClaveFolioViaje).HasColumnName("ClaveFolioViaje");

                builder.Property(e => e.FolioViaje)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                builder.Property(e => e.Operador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.Placa)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                builder.Property(e => e.Ruta)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                builder.Property(e => e.SalidaProgramada).HasColumnType("datetime");

                builder.Property(e => e.Unidad).HasMaxLength(10);
        }
    }
}
