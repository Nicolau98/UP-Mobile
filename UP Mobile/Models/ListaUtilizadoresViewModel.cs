using System.Collections.Generic;

namespace UP_Mobile.Models
{
    public class ListaUtilizadoresViewModel
    {

        public List<Utilizador> Utilizador { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }
    }
}
