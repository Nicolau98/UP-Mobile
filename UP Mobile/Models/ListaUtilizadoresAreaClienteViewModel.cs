using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UP_Mobile.Models
{
    public class ListaUtilizadoresAreaClienteViewModel
    {
        public Utilizador Utilizador { get; set; }

        public List<Contrato> Contrato { get; set; }



        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password não coincide")]
        public string ConfirmarPassword { get; set; }
    }
}
