using System.Collections.Generic;

namespace UP_Mobile.Models
{
    public class ListaPacotesComerciaisViewModel
    {
        public List<PacoteComercial> PacoteComercial { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }
    }
}
