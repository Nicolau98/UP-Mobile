﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            return View(await _context.PacoteComercial.ToListAsync());
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
                return View("Inexistente");
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
        public async Task<IActionResult> Create([Bind("IdPacote,Nome,Descricao,DataInicioComercializacao,DataFimComercializacao,PrecoBase,PeriodoFidelizacao,Ativo,Internet,Voz,Tv,Movel")] PacoteComercial pacoteComercial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacoteComercial);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Pacote Comercial adicionado com sucesso.";
                return View("Sucesso");
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
                return View("Inexistente");
            }
            return View(pacoteComercial);
        }

        // POST: PacotesComerciais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPacote,Nome,Descricao,DataInicioComercializacao,DataFimComercializacao,PrecoBase,PeriodoFidelizacao,Ativo,Internet,Voz,Tv,Movel")] PacoteComercial pacoteComercial)
        {
            if (id != pacoteComercial.IdPacote)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(pacoteComercial);
            }
                try
                {
                    _context.Update(pacoteComercial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacoteComercialExists(pacoteComercial.IdPacote))
                    {
                      return View("EliminarInserir", pacoteComercial);
                      }
                
                    else
                    {
                    ModelState.AddModelError("", "Ocorreu um erro. Não foi possível guardar o Pacote Comercial. Tente novamente e se o problema persistir contacte a assistência.");
                    return View(pacoteComercial);
                }
                }
            ViewBag.Mensagem = "Pacote Comercial alterado com sucesso";
            return View("Sucesso");
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
                ViewBag.Mensagem = "O Pacote Comercial que estava a tentar apagar foi eliminado por outra pessoa.";
                return View("Sucesso");
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

            ViewBag.Mensagem = "O Pacote Comercial foi eliminado com sucesso";
            return View("Sucesso");
        }

        private bool PacoteComercialExists(int id)
        {
            return _context.PacoteComercial.Any(e => e.IdPacote == id);
        }
    }
}
