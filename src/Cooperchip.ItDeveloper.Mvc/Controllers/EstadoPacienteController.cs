using Cooperchip.Demo.Data.Data.ORM;
using Cooperchip.Demo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cooperchip.ItDeveloper.Mvc.Controllers
{
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
        public async Task<IActionResult> Index()
        {
            var model = await _context.EstadoPaciente.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            try
            {
                var model = _context.EstadoPaciente.FirstOrDefaultAsync(x => x.Id.Equals(id));

                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro - {ex.Message}");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("Ediat/{id}")]
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
        #endregion

        #region POST METHODS
        [HttpPost("adicionar-estado-paceinte")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao")] EstadoPaciente estadoPaciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EstadoPaciente model = new EstadoPaciente
                    {
                        Descricao = estadoPaciente.Descricao
                    };

                    var ret = await _context.Set<EstadoPaciente>().AddAsync(model);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                    return BadRequest("Erro na criação");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro - {ex.Message}");
            }
        }
        #endregion
    }
}
