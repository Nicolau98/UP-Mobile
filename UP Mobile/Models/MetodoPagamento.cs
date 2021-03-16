using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    [Table("Metodo_Pagamento")]
    public partial class MetodoPagamento
    {
        public MetodoPagamento()
        {
            Fatura = new HashSet<Fatura>();
        }

        [Key]
        [Column("Id_Metodo_Pagamento")]
        public int IdMetodoPagamento { get; set; }

        [Required]
        [StringLength(50)]
        public string Metodo { get; set; }

        [InverseProperty("IdMetodoPagamentoNavigation")]
        public virtual ICollection<Fatura> Fatura { get; set; }
    }
}
