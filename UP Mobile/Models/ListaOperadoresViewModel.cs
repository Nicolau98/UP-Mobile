using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UP_Mobile.Models
{
    public class ListaOperadoresViewModel
    {

        public List<Operador> Operador { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }

    }
}
