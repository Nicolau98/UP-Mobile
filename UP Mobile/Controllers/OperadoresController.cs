using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UP_Mobile.Data;
using UP_Mobile.Models;

namespace UP_Mobile.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class OperadoresController : Controller
    {
        private readonly UPMobileContext _context;

        public OperadoresController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: Operadores
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Operador.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Operador> Operador = await _context.Operador.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))

                .OrderBy(p => p.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaOperadoresViewModel modelo = new ListaOperadoresViewModel
            {
                Paginacao = paginacao,
                Operador = Operador,
                NomePesquisar = nomePesquisar
            };

            return View(modelo);
        }

        // GET: Operadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operador = await _context.Operador
                .FirstOrDefaultAsync(m => m.IdOperador == id);
            if (operador == null)
            {
                return NotFound();
            }

            if (operador.OperadorAtivo == true)
            {
                ViewBag.Mensagem = "Operador ativo";
            }
            else
            {
                ViewBag.Mensagem = "Operador inativo";
            }
            
            return View(operador);
        }

        // GET: Operadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOperador,Nome,DataNascimento,Morada,Contacto,Email,LocalTrabalho,OperadorAtivo")] Operador operador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operador);
        }

        // GET: Operadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operador = await _context.Operador.FindAsync(id);
            if (operador == null)
            {
                return NotFound();
            }
            return View(operador);
        }

        // POST: Operadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOperador,Nome,DataNascimento,Morada,Contacto,Email,LocalTrabalho,OperadorAtivo")] Operador operador)
        {
            if (id != operador.IdOperador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperadorExists(operador.IdOperador))
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
            return View(operador);
        }

        // GET: Operadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operador = await _context.Operador
                .FirstOrDefaultAsync(m => m.IdOperador == id);
            if (operador == null)
            {
                return NotFound();
            }

            return View(operador);
        }

        // POST: Operadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operador = await _context.Operador.FindAsync(id);
            _context.Operador.Remove(operador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperadorExists(int id)
        {
            return _context.Operador.Any(e => e.IdOperador == id);
        }
    }
}
