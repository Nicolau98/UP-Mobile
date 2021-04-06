using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    public partial class Fatura
    {
        [Key]
        [Column("Id_Fatura")]
        public int IdFatura { get; set; }

        [Column("Id_Contrato")]
        public int IdContrato { get; set; }

        [Column(TypeName = "datetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]

        public DateTime Data { get; set; }


        [Column("Data_Limite_Pagamento", TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]

        public DateTime DataLimitePagamento { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        [Column("Preco_Total", TypeName = "decimal(5, 2)")]
        public decimal PrecoTotal { get; set; }

        [ForeignKey(nameof(IdContrato))]
        [InverseProperty(nameof(Contrato.Fatura))]
        public virtual Contrato IdContratoNavigation { get; set; }
    }
}
