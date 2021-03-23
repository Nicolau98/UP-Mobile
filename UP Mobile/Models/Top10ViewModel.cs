using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UP_Mobile.Models
{
    public class Top10ViewModel
    {

        public List<Contrato> Contratos { get; set; }
        public List<Utilizador> Utilizador { get; set; }

        public List<TotalClienteOperador> Totaloperador { get; set; }

        public int DistritoPesquisar { get; set; }

        public int UtilizadorId { get; set; }

        public TotalClienteOperador TotalClienteOperador { get; set; }


    }
}
