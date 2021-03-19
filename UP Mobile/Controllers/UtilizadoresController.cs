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
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Utilizador.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            if (nomePesquisar == null)
            {

                List<Utilizador> utilizador1 = await _context.Utilizador.Where(p => p.Nome == null)
                    .ToListAsync();

                ListaUtilizadoresViewModel modelo1 = new ListaUtilizadoresViewModel
                {
                    Paginacao = paginacao,
                    Utilizador = utilizador1,
                    NomePesquisar = nomePesquisar
                };


                return View(modelo1);

            }


            Role roleoperador = _context.Role.FirstOrDefault(r => r.Nome == "Cliente");

            List<Utilizador> utilizador = await _context.Utilizador.Where(p => (p.Nome.Contains(nomePesquisar) || p.NContribuinte.Contains(nomePesquisar)) && (p.IdRoleNavigation == roleoperador))
                .Include(u => u.IdRoleNavigation)
                .Include(d => d.IdDistritoNavigation)
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

            if (nomePesquisar == null)
            {

                List<Utilizador> utilizador1 = await _context.Utilizador.Where(p => p.Nome == null)
                    .ToListAsync();

                ListaUtilizadoresViewModel modelo1 = new ListaUtilizadoresViewModel
                {
                    Paginacao = paginacao,
                    Utilizador = utilizador1,
                    NomePesquisar = nomePesquisar
                };


                return View(modelo1);

            }


            Role roleoperador = _context.Role.FirstOrDefault(r => r.Nome == "Operador");

            List<Utilizador> utilizador = await _context.Utilizador.Where(p => (p.Nome.Contains(nomePesquisar) || p.NContribuinte.Contains(nomePesquisar)) && (p.IdRoleNavigation == roleoperador))
                .Include(u => u.IdRoleNavigation)
                .Include(d => d.IdDistritoNavigation)
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


        public async Task<IActionResult> PesquisaClienteDistrito(int distritopesquisar=0, int pagina = 1)

        {

            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome");

            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Utilizador.Where(p => p.IdDistrito == distritopesquisar).CountAsync(),
                PaginaAtual = pagina
            };

            if (distritopesquisar == 0)
            {

                List<Utilizador> utilizador1 = await _context.Utilizador.Where(p => p.Nome == null)
                    .ToListAsync();

                ListaPesquisaViewModel modelo1 = new ListaPesquisaViewModel
                {
                    Paginacao = paginacao,
                    Utilizador = utilizador1,
                    DistritoPesquisar = distritopesquisar
                };


                return View(modelo1);

            }


            Role rolecliente = _context.Role.FirstOrDefault(r => r.Nome == "Cliente");

            List<Utilizador> utilizador = await _context.Utilizador.Where(p => (p.IdDistrito.Equals(distritopesquisar)) && (p.IdRoleNavigation == rolecliente))
                .Include(u => u.IdRoleNavigation)
                .Include(d => d.IdDistritoNavigation)
                .OrderBy(p => p.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();


            ListaPesquisaViewModel modelo = new ListaPesquisaViewModel
            {
                Paginacao = paginacao,
                Utilizador = utilizador,
                DistritoPesquisar = distritopesquisar
            };



            return View(modelo);


        }

        public async Task<IActionResult> ClienteDistritoMaisAntigo(int distritopesquisar = 0, int pagina = 1)

        {

            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome");


            if (distritopesquisar == 0)
            {

                List<Utilizador> utilizador1 = await _context.Utilizador.Where(p => p.Nome == null)
                    .ToListAsync();

                ListaMaisAntigosViewModel modelo1 = new ListaMaisAntigosViewModel
                {
                    
                    Utilizador = utilizador1,
                    DistritoPesquisar = distritopesquisar
                };


                return View(modelo1);

            }


            Role roleoperador = _context.Role.FirstOrDefault(r => r.Nome == "Cliente");

            List<Utilizador> utilizador = await _context.Utilizador.Where(p => (p.IdDistrito.Equals(distritopesquisar)) && (p.IdRoleNavigation == roleoperador))
                .Include(u => u.IdRoleNavigation)
                .Include(d => d.IdDistritoNavigation)
                .OrderBy(p => p.DataCriacao)
                .Take(10)
                .ToListAsync();


            ListaMaisAntigosViewModel modelo = new ListaMaisAntigosViewModel
            {
                
                Utilizador = utilizador,
                DistritoPesquisar = distritopesquisar
            };



            return View(modelo);


        }


        public async Task<IActionResult> PesquisaOperadorDistrito(int distritopesquisar = 0, int pagina = 1)

        {

            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome");

            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Utilizador.Where(p => p.IdDistrito == distritopesquisar).CountAsync(),
                PaginaAtual = pagina
            };

            if (distritopesquisar == 0)
            {

                List<Utilizador> utilizador1 = await _context.Utilizador.Where(p => p.Nome == null)
                    .ToListAsync();

                ListaPesquisaViewModel modelo1 = new ListaPesquisaViewModel
                {
                    Paginacao = paginacao,
                    Utilizador = utilizador1,
                    DistritoPesquisar = distritopesquisar
                };


                return View(modelo1);

            }


            Role roleoperador = _context.Role.FirstOrDefault(r => r.Nome == "Operador");

            List<Utilizador> utilizador = await _context.Utilizador.Where(p => (p.IdDistrito.Equals(distritopesquisar)) && (p.IdRoleNavigation == roleoperador))
                .Include(u => u.IdRoleNavigation)
                .Include(d => d.IdDistritoNavigation)
                .OrderBy(p => p.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();


            ListaPesquisaViewModel modelo = new ListaPesquisaViewModel
            {
                Paginacao = paginacao,
                Utilizador = utilizador,
                DistritoPesquisar = distritopesquisar
            };



            return View(modelo);


        }



        // GET: Utilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var utilizador = await _context.Utilizador
                .Include(u => u.IdRoleNavigation)
                .Include(d => d.IdDistritoNavigation)
                .FirstOrDefaultAsync(m => m.IdUtilizador == id);
            if (utilizador == null)
            {
                utilizador = await _context.Utilizador.SingleOrDefaultAsync(c => c.Email == User.Identity.Name);
                return View(utilizador);
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

        public async Task<IActionResult> DetailsPessoaisCliente(int? id)
        {

            var utilizador = await _context.Utilizador.SingleOrDefaultAsync(u => u.Email == User.Identity.Name);
            //.Include(u => u.IdRoleNavigation)
            //.FirstOrDefaultAsync(m => m.IdUtilizador == id);

            var contrato = await _context.Contrato.Where(p => p.IdCliente == utilizador.IdUtilizador)
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdOperadorNavigation)
                .Include(c => c.IdPacoteComercialPromocaoNavigation)
                .ToListAsync();

            if (utilizador == null)
            {
                utilizador = await _context.Utilizador.SingleOrDefaultAsync(c => c.Email == User.Identity.Name);
                return View(utilizador);
            }

            if (utilizador.Ativo == true)
            {
                ViewBag.Ativo = "Utilizador Ativo";
            }
            else
            {
                ViewBag.Ativo = "Utilizador Inativo";
            }


            ListaUtilizadoresAreaClienteViewModel modelo = new ListaUtilizadoresAreaClienteViewModel
            {
                Utilizador = utilizador,
                Contrato = contrato
            };

            return base.View(modelo);
        }

        // GET: Utilizadores/Create
        public IActionResult CreateCliente()
        {
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "Nome");
            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome");
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCliente([Bind("IdUtilizador,Nome,DataNascimento,Morada,Contacto,Email,NContribuinte,NIdentificacao,LocalTrabalho,IdDistrito")] Utilizador utilizador)
        {
            string nif = utilizador.NContribuinte;
            string nid = utilizador.NIdentificacao;

            var isNContribuinteAlreadyExists = _context.Utilizador.Any(x => x.NContribuinte == utilizador.NContribuinte);
            var isNIdentificacaoAlreadyExists = _context.Utilizador.Any(x => x.NIdentificacao == utilizador.NIdentificacao);
            var isEmailAlreadyExists = _context.Utilizador.Any(x => x.Email == utilizador.Email);

            if (isNContribuinteAlreadyExists || isNIdentificacaoAlreadyExists || isEmailAlreadyExists || nid.Length != 8 || nif.Length < 9)
            {
                if (isNIdentificacaoAlreadyExists) ModelState.AddModelError("NIdentificacao", "Este número já esta associado a uma conta");
                if (isNContribuinteAlreadyExists) ModelState.AddModelError("NContribuinte", "Este contribuinte já esta associado a uma conta");
                if (isEmailAlreadyExists) ModelState.AddModelError("Email", "Este email já esta associado a uma conta");

                if (nif.Length < 9) ModelState.AddModelError("NContribuinte", "Nº de contribuinte incorreto");
                if (nid.Length != 8) ModelState.AddModelError("NIdentificacao", "Nº de identificação incorreto");

                return View(utilizador);
            }

            char firstChar = nif[0];
            if (firstChar.Equals('1') ||
                firstChar.Equals('2') ||
                firstChar.Equals('3') ||
                firstChar.Equals('5') ||
                firstChar.Equals('6') ||
                firstChar.Equals('8') ||
                firstChar.Equals('9'))
            {
                int checkDigit = (Convert.ToInt32(firstChar.ToString()) * 9);
                for (int i = 2; i <= 8; ++i)
                {
                    checkDigit += Convert.ToInt32(nif[i - 1].ToString()) * (10 - i);
                }

                checkDigit = 11 - (checkDigit % 11);
                if (checkDigit >= 10)
                {
                    checkDigit = 0;
                }

                if (checkDigit.ToString() != nif[8].ToString())
                {
                    ModelState.AddModelError("NContribuinte", "Nº de contribuinte incorreto");
                    return View(utilizador);
                }
            };

            if (ModelState.IsValid)
            {
                Role rolecliente = _context.Role.FirstOrDefault(r => r.Nome == "Cliente");

                utilizador.IdRoleNavigation = rolecliente;

                utilizador.Ativo = true;
                utilizador.DataCriacao = System.DateTime.Now;
                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Cliente adicionado com sucesso.";
                return View("Sucesso");
            }
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "Nome", utilizador.IdRole);
            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome");
            return View(utilizador);
        }

        // GET: Utilizadores/Create
        public IActionResult CreateOperador()
        {

            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "Nome");
            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome");
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOperador([Bind("IdUtilizador,Nome,DataNascimento,Morada,Contacto,Email,NContribuinte,NIdentificacao,LocalTrabalho,IdDistrito")] Utilizador utilizador)
        {
            string nif = utilizador.NContribuinte;
            string nid = utilizador.NIdentificacao;

            var isNContribuinteAlreadyExists = _context.Utilizador.Any(x => x.NContribuinte == utilizador.NContribuinte);
            var isNIdentificacaoAlreadyExists = _context.Utilizador.Any(x => x.NIdentificacao == utilizador.NIdentificacao);
            var isEmailAlreadyExists = _context.Utilizador.Any(x => x.Email == utilizador.Email);

            if (isNContribuinteAlreadyExists || isNIdentificacaoAlreadyExists || isEmailAlreadyExists || nid.Length != 8 || nif.Length < 9)
            {
                if (isNIdentificacaoAlreadyExists) ModelState.AddModelError("NIdentificacao", "Este número já esta associado a uma conta");
                if (isNContribuinteAlreadyExists) ModelState.AddModelError("NContribuinte", "Este contribuinte já esta associado a uma conta");
                if (isEmailAlreadyExists) ModelState.AddModelError("Email", "Este email já esta associado a uma conta");

                if (nif.Length < 9) ModelState.AddModelError("NContribuinte", "Nº de contribuinte incorreto");
                if (nid.Length != 8) ModelState.AddModelError("NIdentificacao", "Nº de identificação incorreto");

                return View(utilizador);
            }

            char firstChar = nif[0];
            if (firstChar.Equals('1') ||
                firstChar.Equals('2') ||
                firstChar.Equals('3') ||
                firstChar.Equals('5') ||
                firstChar.Equals('6') ||
                firstChar.Equals('8') ||
                firstChar.Equals('9'))
            {
                int checkDigit = (Convert.ToInt32(firstChar.ToString()) * 9);
                for (int i = 2; i <= 8; ++i)
                {
                    checkDigit += Convert.ToInt32(nif[i - 1].ToString()) * (10 - i);
                }

                checkDigit = 11 - (checkDigit % 11);
                if (checkDigit >= 10)
                {
                    checkDigit = 0;
                }

                if (checkDigit.ToString() != nif[8].ToString())
                {
                    ModelState.AddModelError("NContribuinte", "Nº de contribuinte incorreto");
                    return View(utilizador);
                }
            };

            if (ModelState.IsValid)
            {
                Role roleoperador = _context.Role.FirstOrDefault(r => r.Nome == "Operador");

                utilizador.IdRoleNavigation = roleoperador;

                utilizador.Ativo = true;
                utilizador.DataCriacao = System.DateTime.Now;
                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexOperador));
            }
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "Nome", utilizador.IdRole);
            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome");
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
            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome");
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUtilizador,Nome,DataNascimento,Morada,Contacto,Email,NContribuinte,NIdentificacao,Ativo,LocalTrabalho, IdRole, IdDistrito")] Utilizador utilizador)
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
                Role rolecliente = _context.Role.FirstOrDefault(r => r.Nome == "Cliente");
                Role roleoperador = _context.Role.FirstOrDefault(r => r.Nome == "Operador");

                var role = utilizador.IdRoleNavigation;


                if (role == rolecliente)
                {
                    if (User.IsInRole("Cliente"))
                    {
                        var cliente = utilizador.IdUtilizador;
                        return RedirectToAction("DetailsPessoaisCliente", "Utilizadores", new { id = cliente });
                    }

                    return RedirectToAction(nameof(IndexCliente));

                }
                else if (role == roleoperador)
                {
                    return RedirectToAction(nameof(IndexOperador));
                }

            }
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "Nome", utilizador.IdRole);
            ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "Nome");
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
                .Include(d => d.IdDistritoNavigation)
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

            Role rolecliente = _context.Role.FirstOrDefault(r => r.Nome == "Cliente");
            Role roleoperador = _context.Role.FirstOrDefault(r => r.Nome == "Operador");

            var role = utilizador.IdRoleNavigation;

            _context.Utilizador.Remove(utilizador);
            await _context.SaveChangesAsync();


            if (role == rolecliente)
            {
                return RedirectToAction(nameof(IndexCliente));
            }
            else
            {
                return RedirectToAction(nameof(IndexOperador));
            }
            ///return RedirectToAction(nameof(Index));
        }

        private bool UtilizadorExists(int id)
        {
            return _context.Utilizador.Any(e => e.IdUtilizador == id);
        }
    }
}
