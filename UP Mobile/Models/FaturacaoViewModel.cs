
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UP_Mobile.Models
{
    public class FaturacaoViewModel
    {

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]

        public DateTime Data { get; set; }

    }
}