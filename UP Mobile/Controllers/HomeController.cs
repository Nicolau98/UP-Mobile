using Microsoft.AspNetCore.Mvc;
using AspNetCoreHero.ToastNotification;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using UP_Mobile.Models;
using UP_Mobile.Data;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace UP_Mobile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyf;
        private readonly UPMobileContext _context;
        public HomeController(ILogger<HomeController> logger, INotyfService notyf, UPMobileContext context)
        {
            _logger = logger;
            _notyf = notyf;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            if (User.IsInRole("Operador"))
            {
                var operador = await _context.Utilizador.SingleOrDefaultAsync(o => o.Email == User.Identity.Name);

                //Notificação com numero de reclamações em aberto por distrito
                Estado estadoaberto = _context.Estado.FirstOrDefault(e => e.Nome == "Em Aberto");

                var distritooperador = operador.IdDistrito;
                

                var totalemaberto = _context.Reclamacao.Where(c => (c.IdEstadoNavigation == estadoaberto) && (c.IdClienteNavigation.IdDistrito == distritooperador))
                    .Include(c => c.IdEstadoNavigation)
                    .Include(c => c.IdOperadorNavigation)
                    .Include(c => c.IdClienteNavigation)
                    .Count();

                _notyf.Custom("Existem " + totalemaberto + " Reclamações em aberto no seu Distrito", 20, "#4fd6d9", "fa fa-home");


                //total de faturação do operador
                List<Contrato> contratosperador = await _context.Contrato
                    .Where(c => c.IdOperador == operador.IdUtilizador)
                    .ToListAsync();
                int contacontratos = contratosperador.Count;


                decimal totalfaturacao = 0;
                foreach (var item in contratosperador)
                {

                    totalfaturacao += item.PrecoTotal;

                }
                ViewData["totalfaturacao"] = totalfaturacao;
                ViewData["contacontratos"] = contacontratos;

            }
            return View();
        }

        public IActionResult Main()
        {
            return View();
        }

        public IActionResult UP()
        {
            return View();
        }

        public IActionResult teste()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
