using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    public partial class Contrato
    {
        public Contrato()
        {
            ContratoConteudo = new HashSet<ContratoConteudo>();
            Fatura = new HashSet<Fatura>();
        }

        [Key]
        [Column("Id_Contrato")]
        public int IdContrato { get; set; }
        [Column("Id_Cliente")]
        public int IdCliente { get; set; }
        [Column("Id_Operador")]
        public int? IdOperador { get; set; }
        [Column("Id_Pacote_Comercial_Promocao")]
        public int IdPacoteComercialPromocao { get; set; }
        [Column("Data_Inicio_Contrato", TypeName = "datetime")]
        public DateTime DataInicioContrato { get; set; }
        [Column("Data_Fim_Contrato", TypeName = "datetime")]
        public DateTime? DataFimContrato { get; set; }
        [Required]
        [Column("Morada_Faturacao")]
        [StringLength(50)]
        public string MoradaFaturacao { get; set; }
        [Column("Data_Fidelizacao", TypeName = "date")]
        public DateTime? DataFidelizacao { get; set; }
        [Required]
        [Column("Nome_Cliente")]
        [StringLength(50)]
        public string NomeCliente { get; set; }
        [Column("Nome_Operador")]
        [StringLength(50)]
        public string NomeOperador { get; set; }
        [Column("Preco_Base_Inicio_Contrato", TypeName = "decimal(4, 2)")]
        public decimal PrecoBaseInicioContrato { get; set; }
        [Column("Preco_Total", TypeName = "decimal(5, 2)")]
        public decimal PrecoTotal { get; set; }
        [Column("Conteudo_Extra_Total")]
        public int? ConteudoExtraTotal { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Cliente.Contrato))]
        public virtual Cliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdOperador))]
        [InverseProperty(nameof(Operador.Contrato))]
        public virtual Operador IdOperadorNavigation { get; set; }
        [ForeignKey(nameof(IdPacoteComercialPromocao))]
        [InverseProperty(nameof(PacoteComercialPromocao.Contrato))]
        public virtual PacoteComercialPromocao IdPacoteComercialPromocaoNavigation { get; set; }
        [InverseProperty("IdContratoNavigation")]
        public virtual ICollection<ContratoConteudo> ContratoConteudo { get; set; }
        [InverseProperty("IdContratoNavigation")]
        public virtual ICollection<Fatura> Fatura { get; set; }
    }
}
