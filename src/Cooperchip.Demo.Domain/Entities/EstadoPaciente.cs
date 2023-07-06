using Cooperchip.Demo.Domain.Entities.Base;

namespace Cooperchip.Demo.Domain.Entities
{
    public class EstadoPaciente : BaseEntity
    {
        public EstadoPaciente()
        {
            Pacientes = new HashSet<Paciente>();
        }
        public string? Descricao { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
