namespace Cooperchip.ItDeveloper.Mvc.Controllers
{
    [Route(nameof(EstadoPacienteController))]
    public class EstadoPacienteController : BaseController
    {
        #region CONSTRUCTOR - PROPERTIES
        private readonly ApplicationDbContext _context;

        public EstadoPacienteController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region GET METHODS
        [HttpGet("GetAll")]
        public async Task<IActionResult> Index()
        {
            var model = await _context.EstadoPaciente.ToListAsync();

            return View(model);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("GetByid/{id}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            try
            {
                var model = await _context.EstadoPaciente.FindAsync(id);

                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro - {ex.Message}");
            }
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var model = await _context.EstadoPaciente.FindAsync(id);

                return View(model);
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
                var model = await _context.EstadoPaciente.FindAsync(id);

                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro - {ex.Message}");
            }
        }
        #endregion

        #region POST/PUT/DELETE METHODS
        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([Bind("Descricao")] EstadoPaciente model)
        {
            try
            {
                if (_context.EstadoPaciente.Any(x => x.Id == model.Id))
                    return BadRequest("Esse estado de paciente ja existe");

                EstadoPaciente estadoPaciente = new EstadoPaciente
                {
                    Descricao = model.Descricao
                };
                await _context.AddAsync(estadoPaciente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro - {ex.Message}");
            }
        }

        [HttpPost("EditPut/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPut([Bind("Descricao, Id")] EstadoPaciente estadoPaciente, Guid Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = await _context.EstadoPaciente.FirstOrDefaultAsync(x => x.Id.Equals(Id));
                    model.Descricao = estadoPaciente.Descricao;
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return BadRequest("Erro na edição");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest($"Erro - {ex.Message}");
            }
        }

        [HttpPost("DeleteConfirm/{id}")]
        public async Task<IActionResult> DeleteConfirm(Guid id)
        {
            try
            {
                var model = await _context.EstadoPaciente.FindAsync(id);

                _context.EstadoPaciente.Remove(model);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro - {ex.Message}");
            }
        }
        #endregion
    }
}
