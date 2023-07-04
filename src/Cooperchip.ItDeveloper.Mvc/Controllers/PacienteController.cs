using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("detalhe-de-paciente/{id}")]
        public IActionResult DetalhePaciente(Guid id)
        {
            return View();
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
                    Cpf = "06531506548",
                    Telefones = new List<Telefone>
                    {
                        new Telefone(){ TipoDeTelefone = "Residencial", Numero = "413256985"},
                        new Telefone(){ TipoDeTelefone = "Comercial", Numero = "4135252565"},
                        new Telefone(){ TipoDeTelefone = "Celular", Numero = "4198816969"}
                    }
                },
                new Paciente()
                {
                    Nome = "José",
                    Cpf = "2589696334",
                    Telefones = new List<Telefone>
                    {
                        new Telefone(){ TipoDeTelefone = "Residencial", Numero = "4145456985"},
                        new Telefone(){ TipoDeTelefone = "Comercial", Numero = "41365567498"},
                        new Telefone(){ TipoDeTelefone = "Celular", Numero = "4185898457784"}
                    }
                },
                new Paciente()
                {
                    Nome = "Maria",
                    Cpf = "25893214334",
                    Telefones = new List<Telefone>
                    {
                        new Telefone(){ TipoDeTelefone = "Residencial", Numero = "55858589546"},
                        new Telefone(){ TipoDeTelefone = "Comercial", Numero = "5485465446"},
                        new Telefone(){ TipoDeTelefone = "Celular", Numero = "84879415465849"}
                    }
                }
            };
            return pacientes;
        }
    }

    public class Paciente
    {
        public Paciente()
        {
            Id = Guid.NewGuid();
            Telefones = new HashSet<Telefone>();
        }
        protected Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        //public DateTime DataNascimento { get; set; }
    }

    public class Telefone
    {
        public Telefone()
        {
            Id = Guid.NewGuid();
        }
        protected Guid Id { get; set; }
        public string? TipoDeTelefone { get; set; }
        public string? Numero { get; set; }
    }
}
