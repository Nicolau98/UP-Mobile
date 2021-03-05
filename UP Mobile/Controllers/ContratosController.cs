﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index(int? id)
        {
            var contrato = await _context.Contrato.Where(c=> c.IdCliente == id)
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdOperadorNavigation)
                .Include(c => c.IdPacoteComercialPromocaoNavigation)
                .ToListAsync();
            var pp = _context.PacoteComercialPromocao.Include(c => c.IdPacoteNavigation).Select(p => new { p.IdPacoteComercialPromocao, Nome = p.IdPacoteNavigation.Nome + "/" + p.IdPromocaoNavigation.Nome });

            ViewData["IdPacoteComercialPromocao"] = new SelectList(pp, "IdPacoteComercialPromocao", "Nome");

            return View(contrato);
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
        public async Task<IActionResult> Create(int? id)
        {
            ViewData["IdCliente"] = id;
            ViewData["IdOperador"] = new SelectList(_context.Utilizador, "IdUtilizador", "Email");

            var pp = _context.PacoteComercialPromocao.Include(c => c.IdPacoteNavigation).Select(p => new { p.IdPacoteComercialPromocao, Nome = p.IdPacoteNavigation.Nome + "/" + p.IdPromocaoNavigation.Nome });

            ViewData["IdPacoteComercialPromocao"] = new SelectList(pp, "IdPacoteComercialPromocao", "Nome");


            var operador = await _context.Utilizador.SingleOrDefaultAsync(o => o.Email == User.Identity.Name);

            ViewBag.NomeOperador = operador.Nome;e;

            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContrato,IdCliente,IdPacoteComercialPromocao,DataInicioContrato,MoradaFaturacao,DataFidelizacao,PrecoBaseInicioContrato")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                
                var operador = await _context.Utilizador.SingleOrDefaultAsync(o => o.Email == User.Identity.Name);

                var pacotepromocao = await _context.PacoteComercialPromocao.FindAsync(contrato.IdPacoteComercialPromocao);

                var pacote= await _context.PacoteComercial.FindAsync(pacotepromocao.IdPacote);

                int data = pacote.PeriodoFidelizacao;

                contrato.DataFidelizacao = contrato.DataInicioContrato.AddMonths(data);
                contrato.PrecoBaseInicioContrato = pacotepromocao.PrecoTotalPacote;
                contrato.PrecoTotal = pacotepromocao.PrecoTotalPacote;
                contrato.IdOperador = operador.IdUtilizador;
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                var cliente = contrato.IdCliente;
                return RedirectToAction("Details", "Utilizadores", new { id = cliente });
            }
            ViewData["IdCliente"] = new SelectList(_context.Utilizador, "IdUtilizador", "Email", contrato.IdCliente);
            ViewData["IdOperador"] = new SelectList(_context.Utilizador, "IdUtilizador", "Email", contrato.IdOperador);
            ViewData["IdPacoteComercialPromocao"] = new SelectList(_context.PacoteComercialPromocao.Include(c => c.IdPacoteNavigation), "IdPacoteComercialPromocao", "Nome", contrato.IdPacoteComercialPromocao);
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
            ViewData["IdCliente"] = new SelectList(_context.Utilizador, "IdCliente", "Email", contrato.IdCliente);
            ViewData["IdOperador"] = new SelectList(_context.Utilizador, "IdOperador", "Email", contrato.IdOperador);
            ViewData["IdPacoteComercialPromocao"] = new SelectList(_context.PacoteComercialPromocao, "IdPacoteComercialPromocao", "Nome", contrato.IdPacoteComercialPromocao);
            return View(contrato);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContrato,IdCliente, IdOperador, IdPacoteComercialPromocao,DataInicioContrato,DataFimContrato,MoradaFaturacao,DataFidelizacao,PrecoBaseInicioContrato")] Contrato contrato)
        {
            if (id != contrato.IdContrato)
            {
                return NotFound();
            }
            var pacotepromocao = await _context.PacoteComercialPromocao.FindAsync(contrato.IdPacoteComercialPromocao);

            if (ModelState.IsValid)
            {
                try
                {
                    contrato.PrecoTotal = pacotepromocao.PrecoTotalPacote;
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
                var cliente = contrato.IdCliente;
                return RedirectToAction("Index", "Contratos", new { id = cliente });
            }
            ViewData["IdCliente"] = new SelectList(_context.Utilizador, "IdCliente", "Email", contrato.IdCliente);
            ViewData["IdOperador"] = new SelectList(_context.Utilizador, "IdOperador", "Email", contrato.IdOperador);
            ViewData["IdPacoteComercialPromocao"] = new SelectList(_context.PacoteComercialPromocao, "IdPacoteComercialPromocao", "Nome", contrato.IdPacoteComercialPromocao);
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
            var cliente = id;
            var contrato = await _context.Contrato.FindAsync(id);
            _context.Contrato.Remove(contrato);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Details", "Utilizadores", new { id = cliente });
        }

        private bool ContratoExists(int id)
        {
            return _context.Contrato.Any(e => e.IdContrato == id);

        }


        // GET: Contratos/Terminar/5
        public async Task<IActionResult> Terminar(int? id)
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
            ViewData["IdCliente"] = new SelectList(_context.Utilizador, "IdCliente", "Email", contrato.IdCliente);
            ViewData["IdOperador"] = new SelectList(_context.Utilizador, "IdOperador", "Email", contrato.IdOperador);
            ViewData["IdPacoteComercialPromocao"] = new SelectList(_context.PacoteComercialPromocao, "IdPacoteComercialPromocao", "Nome", contrato.IdPacoteComercialPromocao);
            return View(contrato);
        }

        // POST: Contratos/Terminar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Terminar(int id, [Bind("IdContrato,IdCliente, IdOperador, IdPacoteComercialPromocao,DataInicioContrato,DataFimContrato,MoradaFaturacao,DataFidelizacao,PrecoBaseInicioContrato, PrecoTotal")] Contrato contrato)
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
                var cliente = contrato.IdCliente;
                return RedirectToAction("Index", "Contratos", new { id = cliente });
            }
            ViewData["IdCliente"] = new SelectList(_context.Utilizador, "IdCliente", "Email", contrato.IdCliente);
            ViewData["IdOperador"] = new SelectList(_context.Utilizador, "IdOperador", "Email", contrato.IdOperador);
            ViewData["IdPacoteComercialPromocao"] = new SelectList(_context.PacoteComercialPromocao, "IdPacoteComercialPromocao", "Nome", contrato.IdPacoteComercialPromocao);
            return View(contrato);
        }











        //public async Task<IActionResult> PesquisaCliente(string nomePesquisar, int pagina = 1)
        //{
        //    //Paginacao paginacao = new Paginacao
        //    //{
        //    //    TotalItems = await _context.Utilizador.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
        //    //    PaginaAtual = pagina
        //    //};

        //    //List<Utilizador> Cliente = await _context.Utilizador.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))

        //    //    .OrderBy(p => p.Nome)
        //    //    .Skip(paginacao.ItemsPorPagina * (pagina - 1))
        //    //    .Take(paginacao.ItemsPorPagina)
        //    //    .ToListAsync();

        //    //ListaClientesViewModel modelo = new ListaClientesViewModel
        //    //{
        //    //    Paginacao = paginacao,
        //    //    Cliente = Cliente,
        //    //    NomePesquisar = nomePesquisar
        //    //};



        //    return View(modelo);
        //}
    }
}
