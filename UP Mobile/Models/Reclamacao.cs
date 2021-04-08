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
        [Display(Name = "Nº Reclamação")]
        public int IdReclamacao { get; set; }
        [Column("Id_Cliente")]

        [Display(Name = "Nº Cliente")]
        public int IdCliente { get; set; }

        [Display(Name = "Nº Operador")]
        [Column("Id_Operador")]
        public int? IdOperador { get; set; }

        [Display(Name = "Data de Abertura")]
        [Column("Data_Abertura", TypeName = "datetime")]
        public DateTime DataAbertura { get; set; }


        [Required]
        [StringLength(250)]
        public string Assunto { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }


        [Column("Id_Estado")]
        public int IdEstado { get; set; }

        [Display(Name = "Data de Resolução")]
        [Column("Data_Resolucao", TypeName = "datetime")]
        public DateTime? DataResolucao { get; set; }

        [Display(Name = "Resolução")]
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
