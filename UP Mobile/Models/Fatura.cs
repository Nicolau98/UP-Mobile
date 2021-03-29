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
        [Display(Name = "Nº da Fatura")]
        public int IdFatura { get; set; }

        [Column("Id_Contrato")]
        [Display(Name = "Nº do Contrato")]
        public int IdContrato { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Data { get; set; }

        [Column("Data_Limite_Pagamento", TypeName = "date")]
        [Display(Name = "Data de Limite de Pagamento")]
        public DateTime DataLimitePagamento { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        [Column("Preco_Total", TypeName = "decimal(5, 2)")]
        [Display(Name = "Preço total da Fatura")]
        public decimal PrecoTotal { get; set; }

        [Column("Data_Pagamento", TypeName = "datetime")]
        [Display(Name = "Data de Pagamento da Fatura")]
        public DateTime DataPagamento { get; set; }

        [ForeignKey(nameof(IdContrato))]
        [InverseProperty(nameof(Contrato.Fatura))]
        public virtual Contrato IdContratoNavigation { get; set; }
    }
}
