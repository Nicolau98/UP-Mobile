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
    public class PacotesComerciaisController : Controller
    {
        private readonly UPMobileContext _context;

        public PacotesComerciaisController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: PacotesComerciais
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.PacoteComercial.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<PacoteComercial> PacoteComercial = await _context.PacoteComercial.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))

                .OrderBy(p => p.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaPacotesComerciaisViewModel modelo = new ListaPacotesComerciaisViewModel
            {
                Paginacao = paginacao,
                PacoteComercial = PacoteComercial,
                NomePesquisar = nomePesquisar
            };



            return View(modelo);
        }

        // GET: PacotesComerciais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteComercial = await _context.PacoteComercial
                .FirstOrDefaultAsync(m => m.IdPacote == id);
            if (pacoteComercial == null)
            {
                return NotFound();
            }

            return View(pacoteComercial);
        }

        // GET: PacotesComerciais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PacotesComerciais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPacote,Nome,Descricao,DataInicioComercializacao,DataFimComercializacao,PrecoBase,PeriodoFidelizacao")] PacoteComercial pacoteComercial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacoteComercial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacoteComercial);
        }

        // GET: PacotesComerciais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteComercial = await _context.PacoteComercial.FindAsync(id);
            if (pacoteComercial == null)
            {
                return NotFound();
            }
            return View(pacoteComercial);
        }

        // POST: PacotesComerciais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPacote,Nome,Descricao,DataInicioComercializacao,DataFimComercializacao,PrecoBase,PeriodoFidelizacao")] PacoteComercial pacoteComercial)
        {
            if (id != pacoteComercial.IdPacote)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacoteComercial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacoteComercialExists(pacoteComercial.IdPacote))
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
            return View(pacoteComercial);
        }

        // GET: PacotesComerciais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteComercial = await _context.PacoteComercial
                .FirstOrDefaultAsync(m => m.IdPacote == id);
            if (pacoteComercial == null)
            {
                return NotFound();
            }

            return View(pacoteComercial);
        }

        // POST: PacotesComerciais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacoteComercial = await _context.PacoteComercial.FindAsync(id);
            _context.PacoteComercial.Remove(pacoteComercial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacoteComercialExists(int id)
        {
            return _context.PacoteComercial.Any(e => e.IdPacote == id);
        }
    }
}
