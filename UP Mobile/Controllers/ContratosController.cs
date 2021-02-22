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
    public class ContratosController : Controller
    {
        private readonly UPMobileContext _context;

        public ContratosController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: Contratos
        public async Task<IActionResult> Index()
        {
            var uPMobileContext = _context.Contrato.Include(c => c.IdClienteNavigation).Include(c => c.IdOperadorNavigation).Include(c => c.IdPacoteComercialPromocaoNavigation);
            return View(await uPMobileContext.ToListAsync());
        }

        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdOperadorNavigation)
                .Include(c => c.IdPacoteComercialPromocaoNavigation)
                .FirstOrDefaultAsync(m => m.IdContrato == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // GET: Contratos/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Email");
            ViewData["IdOperador"] = new SelectList(_context.Operador, "IdOperador", "Email");
            ViewData["IdPacoteComercialPromocao"] = new SelectList(_context.PacoteComercialPromocao, "IdPacoteComercialPromocao", "IdPacoteComercialPromocao");

            //var operador = await _context.Operador.SingleOrDefaultAsync(o => o.Email == User.Identity.Name);

            //ViewBag.NomeOperador = operador.Nome;

            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContrato,IdCliente,IdOperador,IdPacoteComercialPromocao,DataInicioContrato,DataFimContrato,MoradaFaturacao,DataFidelizacao,PrecoBaseInicioContrato,PrecoTotal,ConteudoExtraTotal")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                var cliente = await _context.Cliente.FindAsync(contrato.IdCliente);
                var operador = await _context.Operador.SingleOrDefaultAsync(o => o.Email == User.Identity.Name);
                contrato.NomeCliente = cliente.Nome;
                contrato.NomeOperador = operador.Nome;


                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Email", contrato.IdCliente);
            ViewData["IdOperador"] = new SelectList(_context.Operador, "IdOperador", "Email", contrato.IdOperador);
            ViewData["IdPacoteComercialPromocao"] = new SelectList(_context.PacoteComercialPromocao, "IdPacoteComercialPromocao", "IdPacoteComercialPromocao", contrato.IdPacoteComercialPromocao);
            return View(contrato);
        }

        // GET: Contratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Email", contrato.IdCliente);
            ViewData["IdOperador"] = new SelectList(_context.Operador, "IdOperador", "Email", contrato.IdOperador);
            ViewData["IdPacoteComercialPromocao"] = new SelectList(_context.PacoteComercialPromocao, "IdPacoteComercialPromocao", "IdPacoteComercialPromocao", contrato.IdPacoteComercialPromocao);
            return View(contrato);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContrato,IdCliente,IdOperador,IdPacoteComercialPromocao,DataInicioContrato,DataFimContrato,MoradaFaturacao,DataFidelizacao,NomeCliente,NomeOperador,PrecoBaseInicioContrato,PrecoTotal,ConteudoExtraTotal")] Contrato contrato)
        {
            if (id != contrato.IdContrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExists(contrato.IdContrato))
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
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Email", contrato.IdCliente);
            ViewData["IdOperador"] = new SelectList(_context.Operador, "IdOperador", "Email", contrato.IdOperador);
            ViewData["IdPacoteComercialPromocao"] = new SelectList(_context.PacoteComercialPromocao, "IdPacoteComercialPromocao", "IdPacoteComercialPromocao", contrato.IdPacoteComercialPromocao);
            return View(contrato);
        }

        // GET: Contratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdOperadorNavigation)
                .Include(c => c.IdPacoteComercialPromocaoNavigation)
                .FirstOrDefaultAsync(m => m.IdContrato == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contrato = await _context.Contrato.FindAsync(id);
            _context.Contrato.Remove(contrato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoExists(int id)
        {
            return _context.Contrato.Any(e => e.IdContrato == id);
        }

        public async Task<IActionResult> PesquisaCliente(string nomePesquisar, int pagina = 1)
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
    }
}
