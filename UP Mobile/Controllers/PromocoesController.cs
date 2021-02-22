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
    public class PromocoesController : Controller
    {
        private readonly UPMobileContext _context;

        public PromocoesController(UPMobileContext context)
        {
            _context = context;
        }

        // GET: Promocoes
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Promocao.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Promocao> Promocao = await _context.Promocao.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))

                .OrderBy(p => p.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaPromocoesViewModel modelo = new ListaPromocoesViewModel
            {
                Paginacao = paginacao,
                Promocao = Promocao,
                NomePesquisar = nomePesquisar
            };



            return View(modelo);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Promocoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocao
                .FirstOrDefaultAsync(m => m.IdPromocao == id);
            if (promocao == null)
            {
                return View("Inexistente");
            }

            return View(promocao);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Promocoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promocoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPromocao,Nome,Descricao,DataInicio,DataFim,Preco,Conteudo")] Promocao promocao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promocao);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Promoção adicionada com sucesso.";
                return View("Sucesso");
            }
            return View(promocao);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Promocoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocao.FindAsync(id);
            if (promocao == null)
            {
                return View("Inexistente");
            }
            return View(promocao);
        }

        // POST: Promocoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPromocao,Nome,Descricao,DataInicio,DataFim,Preco,Conteudo")] Promocao promocao)
        {
            if (id != promocao.IdPromocao)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(promocao);
            }
            try
            {
                _context.Update(promocao);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromocaoExists(promocao.IdPromocao))
                {
                    return View("EliminarInserir", promocao);
                }
                else
                {
                    ModelState.AddModelError("", "Ocorreu um erro. Não foi possível guardar a Promoção. Tente novamente e se o problema persistir contacte a assistência.");
                    return View(promocao);
                }
            }

            ViewBag.Mensagem = "Promoção alterada com sucesso";
            return View("Sucesso");

        }

        [Authorize(Roles = "Administrador")]
        // GET: Promocoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocao
                .FirstOrDefaultAsync(m => m.IdPromocao == id);
            if (promocao == null)
            {
                ViewBag.Mensagem = "A promoção que estava a tentar apagar foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(promocao);
        }

        // POST: Promocoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocao = await _context.Promocao.FindAsync(id);
            _context.Promocao.Remove(promocao);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "A Promoção foi eliminada com sucesso";
            return View("Sucesso");
        }

        private bool PromocaoExists(int id)
        {
            return _context.Promocao.Any(e => e.IdPromocao == id);
        }
    }
}
