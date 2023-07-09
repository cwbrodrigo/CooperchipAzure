using Cooperchip.Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cooperchip.Demo.Data.Mappings
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(60)")
                .HasColumnName("Nome");

            builder.Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsFixedLength(true)
                .HasColumnName("CPF")
                .HasColumnType("varchar(11)");

            builder.Property(x => x.RgOrgao)
                .HasColumnName("RgOrgao")
                .HasColumnType("varchar(10)");

            builder.Property(x => x.Rg)
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(150)");

            builder.Property(x => x.Motivo)
                .HasColumnName("Motivo")
                .HasColumnType("varchar(90)");

            builder.HasOne(x => x.EstadoPaciente)
                .WithMany(x => x.Pacientes)
                .HasForeignKey(x => x.EstadoPacienteId)
                .HasPrincipalKey(x => x.Id);

            builder.ToTable(nameof(Paciente));
        }
    }
}
