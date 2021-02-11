using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UP_Mobile.Data;
using UP_Mobile.Models;

namespace UP_Mobile.Controllers
{
    public class FaturasController : Controller
    {
        private readonly UPMobileContext _context;

        public FaturasController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: Faturas
        public async Task<IActionResult> Index()
        {
            var uPMobileContext = _context.Fatura.Include(f => f.IdContratoNavigation);
            return View(await uPMobileContext.ToListAsync());
        }

        // GET: Faturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fatura = await _context.Fatura
                .Include(f => f.IdContratoNavigation)
                .FirstOrDefaultAsync(m => m.IdFatura == id);
            if (fatura == null)
            {
                return NotFound();
            }

            return View(fatura);
        }

        // GET: Faturas/Create
        public IActionResult Create()
        {
            ViewData["IdContrato"] = new SelectList(_context.Contrato, "IdContrato", "MoradaFaturacao");
            return View();
        }

        // POST: Faturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFatura,IdContrato,Data,DataLimitePagamento,Descricao,PrecoTotal")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdContrato"] = new SelectList(_context.Contrato, "IdContrato", "MoradaFaturacao", fatura.IdContrato);
            return View(fatura);
        }

        // GET: Faturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fatura = await _context.Fatura.FindAsync(id);
            if (fatura == null)
            {
                return NotFound();
            }
            ViewData["IdContrato"] = new SelectList(_context.Contrato, "IdContrato", "MoradaFaturacao", fatura.IdContrato);
            return View(fatura);
        }

        // POST: Faturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFatura,IdContrato,Data,DataLimitePagamento,Descricao,PrecoTotal")] Fatura fatura)
        {
            if (id != fatura.IdFatura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaturaExists(fatura.IdFatura))
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
            ViewData["IdContrato"] = new SelectList(_context.Contrato, "IdContrato", "MoradaFaturacao", fatura.IdContrato);
            return View(fatura);
        }

        // GET: Faturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fatura = await _context.Fatura
                .Include(f => f.IdContratoNavigation)
                .FirstOrDefaultAsync(m => m.IdFatura == id);
            if (fatura == null)
            {
                return NotFound();
            }

            return View(fatura);
        }

        // POST: Faturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fatura = await _context.Fatura.FindAsync(id);
            _context.Fatura.Remove(fatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaturaExists(int id)
        {
            return _context.Fatura.Any(e => e.IdFatura == id);
        }
    }
}
