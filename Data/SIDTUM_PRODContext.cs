using System;
using EDS_API.Data.Configurations;
using EDS_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EDS_API.Data
{
    public partial class SIDTUM_PRODContext : DbContext
    {
        public SIDTUM_PRODContext()
        {
        }

        public SIDTUM_PRODContext(DbContextOptions<SIDTUM_PRODContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FolioViajeGeneral> FolioViajeGenerals { get; set; }
        public virtual DbSet<TbhisContenidoViajeSae> TbhisContenidoViajeSaes { get; set; }
        public virtual DbSet<ConcesionarioRutum> ConcesionarioRuta { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.ApplyConfiguration(new CargaConfiguration());
            modelBuilder.ApplyConfiguration(new FoliosConfiguration());
            modelBuilder.ApplyConfiguration(new ConcesionarioRutaConfiguration());


        }
    }
}
