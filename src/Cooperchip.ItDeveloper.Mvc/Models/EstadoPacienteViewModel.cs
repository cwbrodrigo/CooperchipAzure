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
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "O capo {0} deve ter entre {2} e {1} caracteres")]
        public string? Descricao { get; set; }

        public virtual ICollection<Paciente>? Pacientes { get; set; }
    }
}
