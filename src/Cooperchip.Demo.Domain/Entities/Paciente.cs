using Cooperchip.Demo.Domain.Entities.Base;
using Cooperchip.Demo.Domain.Enums;

namespace Cooperchip.Demo.Domain.Entities
{
    public class Paciente : BaseEntity
    {
        public Paciente()
        {
            this.Ativo = true;
            EstadoPaciente = new EstadoPaciente();
        }
        
        public Guid EstadoPacienteId { get; set; }
        public virtual EstadoPaciente EstadoPaciente { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInternacao { get; set; }
        public string? Email { get; set; }
        public bool Ativo{ get; set; }
        public string? Cpf { get; set; }
        public TipoPaciente TipoPaciente { get; set; }
        public Sexo Sexo { get; set; }
        public string? Rg { get; set; }
        public string? RgOrgao { get; set; }
        public string? EgDataEmissao { get; set; }
        public string? Motivo { get; set; }

        
    }
}
