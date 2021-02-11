﻿using System;
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
    public class PacoteComercialPromocaoController : Controller
    {
        private readonly UPMobileContext _context;

        public PacoteComercialPromocaoController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: PacoteComercialPromocoes
        public async Task<IActionResult> Index()
        {
            var uPMobileContext = _context.PacoteComercialPromocao.Include(p => p.IdPacoteNavigation).Include(p => p.IdPromocaoNavigation);
            return View(await uPMobileContext.ToListAsync());
        }

        // GET: PacoteComercialPromocoes/Details/5
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

        // GET: PacoteComercialPromocoes/Create
        public IActionResult Create()
        {
            ViewData["IdPacote"] = new SelectList(_context.PacoteComercial, "IdPacote", "Descricao");
            ViewData["IdPromocao"] = new SelectList(_context.Promocao, "IdPromocao", "Descricao");
            return View();
        }

        // POST: PacoteComercialPromocoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPacoteComercialPromocao,IdPromocao,IdPacote")] PacoteComercialPromocao pacoteComercialPromocao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacoteComercialPromocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPacote"] = new SelectList(_context.PacoteComercial, "IdPacote", "Descricao", pacoteComercialPromocao.IdPacote);
            ViewData["IdPromocao"] = new SelectList(_context.Promocao, "IdPromocao", "Descricao", pacoteComercialPromocao.IdPromocao);
            return View(pacoteComercialPromocao);
        }

        // GET: PacoteComercialPromocoes/Edit/5
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
            ViewData["IdPacote"] = new SelectList(_context.PacoteComercial, "IdPacote", "Descricao", pacoteComercialPromocao.IdPacote);
            ViewData["IdPromocao"] = new SelectList(_context.Promocao, "IdPromocao", "Descricao", pacoteComercialPromocao.IdPromocao);
            return View(pacoteComercialPromocao);
        }

        // POST: PacoteComercialPromocoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPacoteComercialPromocao,IdPromocao,IdPacote")] PacoteComercialPromocao pacoteComercialPromocao)
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
            ViewData["IdPacote"] = new SelectList(_context.PacoteComercial, "IdPacote", "Descricao", pacoteComercialPromocao.IdPacote);
            ViewData["IdPromocao"] = new SelectList(_context.Promocao, "IdPromocao", "Descricao", pacoteComercialPromocao.IdPromocao);
            return View(pacoteComercialPromocao);
        }

        // GET: PacoteComercialPromocoes/Delete/5
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

        // POST: PacoteComercialPromocoes/Delete/5
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
