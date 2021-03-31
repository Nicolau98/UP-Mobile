
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UP_Mobile.Models
{
    public class Faturacao
    {

        public List<Contrato> Contratos { get; set; }

        public int ContratoId { get; set; }

        public DateTime Data { get; set; }

        public decimal Total { get; set; }


    }
}