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
    public class ConteudosExtrasController : Controller
    {
        private readonly UPMobileContext _context;

        public ConteudosExtrasController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: ConteudosExtras
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConteudoExtra.ToListAsync());
        }

        // GET: ConteudosExtras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteudoExtra = await _context.ConteudoExtra
                .FirstOrDefaultAsync(m => m.IdConteudo == id);
            if (conteudoExtra == null)
            {
                return NotFound();
            }

            return View(conteudoExtra);
        }

        // GET: ConteudosExtras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConteudosExtras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConteudo,Nome,Descricao,DataInicioComercializacao,DataFimComercializacao,Preco")] ConteudoExtra conteudoExtra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conteudoExtra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conteudoExtra);
        }

        // GET: ConteudosExtras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteudoExtra = await _context.ConteudoExtra.FindAsync(id);
            if (conteudoExtra == null)
            {
                return NotFound();
            }
            return View(conteudoExtra);
        }

        // POST: ConteudosExtras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConteudo,Nome,Descricao,DataInicioComercializacao,DataFimComercializacao,Preco")] ConteudoExtra conteudoExtra)
        {
            if (id != conteudoExtra.IdConteudo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conteudoExtra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteudoExtraExists(conteudoExtra.IdConteudo))
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
            return View(conteudoExtra);
        }

        // GET: ConteudosExtras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteudoExtra = await _context.ConteudoExtra
                .FirstOrDefaultAsync(m => m.IdConteudo == id);
            if (conteudoExtra == null)
            {
                return NotFound();
            }

            return View(conteudoExtra);
        }

        // POST: ConteudosExtras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conteudoExtra = await _context.ConteudoExtra.FindAsync(id);
            _context.ConteudoExtra.Remove(conteudoExtra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConteudoExtraExists(int id)
        {
            return _context.ConteudoExtra.Any(e => e.IdConteudo == id);
        }
    }
}
