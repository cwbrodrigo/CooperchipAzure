using Cooperchip.Demo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Cooperchip.ItDeveloper.Mvc.Controllers
{
    [Route("")]
    [Route("gestao-de-pacientes")]
    [Route("gestao-de-paciente")]
    public class PacienteController : BaseController
    {
        [Route("pacientes")]
        [Route("obter-pacientes")]
        //[HttpGet("")]
        public IActionResult Index()
        {
            var pacientes = ObterPacientes();

            return View(pacientes);
        }

        //[Route("detalhe-de-paciente/{id}")]
        [HttpGet("detalhe-de-paciente/{nome}")]
        public IActionResult DetalhePaciente(string nome)
        {
            var paciente = ObterPacientes().FirstOrDefault(x => x.Nome == nome);

            if (paciente is null) return NotFound();

            return View(paciente);
        }

        [HttpPost("adicionar-paciente")]
        public IActionResult AdicionarPaciente()
        {
            return View();
        }

        private List<Paciente> ObterPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>
            {
                new Paciente()
                {
                    Nome = "Rodrigo",
                    Cpf = "06531506548"
                },
                new Paciente()
                {
                    Nome = "José",
                    Cpf = "2589696334"
                },
                new Paciente()
                {
                    Nome = "Maria",
                    Cpf = "25893214334"
                }
            };
            return pacientes;
        }
    }
}

//    public class Paciente
//    {
//        public Paciente()
//        {
//            Id = Guid.NewGuid();
//            Telefones = new HashSet<Telefone>();
//        }
//        public Guid Id { get; set; }
//        public string? Nome { get; set; }
//        public string? Cpf { get; set; }
//        public ICollection<Telefone> Telefones { get; set; }
//        //public DateTime DataNascimento { get; set; }
//    }

//    public class Telefone
//    {
//        public Telefone()
//        {
//            Id = Guid.NewGuid();
//        }
//        public Guid Id { get; set; }
//        public string? TipoDeTelefone { get; set; }
//        public string? Numero { get; set; }
//    }
//}
