using Cooperchip.Demo.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.ItDeveloper.Mvc.Models
{
    public class EstadoPacienteViewModel
    {
        [Key]
        [DisplayName("Id do Estado do Paciente")]
        public Guid Id { get; set; }

        [DisplayName("Descrição do Paciente")]
        public string? Descricao { get; set; }

        public virtual ICollection<Paciente>? Pacientes { get; set; }
    }
}
