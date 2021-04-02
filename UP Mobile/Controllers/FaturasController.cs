using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCore_Email.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UP_Mobile.Data;
using UP_Mobile.Models;

namespace UP_Mobile.Controllers
{
    public class FaturasController : Controller
    {
        private readonly UPMobileContext _context;
        private readonly IEmailSender _emailSender;

        public FaturasController(UPMobileContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        // GET: Faturas
        public async Task<IActionResult> Index()
        {
            var uPMobileContext = _context.Fatura.Include(f => f.IdContratoNavigation);
            return View(await uPMobileContext.ToListAsync());
        }

        // GET: Faturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fatura = await _context.Fatura
                .Include(f => f.IdContratoNavigation)
                .FirstOrDefaultAsync(m => m.IdFatura == id);
            if (fatura == null)
            {
                return NotFound();
            }

            return View(fatura);
        }

        // GET: Faturas/Create
        public IActionResult Create()
        {
            ViewData["IdContrato"] = new SelectList(_context.Contrato, "IdContrato", "MoradaFaturacao");
            return View();
        }

        // POST: Faturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFatura,IdContrato,Data,DataLimitePagamento,Descricao,PrecoTotal")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdContrato"] = new SelectList(_context.Contrato, "IdContrato", "MoradaFaturacao", fatura.IdContrato);
            return View(fatura);
        }

        public IActionResult CriarFaturas()
        {

            return View();
        }

        // POST: Faturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarFaturas(FaturacaoViewModel faturacao)
        {
            if (ModelState.IsValid)
            {
                var verificadata = faturacao.Data.Month;

                if (!DataFaturaExists(verificadata))

                {

                    foreach (var contrato in _context.Contrato.ToList())
                    {

                        Fatura fatura = new Fatura
                        {
                            IdContrato = contrato.IdContrato,
                            Data = faturacao.Data,
                            DataLimitePagamento = faturacao.Data.AddDays(15),
                            Descricao = "Fatura referente ao Contrato nº " + contrato.IdContrato,
                            PrecoTotal = contrato.PrecoTotal

                        };
                        _context.Add(fatura);
                        await _context.SaveChangesAsync();
                        var cliente = _context.Utilizador.SingleOrDefault(c => c.IdUtilizador == contrato.IdCliente);
                        var emailcliente = cliente.Email;
                        var assunto = ": "+fatura.Descricao;
                        var mensagem = "O valor da sua fatura de " + fatura.Data + " é de " + fatura.PrecoTotal + " Euros. " +
                            "O seu pagamento deve ser realizado até " + fatura.DataLimitePagamento;
                        await _emailSender.SendEmailAsync(emailcliente, assunto, mensagem);
                    }
                    ViewBag.Mensagem = "Faturas geradas e anviado email para o Cliente com sucesso.";
                    return View("Sucesso");
                }
                

                ModelState.AddModelError("Data", "Já existe faturação para esse mês");

            }




            return View(faturacao);
        }





        // GET: Faturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fatura = await _context.Fatura.FindAsync(id);
            if (fatura == null)
            {
                return NotFound();
            }
            ViewData["IdContrato"] = new SelectList(_context.Contrato, "IdContrato", "MoradaFaturacao", fatura.IdContrato);
            return View(fatura);
        }

        // POST: Faturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFatura,IdContrato,Data,DataLimitePagamento,Descricao,PrecoTotal")] Fatura fatura)
        {
            if (id != fatura.IdFatura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaturaExists(fatura.IdFatura))
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
            ViewData["IdContrato"] = new SelectList(_context.Contrato, "IdContrato", "MoradaFaturacao", fatura.IdContrato);
            return View(fatura);
        }

        // GET: Faturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fatura = await _context.Fatura
                .Include(f => f.IdContratoNavigation)
                .FirstOrDefaultAsync(m => m.IdFatura == id);
            if (fatura == null)
            {
                return NotFound();
            }

            return View(fatura);
        }

        // POST: Faturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fatura = await _context.Fatura.FindAsync(id);
            _context.Fatura.Remove(fatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaturaExists(int id)
        {
            return _context.Fatura.Any(e => e.IdFatura == id);
        }

        private bool DataFaturaExists(int mes)
        {

            return _context.Fatura.Any(e => e.Data.Month == mes);
        }
    }
}
