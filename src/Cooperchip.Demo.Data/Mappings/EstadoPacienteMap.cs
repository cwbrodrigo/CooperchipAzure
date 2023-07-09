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
                .IsRequired()
                .HasColumnName("Descicao");

            builder.HasMany(x => x.Pacientes)
                .WithOne(x => x.EstadoPaciente);

            builder.ToTable(nameof(EstadoPaciente));
                //.OnDelete(DeleteBehavior.NoAction);
        }
    }
}
