using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UP_Mobile.Models
{
    public class ListaClientesViewModel
    {

        public List<Cliente> Cliente { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }

    }
}
