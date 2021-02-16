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
    
    public class ClientesController : Controller
    {
        private readonly UPMobileContext _context;

        public ClientesController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Cliente.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Cliente> Cliente = await _context.Cliente.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
    
                .OrderBy(p => p.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaClientesViewModel modelo = new ListaClientesViewModel
            {
                Paginacao = paginacao,
                Cliente = Cliente,
                NomePesquisar = nomePesquisar
            };



            return View(modelo);
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return View("Inexistente");
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,Nome,DataNascimento,Morada,Contacto,Email,NContribuinte,NIdentificacao")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Cliente adicionado com sucesso.";
                return View("Sucesso");
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return View("Inexistente");
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,Nome,DataNascimento,Morada,Contacto,Email,NContribuinte,NIdentificacao")] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.IdCliente))
                    {
                        return View("EliminarInserir", cliente);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ocorreu um erro. Não foi possível guardar o Cliente. Tente novamente e se o problema persistir contacte a assistência.");
                        return View(cliente);
                    }
                }

                ViewBag.Mensagem = "Cliente alterado com sucesso";
                return View("Sucesso");

        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                ViewBag.Mensagem = "O Cliente que estava a tentar apagar foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "O Cliente foi eliminado com sucesso";
            return View("Sucesso");
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.IdCliente == id);
        }
    }
}
