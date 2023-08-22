using Azure.Core;
using Cooperchip.ItDeveloper.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cooperchip.ItDeveloper.Mvc.Controllers
{
    public class PacienteController : BaseController
    {
        #region CONSTRUCOTR
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public PacienteController(ApplicationDbContext context) => _context = context;
        #endregion

        #region GET METHODS
        [HttpGet("GetAll")]
        public async Task<IActionResult> Index()
        {
            var model = await _context.Paciente
                            .Include(x => x.EstadoPaciente)
                            .AsNoTracking()
                            .ToListAsync();

            if (model is null)
                return View();

            List<PacienteViewModel> viewModel = await MapListModelToListViewModel(model);

            return View(viewModel);
        }

        [HttpGet("GetByid/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await _context.Paciente
                .Include(x => x.EstadoPaciente)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (model is null)
                return NotFound();

            var viewModel = await MapModelToViewModel(model);

            return View(viewModel);
        }

        [HttpGet("GetByEstadoPaciente/{id}")]

        public async Task<IActionResult> GetByEstadoPaciente(Guid id)
        {
            var model = await _context.Paciente
                .Include(ep => ep.EstadoPaciente)
                .AsNoTracking()
                .Where(x => x.EstadoPaciente.Id.Equals(id))
                .OrderBy(o => o.Nome)
                .ToListAsync();

            if (model is null)
                return NotFound();

            var viewModel = await MapListModelToListViewModel(model);

            return View(viewModel);
        }
        #endregion

        #region POST METHODS
        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                await _context.Set<Paciente>().AddAsync(paciente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
                return BadRequest();
        }

        [HttpPost("EditPut")]
        public async Task<IActionResult> EditPut([FromBody] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                var model = await _context.Set<Paciente>().AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(paciente.Id));

                model = paciente;

                _context.Entry(model).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
                return BadRequest();
        }

        [HttpPost("DeleteConfirm/{id}")]
        public async Task<IActionResult> DeleteConfirm([Bind("Id")] Guid id)
        {
            var model = await _context.Paciente.FindAsync(id);

            _context.Paciente.Remove(model);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region: Mappers
        private async Task<PacienteViewModel> MapModelToViewModel(Paciente model)
        {
            PacienteViewModel pacienteViewModel = new()
            {
                Id = model.Id,
                Ativo = model.Ativo,
                Cpf = model.Cpf,
                DataInternacao = model.DataInternacao,
                DataNascimento = model.DataNascimento,
                Email = model.Email,
                EstadoPacienteId = model.EstadoPacienteId,
                Motivo = model.Motivo,
                Nome = model.Nome,
                Rg = model.Rg,
                RgDataEmissao = model.RgDataEmissao,
                RgOrgao = model.RgOrgao,
                Sexo = model.Sexo,
                TipoPaciente = model.TipoPaciente
            };

            return await Task.FromResult(pacienteViewModel);
        }

        private async Task<List<PacienteViewModel>> MapListModelToListViewModel(List<Paciente> model)
        {
            List<PacienteViewModel> listView = new();

            foreach (var item in model)
            {
                listView.Add(new PacienteViewModel
                {
                    Ativo = item.Ativo,
                    Cpf = item.Cpf,
                    DataInternacao = item.DataInternacao,
                    DataNascimento = item.DataNascimento,
                    Email = item.Email,
                    EstadoPacienteId = item.EstadoPacienteId,
                    Id = item.Id,
                    Motivo = item.Motivo,
                    Nome = item.Nome,
                    Rg = item.Rg,
                    RgDataEmissao = item.RgDataEmissao,
                    RgOrgao = item.RgOrgao,
                    Sexo = item.Sexo,
                    TipoPaciente = item.TipoPaciente
                });
            }

            return await Task.FromResult(listView);
        }
        #endregion
    }
}
