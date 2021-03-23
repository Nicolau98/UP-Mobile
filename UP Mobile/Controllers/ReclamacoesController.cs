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
    public class ReclamacoesController : Controller
    {
        private readonly UPMobileContext _context;

        public ReclamacoesController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: Reclamacoes
        public async Task<IActionResult> Index()
        {
            var uPMobileContext = _context.Reclamacao.Include(r => r.IdClienteNavigation).Include(r => r.IdEstadoNavigation).Include(r => r.IdOperadorNavigation);
            return View(await uPMobileContext.ToListAsync());
        }

        // GET: Reclamacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamacao
                .Include(r => r.IdClienteNavigation)
                .Include(r => r.IdEstadoNavigation)
                .Include(r => r.IdOperadorNavigation)
                .FirstOrDefaultAsync(m => m.IdReclamacao == id);
            if (reclamacao == null)
            {
                return NotFound();
            }

            return View(reclamacao);
        }

        // GET: Reclamacoes/Create
        public IActionResult Create(int? id)
        {
            ViewData["IdCliente"] = id;

            //ViewData["IdCliente"] = new SelectList(_context.Utilizador, "IdUtilizador", "Contacto");
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "Nome");
            ViewData["IdOperador"] = new SelectList(_context.Utilizador, "IdUtilizador", "Contacto");
            return View();
        }

        // POST: Reclamacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReclamacao,IdCliente,Assunto,Descricao")] Reclamacao reclamacao)
        {
            if (ModelState.IsValid)
            {
                Estado estadoaberto = _context.Estado.FirstOrDefault(e => e.Nome == "Em Aberto");

                reclamacao.IdEstadoNavigation = estadoaberto;
                reclamacao.DataAbertura = System.DateTime.Now;

                _context.Add(reclamacao);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Reclamação criada com sucesso.";
                return View("Sucesso");
            }
            ViewData["IdCliente"] = new SelectList(_context.Utilizador, "IdUtilizador", "Contacto", reclamacao.IdCliente);
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "Nome", reclamacao.IdEstado);
            ViewData["IdOperador"] = new SelectList(_context.Utilizador, "IdUtilizador", "Contacto", reclamacao.IdOperador);
            return View(reclamacao);
        }

        // GET: Reclamacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamacao.FindAsync(id);
            if (reclamacao == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Utilizador, "IdUtilizador", "Contacto", reclamacao.IdCliente);
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "Nome", reclamacao.IdEstado);
            ViewData["IdOperador"] = new SelectList(_context.Utilizador, "IdUtilizador", "Contacto", reclamacao.IdOperador);
            return View(reclamacao);
        }

        // POST: Reclamacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReclamacao,IdCliente,IdOperador,DataAbertura,Assunto,Descricao,IdEstado,DataResolucao,Resolucao")] Reclamacao reclamacao)
        {
            if (id != reclamacao.IdReclamacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reclamacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclamacaoExists(reclamacao.IdReclamacao))
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
            ViewData["IdCliente"] = new SelectList(_context.Utilizador, "IdUtilizador", "Contacto", reclamacao.IdCliente);
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "Nome", reclamacao.IdEstado);
            ViewData["IdOperador"] = new SelectList(_context.Utilizador, "IdUtilizador", "Contacto", reclamacao.IdOperador);
            return View(reclamacao);
        }

        // GET: Reclamacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamacao
                .Include(r => r.IdClienteNavigation)
                .Include(r => r.IdEstadoNavigation)
                .Include(r => r.IdOperadorNavigation)
                .FirstOrDefaultAsync(m => m.IdReclamacao == id);
            if (reclamacao == null)
            {
                return NotFound();
            }

            return View(reclamacao);
        }

        // POST: Reclamacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reclamacao = await _context.Reclamacao.FindAsync(id);
            _context.Reclamacao.Remove(reclamacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReclamacaoExists(int id)
        {
            return _context.Reclamacao.Any(e => e.IdReclamacao == id);
        }
    }
}
