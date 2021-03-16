using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    public partial class Reclamacao
    {
        [Key]
        [Column("Id_Reclamacao")]
        public int IdReclamacao { get; set; }
        [Column("Id_Cliente")]
        public int IdCliente { get; set; }
        [Column("Id_Operador")]
        public int? IdOperador { get; set; }
        [Column("Data_Abertura", TypeName = "datetime")]
        public DateTime DataAbertura { get; set; }
        [Required]
        [StringLength(100)]
        public string Assunto { get; set; }
        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }
        [Column("Id_Estado")]
        public int IdEstado { get; set; }
        [Column("Data_Resolucao", TypeName = "datetime")]
        public DateTime? DataResolucao { get; set; }
        [StringLength(500)]
        public string Resolucao { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Utilizador.ReclamacaoIdClienteNavigation))]
        public virtual Utilizador IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdEstado))]
        [InverseProperty(nameof(Estado.Reclamacao))]
        public virtual Estado IdEstadoNavigation { get; set; }
        [ForeignKey(nameof(IdOperador))]
        [InverseProperty(nameof(Utilizador.ReclamacaoIdOperadorNavigation))]
        public virtual Utilizador IdOperadorNavigation { get; set; }
    }
}
