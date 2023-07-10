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
            return View();
        }

        //[Route("detalhe-de-paciente/{id}")]
        [HttpGet("detalhe-de-paciente/{nome}")]
        public IActionResult DetalhePaciente(string nome)
        {

            return View();
        }
    }
}
