using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Insfrastructure.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {

            builder.ToTable("Post");

            builder.Property(e => e.Id);

            builder.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Fecha).HasColumnType("datetime");

            builder.Property(e => e.Imagen)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Usuario");

        }
    }
}
