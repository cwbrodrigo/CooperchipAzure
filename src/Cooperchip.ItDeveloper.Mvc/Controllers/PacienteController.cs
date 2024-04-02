using Cooperchip.ItDeveloper.Mvc.Extensions.Repository;
using Cooperchip.ItDeveloper.Mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cooperchip.ItDeveloper.Mvc.Controllers
{
    [Route(nameof(PacienteController))]
    public class PacienteController : BaseController
    {
        #region CONSTRUCOTR
        private readonly ApplicationDbContext _context;
        //private readonly ILogger _logger;
        private IUtilities _mappers;
        IEnumerable<EstadoPaciente> estadoPacientes;

        public PacienteController(ApplicationDbContext context, IUtilities mappers)
        {
            this._context = context;
            _mappers = mappers;
            estadoPacientes = _context.EstadoPaciente.AsNoTracking().ToList();
        }
        #endregion

        #region GET METHODS
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var model = await _context.Paciente
                            .Include(x => x.EstadoPaciente)
                            .AsNoTracking()
                            .ToListAsync();
            List<PacienteViewModel> viewModel = new List<PacienteViewModel>();

            viewModel = await _mappers.MapListModelToListViewModel(model);

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

            var viewModel = await _mappers.MapModelToViewModel(model);

            return View(viewModel);
        }

        [HttpGet("GetByEstadoPaciente/{id}")]
        public async Task<IActionResult> GetPacienteByEstado(Guid Id)
        {
            var paciente = await _context.Paciente
                                 .Include(e => e.EstadoPacienteId)
                                 .AsNoTracking()
                                 .Where(x => x.EstadoPaciente.Id == Id)
                                 .OrderBy(o => o.Nome)
                                 .ToListAsync();
                                 
            return View(await _mappers.MapListModelToListViewModel(paciente));
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.EstadoPaciente = new SelectList(estadoPacientes.Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Descricao)), "Key", "Value");

            return View();
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var model = await _context.Paciente.FindAsync(id);
                ViewBag.EstadoPaciente = new SelectList(estadoPacientes.Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Descricao)), "Key", "Value");

                var viewModel = await _mappers.MapModelToViewModel(model);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro - {ex.Message}");
            }
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var model = await _context.Paciente.FindAsync(id);

                var viewModel = await _mappers.MapModelToViewModel(model);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro - {ex.Message}");
            }
        }

        public async Task<IActionResult> GetPacienteByEstadoPaciente(Guid id)
        {
            var model = await _context.Paciente
                .Include(ep => ep.EstadoPaciente)
                .AsNoTracking()
                .Where(x => x.EstadoPaciente.Id.Equals(id))
                .OrderBy(o => o.Nome)
                .ToListAsync();

            if (model is null)
                return NotFound();

            var viewModel = await _mappers.MapListModelToListViewModel(model);

            return View(viewModel);
        }
        #endregion

        #region POST METHODS
        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost(PacienteViewModel pacienteViewModel)
        {
            if (ModelState.IsValid)
            {
                Paciente paciente = await _mappers.MapViewModelToModel(pacienteViewModel);
                paciente.EstadoPaciente = null;
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

        //#region: Mappers
        //private async Task<Paciente> MapViewModelToModel(PacienteViewModel model)
        //{
        //    Paciente paciente = new()
        //    {
        //        Id = model.Id,
        //        Ativo = model.Ativo,
        //        Cpf = model.Cpf,
        //        DataInternacao = model.DataInternacao,
        //        DataNascimento = model.DataNascimento,
        //        Email = model.Email,
        //        EstadoPacienteId = model.EstadoPacienteId,
        //        Motivo = model.Motivo,
        //        Nome = model.Nome,
        //        Rg = model.Rg,
        //        RgDataEmissao = model.RgDataEmissao,
        //        RgOrgao = model.RgOrgao,
        //        Sexo = model.Sexo,
        //        TipoPaciente = model.TipoPaciente
        //    };

        //    return await Task.FromResult(paciente);
        //}

        //private async Task<PacienteViewModel> MapModelToViewModel(Paciente? model)
        //{
        //    PacienteViewModel pacienteViewModel = new()
        //    {
        //        Id = model.Id,
        //        Ativo = model.Ativo,
        //        Cpf = model.Cpf,
        //        DataInternacao = model.DataInternacao,
        //        DataNascimento = model.DataNascimento,
        //        Email = model.Email,
        //        EstadoPacienteId = model.EstadoPacienteId,
        //        Motivo = model.Motivo,
        //        Nome = model.Nome,
        //        Rg = model.Rg,
        //        RgDataEmissao = model.RgDataEmissao,
        //        RgOrgao = model.RgOrgao,
        //        Sexo = model.Sexo,
        //        TipoPaciente = model.TipoPaciente
        //    };

        //    return await Task.FromResult(pacienteViewModel);
        //}

        //private async Task<List<PacienteViewModel>> MapListModelToListViewModel(List<Paciente>? model)
        //{
        //    List<PacienteViewModel> listView = new();

        //    foreach (var item in model)
        //    {
        //        listView.Add(new PacienteViewModel
        //        {
        //            Ativo = item.Ativo,
        //            Cpf = item.Cpf,
        //            DataInternacao = item.DataInternacao,
        //            DataNascimento = item.DataNascimento,
        //            Email = item.Email,
        //            EstadoPacienteId = item.EstadoPacienteId,
        //            Id = item.Id,
        //            Motivo = item.Motivo,
        //            Nome = item.Nome,
        //            Rg = item.Rg,
        //            RgDataEmissao = item.RgDataEmissao,
        //            RgOrgao = item.RgOrgao,
        //            Sexo = item.Sexo,
        //            TipoPaciente = item.TipoPaciente
        //        });
        //    }

        //    return await Task.FromResult(listView);
        //}
        //#endregion
    }
}
