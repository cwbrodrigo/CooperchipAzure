using Cooperchip.Demo.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.ItDeveloper.Mvc.Models
{
    public class PacienteViewModel
    {
        [Key]
        [DisplayName("Id do Paciente")]
        public Guid Id { get; set; }

        public Guid EstadoPacienteId { get; set; }
        public virtual EstadoPacienteViewModel EstadoPaciente { get; set; }

        public string? Nome { get; set; }
        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "o campo {0} é inválido")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Data de Internacao")]
        [DataType(DataType.Date, ErrorMessage = "o campo {0} é inválido")]
        public DateTime DataInternacao { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "o campo {0} é inválido")]
        public string? Email { get; set; }

        public bool Ativo { get; set; }
        public string? Cpf { get; set; }

        [DisplayName("Tipo do Paciente")]
        public TipoPaciente TipoPaciente { get; set; }

        public Sexo Sexo { get; set; }

        public string? Rg { get; set; }

        [DisplayName("Orgão do RG")]
        public string? RgOrgao { get; set; }

        [DisplayName("Data de Emissão do RG")]
        public string? EgDataEmissao { get; set; }

        public string? Motivo { get; set; }

        public override string ToString()
        {
            return $"{Id.ToString()} - {Nome}";
        }
    }
}
