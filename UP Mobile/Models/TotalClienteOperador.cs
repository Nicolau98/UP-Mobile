using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UP_Mobile.Models
{
    public class TotalClienteOperador
    {

        public Utilizador Utilizador { get; set; }
        public string NomeUtilizador { get; set; }
        public List<Contrato> Contratos { get; set; }
        public decimal Total { get; set; }
        public int DistritosId { get; set; }

    }
}
