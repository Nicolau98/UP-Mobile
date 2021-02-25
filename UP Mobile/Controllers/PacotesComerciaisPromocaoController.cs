using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UP_Mobile.Data;
using UP_Mobile.Models;

namespace UP_Mobile.Controllers
{
    public class PacotesComerciaisPromocaoController : Controller
    {
        private readonly UPMobileContext _context;

        public PacotesComerciaisPromocaoController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: PacotesComerciaisPromocao
        public async Task<IActionResult> Index()
        {
            var UPMobileContext = _context.PacoteComercialPromocao.Include(p => p.IdPacoteNavigation).Include(p => p.IdPromocaoNavigation);
            return View(await UPMobileContext.ToListAsync());
        }

        // GET: PacotesComerciaisPromocao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteComercialPromocao = await _context.PacoteComercialPromocao
                .Include(p => p.IdPacoteNavigation)
                .Include(p => p.IdPromocaoNavigation)
                .FirstOrDefaultAsync(m => m.IdPacoteComercialPromocao == id);
            if (pacoteComercialPromocao == null)
            {
                return NotFound();
            }

            return View(pacoteComercialPromocao);
        }

        // GET: PacotesComerciaisPromocao/Create
        public IActionResult Create()
        {
            ViewData["IdPacote"] = new SelectList(_context.PacoteComercial, "IdPacote", "Nome");
            ViewData["IdPromocao"] = new SelectList(_context.Promocao, "IdPromocao", "Nome");
            return View();
        }

        // POST: PacotesComerciaisPromocao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPacoteComercialPromocao,IdPromocao,IdPacote, PrecoTotalPacote")] PacoteComercialPromocao pacoteComercialPromocao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacoteComercialPromocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPacote"] = new SelectList(_context.PacoteComercial, "IdPacote", "Nome", pacoteComercialPromocao.IdPacote);
            ViewData["IdPromocao"] = new SelectList(_context.Promocao, "IdPromocao", "Nome", pacoteComercialPromocao.IdPromocao);
            return View(pacoteComercialPromocao);
        }

        // GET: PacotesComerciaisPromocao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteComercialPromocao = await _context.PacoteComercialPromocao.FindAsync(id);
            if (pacoteComercialPromocao == null)
            {
                return NotFound();
            }
            ViewData["IdPacote"] = new SelectList(_context.PacoteComercial, "IdPacote", "Nome", pacoteComercialPromocao.IdPacote);
            ViewData["IdPromocao"] = new SelectList(_context.Promocao, "IdPromocao", "Nome", pacoteComercialPromocao.IdPromocao);
            return View(pacoteComercialPromocao);
        }

        // POST: PacotesComerciaisPromocao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPacoteComercialPromocao,IdPromocao,IdPacote, PrecoTotalPacote")] PacoteComercialPromocao pacoteComercialPromocao)
        {
            if (id != pacoteComercialPromocao.IdPacoteComercialPromocao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacoteComercialPromocao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacoteComercialPromocaoExists(pacoteComercialPromocao.IdPacoteComercialPromocao))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPacote"] = new SelectList(_context.PacoteComercial, "IdPacote", "Nome", pacoteComercialPromocao.IdPacote);
            ViewData["IdPromocao"] = new SelectList(_context.Promocao, "IdPromocao", "Nome", pacoteComercialPromocao.IdPromocao);
            return View(pacoteComercialPromocao);
        }

        // GET: PacotesComerciaisPromocao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteComercialPromocao = await _context.PacoteComercialPromocao
                .Include(p => p.IdPacoteNavigation)
                .Include(p => p.IdPromocaoNavigation)
                .FirstOrDefaultAsync(m => m.IdPacoteComercialPromocao == id);
            if (pacoteComercialPromocao == null)
            {
                return NotFound();
            }

            return View(pacoteComercialPromocao);
        }

        // POST: PacotesComerciaisPromocao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacoteComercialPromocao = await _context.PacoteComercialPromocao.FindAsync(id);
            _context.PacoteComercialPromocao.Remove(pacoteComercialPromocao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacoteComercialPromocaoExists(int id)
        {
            return _context.PacoteComercialPromocao.Any(e => e.IdPacoteComercialPromocao == id);
        }
    }
}
