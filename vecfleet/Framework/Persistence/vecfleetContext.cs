using System;
using System.Collections.Generic;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Framework.Persistence
{
    public partial class vecfleetContext : DbContext
    {
        public vecfleetContext()
        {
        }

        public vecfleetContext(DbContextOptions<vecfleetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.ToTable("TipoVehiculo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Anio).HasColumnName("anio");

                entity.Property(e => e.CantidadRuedas).HasColumnName("cantidadRuedas");

                entity.Property(e => e.Chasis)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("chasis");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.IdTipoVehiculo).HasColumnName("idTipoVehiculo");

                entity.Property(e => e.KmsProximoMantenimiento).HasColumnName("kmsProximoMantenimiento");

                entity.Property(e => e.KmsRecorrido).HasColumnName("kmsRecorrido");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.Patente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
