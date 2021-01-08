using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Blog.Insfrastructure.Data.Configurations
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {

            builder.ToTable("Comentario");

            builder.Property(e => e.Id);

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Fecha).HasColumnType("datetime");

            builder.HasOne(d => d.IdPostNavigation)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Post");

            builder.HasOne(d => d.IdPost1)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Usuario1");

        }
    }
}
