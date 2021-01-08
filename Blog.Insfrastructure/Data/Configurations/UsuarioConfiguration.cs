using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Blog.Insfrastructure.Data.Configurations
{
   public  class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
      

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(e => e.Id);

            builder.Property(e => e.Apellido)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

            builder.Property(e => e.Email)
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

            builder.Property(e => e.FechaNacimiento).HasColumnType("date");

            builder.Property(e => e.Nombre)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

            builder.Property(e => e.Telefono)
                        .HasMaxLength(25)
                        .IsUnicode(false);
        }
    }
}
