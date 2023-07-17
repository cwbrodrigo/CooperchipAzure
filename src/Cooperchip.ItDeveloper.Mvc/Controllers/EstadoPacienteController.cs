using Cooperchip.Demo.Data.Data.ORM;
using Cooperchip.Demo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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

        public IActionResult Create()
        {
            return View();  
        }

        [HttpGet("Details/{id}")]
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

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id) => (IActionResult)await _context.EstadoPaciente.FindAsync(id);
        //{
        //    try
        //    {
        //        var model = await _context.EstadoPaciente.FindAsync(id);

        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Erro - {ex.Message}");
        //    }
        //}

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id) => (IActionResult)await _context.EstadoPaciente.FindAsync(id);               
        #endregion

        #region POST/PUT/DELETE METHODS
        [HttpPost("Create")]
        public async Task<IActionResult> Create([Bind("Descricao")] EstadoPaciente model)
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

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro - {ex.Message}");
            }
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Descricao, Id")] EstadoPaciente estadoPaciente)
        {
            try
            {
                if (id != estadoPaciente.Id)
                    return NotFound();

                if (ModelState.IsValid)
                {
                    _context.Update(estadoPaciente);
                    await _context.SaveChangesAsync();
                    return View(estadoPaciente);
                }
                else
                    return BadRequest("Erro na edição");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest($"Erro - {ex.Message}");
            }
        }

        [HttpDelete, ActionName("Delete")]
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
