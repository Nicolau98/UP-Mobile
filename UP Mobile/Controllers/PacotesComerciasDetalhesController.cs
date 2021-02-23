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
    public class PacotesComerciasDetalhesController : Controller
    {
        private readonly UPMobileContext _context;

        public PacotesComerciasDetalhesController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: PacotesComerciasDetalhes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PacoteComercialDetalhes.ToListAsync());
        }

        // GET: PacotesComerciasDetalhes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteComercialDetalhes = await _context.PacoteComercialDetalhes
                .FirstOrDefaultAsync(m => m.IdPacoteComercialDetalhes == id);
            if (pacoteComercialDetalhes == null)
            {
                return NotFound();
            }

            return View(pacoteComercialDetalhes);
        }

        // GET: PacotesComerciasDetalhes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PacotesComerciasDetalhes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPacoteComercialDetalhes,Internet,Tv,Voz,Movel")] PacoteComercialDetalhes pacoteComercialDetalhes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacoteComercialDetalhes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacoteComercialDetalhes);
        }

        // GET: PacotesComerciasDetalhes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteComercialDetalhes = await _context.PacoteComercialDetalhes.FindAsync(id);
            if (pacoteComercialDetalhes == null)
            {
                return NotFound();
            }
            return View(pacoteComercialDetalhes);
        }

        // POST: PacotesComerciasDetalhes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPacoteComercialDetalhes,Internet,Tv,Voz,Movel")] PacoteComercialDetalhes pacoteComercialDetalhes)
        {
            if (id != pacoteComercialDetalhes.IdPacoteComercialDetalhes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacoteComercialDetalhes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacoteComercialDetalhesExists(pacoteComercialDetalhes.IdPacoteComercialDetalhes))
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
            return View(pacoteComercialDetalhes);
        }

        // GET: PacotesComerciasDetalhes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteComercialDetalhes = await _context.PacoteComercialDetalhes
                .FirstOrDefaultAsync(m => m.IdPacoteComercialDetalhes == id);
            if (pacoteComercialDetalhes == null)
            {
                return NotFound();
            }

            return View(pacoteComercialDetalhes);
        }

        // POST: PacotesComerciasDetalhes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacoteComercialDetalhes = await _context.PacoteComercialDetalhes.FindAsync(id);
            _context.PacoteComercialDetalhes.Remove(pacoteComercialDetalhes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacoteComercialDetalhesExists(int id)
        {
            return _context.PacoteComercialDetalhes.Any(e => e.IdPacoteComercialDetalhes == id);
        }
    }
}
