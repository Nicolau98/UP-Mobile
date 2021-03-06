﻿using Microsoft.AspNetCore.Mvc;
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
            var UPMobileContext = _context.PacoteComercialPromocao.Include(p => p.IdPacoteNavigation).Include(p => p.IdPromocaoNavigation).Include(p => p.IdDistritoNavigation);
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
                .Include(p => p.IdDistritoNavigation)
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
            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome");
            return View();
        }

        // POST: PacotesComerciaisPromocao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPacoteComercialPromocao,IdPromocao,IdPacote,IdDistrito")] PacoteComercialPromocao pacoteComercialPromocao)
        {
            if (ModelState.IsValid)
            {
                var promocao = await _context.Promocao.FindAsync(pacoteComercialPromocao.IdPromocao);
                var pacote = await _context.PacoteComercial.FindAsync(pacoteComercialPromocao.IdPacote);
                
                
                pacoteComercialPromocao.Nome = pacote.Nome +" / " + promocao.Nome;
                pacoteComercialPromocao.PrecoTotalPacote = pacote.PrecoBase - promocao.Preco;

                _context.Add(pacoteComercialPromocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPacote"] = new SelectList(_context.PacoteComercial, "IdPacote", "Nome", pacoteComercialPromocao.IdPacote);
            ViewData["IdPromocao"] = new SelectList(_context.Promocao, "IdPromocao", "Nome", pacoteComercialPromocao.IdPromocao);
            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome");
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
            //var distritoid = pacoteComercialPromocao.IdDistrito;
            
            //var ditritos = await _context.Distrito.FindAsync(distritoid);
            //var distrito = ditritos.Nome;
            if (pacoteComercialPromocao == null)
            {
                return NotFound();
            }
            ViewData["IdPacote"] = new SelectList(_context.PacoteComercial, "IdPacote", "Nome", pacoteComercialPromocao.IdPacote);
            ViewData["IdPromocao"] = new SelectList(_context.Promocao, "IdPromocao", "Nome", pacoteComercialPromocao.IdPromocao);
            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome", pacoteComercialPromocao.IdDistrito);
            //ViewData["Distrito"] = distrito;
            return View(pacoteComercialPromocao);
        }

        // POST: PacotesComerciaisPromocao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPacoteComercialPromocao,IdPromocao,IdPacote, IdDistrito")] PacoteComercialPromocao pacoteComercialPromocao)
        {
            if (id != pacoteComercialPromocao.IdPacoteComercialPromocao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var promocao = await _context.Promocao.FindAsync(pacoteComercialPromocao.IdPromocao);
                    var pacote = await _context.PacoteComercial.FindAsync(pacoteComercialPromocao.IdPacote);
                    //var pacoteComProm = pacoteComercialPromocao.IdDistrito;

                    pacoteComercialPromocao.Nome = pacote.Nome + " / " + promocao.Nome;
                    pacoteComercialPromocao.PrecoTotalPacote = pacote.PrecoBase - promocao.Preco;
                    //pacoteComercialPromocao.IdDistrito = pacoteComProm;
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
            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome", pacoteComercialPromocao.IdDistrito);
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
                .Include(p => p.IdDistritoNavigation)
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
