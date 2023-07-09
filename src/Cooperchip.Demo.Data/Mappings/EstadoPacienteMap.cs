using Cooperchip.Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cooperchip.Demo.Data.Mappings
{
    public class EstadoPacienteMap : IEntityTypeConfiguration<EstadoPaciente>
    {
        public void Configure(EntityTypeBuilder<EstadoPaciente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .HasColumnName("Descicao")
                .IsRequired();

            builder.HasMany(x => x.Pacientes)
                .WithOne(x => x.EstadoPaciente);
                //.OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(nameof(EstadoPaciente));
        }
    }
}
