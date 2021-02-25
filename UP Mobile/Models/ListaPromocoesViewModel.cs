using System.Collections.Generic;

namespace UP_Mobile.Models
{
    public class ListaPromocoesViewModel
    {

        public List<Promocao> Promocao { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }
    }
}
