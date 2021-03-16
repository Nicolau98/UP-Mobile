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
        public DateTime Data { get; set; }
        [Column("Data_Limite_Pagamento", TypeName = "date")]
        public DateTime DataLimitePagamento { get; set; }
        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }
        [Column("Preco_Total", TypeName = "decimal(5, 2)")]
        public decimal PrecoTotal { get; set; }
        [Column("Id_Metodo_Pagamento")]
        public int IdMetodoPagamento { get; set; }

        [ForeignKey(nameof(IdContrato))]
        [InverseProperty(nameof(Contrato.Fatura))]
        public virtual Contrato IdContratoNavigation { get; set; }
        [ForeignKey(nameof(IdMetodoPagamento))]
        [InverseProperty(nameof(MetodoPagamento.Fatura))]
        public virtual MetodoPagamento IdMetodoPagamentoNavigation { get; set; }
    }
}
