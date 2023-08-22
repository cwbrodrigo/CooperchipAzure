using Cooperchip.Demo.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Cooperchip.ItDeveloper.Mvc.Models
{
    public class PacienteViewModel
    {
        [Key]
        [DisplayName("Id do Paciente")]
        public Guid Id { get; set; }

        [ForeignKey("EstadoPaciente")]
        [DisplayName("Estado do Paciente")]
        public Guid EstadoPacienteId { get; set; }
        public virtual EstadoPacienteViewModel? EstadoPaciente { get; set; }

        [DisplayName("Nome do Paciente")]
        [StringLength(maximumLength: 80, MinimumLength = 5, ErrorMessage = "O capo {0} deve ter entre {2} e {1} caracteres")]
        public string? Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Data de Internação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida")]
        public DateTime DataInternacao { get; set; }


        //[DisplayName("Data Inclusão")]
        //public DateTime? DataInclusao { get; set; }

        //[DisplayName("Data Última Modificação")]
        //public DateTime? DataUltimaModificacao { get; set; }

        //[DisplayName("Usuário Inclusão")]
        //public string? UsuarioInclusao { get; set; }

        //[DisplayName("Usuário Última Modificação")]
        //public string? UsuarioUltimaModificacao { get; set; }


        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail  inválido")]
        public string? Email { get; set; }

        public bool Ativo { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(maximumLength: 11, ErrorMessage = "O capo {0} deve ter {1} caracteres", MinimumLength = 11)]
        public string? Cpf { get; set; }

        [DisplayName("Tipo do Paciente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TipoPaciente TipoPaciente { get; set; }

        [DisplayName("Sexo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Sexo Sexo { get; set; }

        [DisplayName("RG")]
        [MaxLength(15, ErrorMessage = "O capo {0} deve ter no máximo {1} caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Rg { get; set; }

        [DisplayName("Orgão Expedidor")]
        [MaxLength(10, ErrorMessage = "O capo {0} deve ter no máximo {1} caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? RgOrgao { get; set; }

        [DisplayName("Data de Emissão do RG")]
        [MaxLength(10, ErrorMessage = "O capo {0} deve ter no máximo {1} caracteres")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida")]
        public string? RgDataEmissao { get; set; }

        [MaxLength(90, ErrorMessage = "O capo {0} deve ter no máximo {1} caracteres")]
        public string? Motivo { get; set; }

        public override string ToString()
        {
            return $"{Id.ToString()} - {Nome}";
        }
    }
}
