using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace UP_Mobile.Models
{
    [Table("Contrato_Conteudo")]
    public partial class ContratoConteudo
    {
        [Key]
        [Column("Id_Contrato_Conteudo")]
        public int IdContratoConteudo { get; set; }
        [Column("Id_Conteudo")]
        public int IdConteudo { get; set; }
        [Column("Id_Contrato")]
        public int IdContrato { get; set; }
        [Column("Data_Inicio_Conteudo", TypeName = "datetime")]
        public DateTime DataInicioConteudo { get; set; }
        [Column("Data_Fim_Conteudo", TypeName = "datetime")]
        public DateTime? DataFimConteudo { get; set; }

        [ForeignKey(nameof(IdConteudo))]
        [InverseProperty(nameof(ConteudoExtra.ContratoConteudo))]
        public virtual ConteudoExtra IdConteudoNavigation { get; set; }
        [ForeignKey(nameof(IdContrato))]
        [InverseProperty(nameof(Contrato.ContratoConteudo))]
        public virtual Contrato IdContratoNavigation { get; set; }
    }
}
