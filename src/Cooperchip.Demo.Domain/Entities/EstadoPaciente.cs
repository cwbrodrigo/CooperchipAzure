namespace Cooperchip.Demo.Domain.Entities
{
    public class EstadoPaciente
    {
        public EstadoPaciente()
        {
            this.Id = Guid.NewGuid();
            Pacientes = new HashSet<Paciente>();
        }
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
