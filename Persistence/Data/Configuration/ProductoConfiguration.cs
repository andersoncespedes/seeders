using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("producto");

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(245);

        builder.Property(e => e.FechaCreacion)
        .HasColumnName("fecha_creacion")
        .HasColumnType("date")
        .IsRequired();

        builder.Property(e => e.Precio)
        .HasColumnName("precio")
        .HasColumnType("decimal")
        .IsRequired();

        builder.Property(e => e.MarcaId)
        .HasColumnName("marca_id")
        .IsRequired();

        builder.Property(e => e.CategoriaId)
        .HasColumnName("categoria_id")
        .IsRequired();

        builder.HasOne(e => e.Marca)
        .WithMany(e => e.Productos)
        .HasForeignKey(e => e.MarcaId);

        builder.HasOne(e => e.Categoria)
        .WithMany(e => e.Productos)
        .HasForeignKey(e => e.CategoriaId);


    }
}
