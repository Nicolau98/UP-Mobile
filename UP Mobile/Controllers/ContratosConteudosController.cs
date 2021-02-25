using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UP_Mobile.Data;
using UP_Mobile.Models;

namespace UP_Mobile.Controllers
{
    public class ContratosConteudosController : Controller
    {
        private readonly UPMobileContext _context;

        public ContratosConteudosController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: ContratosConteudos
        public async Task<IActionResult> Index()
        {
            var uPMobileContext = _context.ContratoConteudo.Include(c => c.IdConteudoNavigation).Include(c => c.IdContratoNavigation);
            return View(await uPMobileContext.ToListAsync());
        }

        // GET: ContratosConteudos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoConteudo = await _context.ContratoConteudo
                .Include(c => c.IdConteudoNavigation)
                .Include(c => c.IdContratoNavigation)
                .FirstOrDefaultAsync(m => m.IdContratoConteudo == id);
            if (contratoConteudo == null)
            {
                return NotFound();
            }

            return View(contratoConteudo);
        }

        // GET: ContratosConteudos/Create
        public IActionResult Create()
        {
            ViewData["IdConteudo"] = new SelectList(_context.ConteudoExtra, "IdConteudo", "Descricao");
            ViewData["IdContrato"] = new SelectList(_context.Contrato, "IdContrato", "MoradaFaturacao");
            return View();
        }

        // POST: ContratosConteudos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContratoConteudo,IdConteudo,IdContrato,DataInicioConteudo,DataFimConteudo")] ContratoConteudo contratoConteudo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoConteudo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConteudo"] = new SelectList(_context.ConteudoExtra, "IdConteudo", "Descricao", contratoConteudo.IdConteudo);
            ViewData["IdContrato"] = new SelectList(_context.Contrato, "IdContrato", "MoradaFaturacao", contratoConteudo.IdContrato);
            return View(contratoConteudo);
        }

        // GET: ContratosConteudos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoConteudo = await _context.ContratoConteudo.FindAsync(id);
            if (contratoConteudo == null)
            {
                return NotFound();
            }
            ViewData["IdConteudo"] = new SelectList(_context.ConteudoExtra, "IdConteudo", "Descricao", contratoConteudo.IdConteudo);
            ViewData["IdContrato"] = new SelectList(_context.Contrato, "IdContrato", "MoradaFaturacao", contratoConteudo.IdContrato);
            return View(contratoConteudo);
        }

        // POST: ContratosConteudos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContratoConteudo,IdConteudo,IdContrato,DataInicioConteudo,DataFimConteudo")] ContratoConteudo contratoConteudo)
        {
            if (id != contratoConteudo.IdContratoConteudo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoConteudo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoConteudoExists(contratoConteudo.IdContratoConteudo))
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
            ViewData["IdConteudo"] = new SelectList(_context.ConteudoExtra, "IdConteudo", "Descricao", contratoConteudo.IdConteudo);
            ViewData["IdContrato"] = new SelectList(_context.Contrato, "IdContrato", "MoradaFaturacao", contratoConteudo.IdContrato);
            return View(contratoConteudo);
        }

        // GET: ContratosConteudos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoConteudo = await _context.ContratoConteudo
                .Include(c => c.IdConteudoNavigation)
                .Include(c => c.IdContratoNavigation)
                .FirstOrDefaultAsync(m => m.IdContratoConteudo == id);
            if (contratoConteudo == null)
            {
                return NotFound();
            }

            return View(contratoConteudo);
        }

        // POST: ContratosConteudos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratoConteudo = await _context.ContratoConteudo.FindAsync(id);
            _context.ContratoConteudo.Remove(contratoConteudo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoConteudoExists(int id)
        {
            return _context.ContratoConteudo.Any(e => e.IdContratoConteudo == id);
        }
    }
}
