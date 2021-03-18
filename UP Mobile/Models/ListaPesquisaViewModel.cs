using System.Collections.Generic;

namespace UP_Mobile.Models
{
    public class ListaPesquisaViewModel
    {

        public List<Utilizador> Utilizador { get; set; }
        public Paginacao Paginacao { get; set; }
        public int DistritoPesquisar { get; set; }
    }
}