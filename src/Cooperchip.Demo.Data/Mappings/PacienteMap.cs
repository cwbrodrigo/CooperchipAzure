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
                .HasColumnType("varchar(60)")
                .HasMaxLength(60)
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
                .IsFixedLength(true)
                .HasColumnName("CPF");

            builder.Property(x => x.RgOrgao)
                .HasColumnType("varchar(10)")
                .HasColumnName("RgOrgao");

            builder.Property(x => x.Rg)
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);

            builder.Property(x => x.Email)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .HasColumnName("Email");

            builder.Property(x => x.Motivo)
                .HasColumnType("varchar(90)")
                .HasMaxLength(90)
                .HasColumnName("Motivo");

            builder.HasOne(x => x.EstadoPaciente)
                .WithMany(x => x.Pacientes)
                .HasForeignKey(x => x.EstadoPacienteId)
                .HasPrincipalKey(x => x.Id);

            builder.ToTable(nameof(Paciente));
        }
    }
}
