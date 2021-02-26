using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UP_Mobile.Data;
using UP_Mobile.Models;

namespace UP_Mobile.Controllers
{
    public class UtilizadoresController : Controller
    {
        private readonly UPMobileContext _context;

        public UtilizadoresController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: Utilizadores
        public async Task<IActionResult> IndexCliente(string nomePesquisar, int pagina = 1)
        {
            //var uPMobileContext = _context.Utilizador.Include(u => u.IdRoleNavigation)
            //    .Where(u=>u.IdRole==3);

            //return View(await uPMobileContext.ToListAsync());

            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Utilizador.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            //Role rolecliente = _context.Role.FirstOrDefault(r => r.Nome == "Cliente");

            List<Utilizador> utilizador = await _context.Utilizador.Where(p => (nomePesquisar == null || p.Nome.Contains(nomePesquisar)) && (p.IdRole == 3))
                .Include(u => u.IdRoleNavigation)
                .OrderBy(p => p.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();


            ListaUtilizadoresViewModel modelo = new ListaUtilizadoresViewModel
            {
                Paginacao = paginacao,
                Utilizador = utilizador,
                NomePesquisar = nomePesquisar
            };



            return View(modelo);


        }

        public async Task<IActionResult> IndexOperador(string nomePesquisar, int pagina = 1)
        {
            //var uPMobileContext = _context.Utilizador.Include(u => u.IdRoleNavigation)
            //    .Where(u=>u.IdRole==3);

            //return View(await uPMobileContext.ToListAsync());

            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Utilizador.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            //Role rolecliente = _context.Role.FirstOrDefault(r => r.Nome == "Cliente");

            List<Utilizador> utilizador = await _context.Utilizador.Where(p => (nomePesquisar == null || p.Nome.Contains(nomePesquisar)) && (p.IdRole == 3))
                .Include(u => u.IdRoleNavigation)
                .OrderBy(p => p.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();


            ListaUtilizadoresViewModel modelo = new ListaUtilizadoresViewModel
            {
                Paginacao = paginacao,
                Utilizador = utilizador,
                NomePesquisar = nomePesquisar
            };



            return View(modelo);


        }

        // GET: Utilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizador
                .Include(u => u.IdRoleNavigation)
                .FirstOrDefaultAsync(m => m.IdUtilizador == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            if (utilizador.Ativo == true)
            {
                ViewBag.Ativo = "Utilizador Ativo";
            }
            else
            {
                ViewBag.Ativo = "Utilizador Inativo";
            }

            return View(utilizador);
        }

        // GET: Utilizadores/Create
        public IActionResult CreateCliente()
        {
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "Nome");
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCliente([Bind("IdUtilizador,Nome,DataNascimento,Morada,Contacto,Email,NContribuinte,NIdentificacao,Ativo,LocalTrabalho")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                utilizador.IdRole = 3;
                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexCliente));
            }
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "Nome", utilizador.IdRole);
            return View(utilizador);
        }

        // GET: Utilizadores/Create
        public IActionResult CreateOperador()
        {
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "Nome");
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOperador([Bind("IdUtilizador,Nome,DataNascimento,Morada,Contacto,Email,NContribuinte,NIdentificacao,Ativo,LocalTrabalho")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                utilizador.IdRole = 2;
                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexOperador));
            }
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "Nome", utilizador.IdRole);
            return View(utilizador);
        }

        // GET: Utilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizador.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "Nome", utilizador.IdRole);
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUtilizador,Nome,DataNascimento,Morada,Contacto,Email,NContribuinte,NIdentificacao,Ativo,LocalTrabalho, IdRole")] Utilizador utilizador)
        {
            if (id != utilizador.IdUtilizador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadorExists(utilizador.IdUtilizador))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                var role = utilizador.IdRole;

                if (role == 3) 
                {
                    return RedirectToAction(nameof(IndexCliente));
                }else if(role == 2) 
                {
                    return RedirectToAction(nameof(IndexOperador));
                }
                
            }
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "Nome", utilizador.IdRole);
            return View(utilizador);
        }

        // GET: Utilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizador
                .Include(u => u.IdRoleNavigation)
                .FirstOrDefaultAsync(m => m.IdUtilizador == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizador = await _context.Utilizador.FindAsync(id);
            _context.Utilizador.Remove(utilizador);
            await _context.SaveChangesAsync();

            var role = utilizador.IdRole;

            if (role == 3)
            {
                return RedirectToAction(nameof(IndexCliente));
            }
            else if (role == 2)
            {
                return RedirectToAction(nameof(IndexOperador));
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadorExists(int id)
        {
            return _context.Utilizador.Any(e => e.IdUtilizador == id);
        }
    }
}
