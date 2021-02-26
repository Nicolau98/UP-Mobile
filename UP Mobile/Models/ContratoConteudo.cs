using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    [Table("Contrato_Conteudo")]
    public partial class ContratoConteudo
    {
        [Key]
        [Column("Id_Contrato_Conteudo")]
        [Display(Name = "Nº Contrato Conteudo")]
        public int IdContratoConteudo { get; set; }

        [Column("Id_Conteudo")]
        [Display(Name = "Nº Conteudo")]
        public int IdConteudo { get; set; }

        [Column("Id_Contrato")]
        [Display(Name = "Nº Contrato")]
        public int IdContrato { get; set; }

        [Column("Data_Inicio_Conteudo", TypeName = "datetime")]
        [Display(Name = "Data de início do conteudo")]
        public DateTime DataInicioConteudo { get; set; }

        [Column("Data_Fim_Conteudo", TypeName = "datetime")]
        [Display(Name = "Data de fim do conteudo")]
        public DateTime? DataFimConteudo { get; set; }


        [ForeignKey(nameof(IdConteudo))]
        [InverseProperty(nameof(ConteudoExtra.ContratoConteudo))]
        public virtual ConteudoExtra IdConteudoNavigation { get; set; }

        [ForeignKey(nameof(IdContrato))]
        [InverseProperty(nameof(Contrato.ContratoConteudo))]
        public virtual Contrato IdContratoNavigation { get; set; }
    }
}

