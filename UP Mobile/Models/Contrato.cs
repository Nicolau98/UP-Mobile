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
        }

        [Key]
        [Column("Id_Contrato")]
        [Display(Name = "Nº Contrato")]
        public int IdContrato { get; set; }

        [Column("Id_Cliente")]
        [Display(Name = "Nº Cliente")]
        public int IdCliente { get; set; 
        }
        [Column("Id_Operador")]
        [Display(Name = "Nº Operador")]
        public int? IdOperador { get; set; }

        [Column("Id_Pacote_Comercial_Promocao")]
        [Display(Name = "Nº Pacote Comercial Promoção")]
        public int IdPacoteComercialPromocao { get; set; }

        [Column("Data_Inicio_Contrato", TypeName = "datetime")]
        [Display(Name = "Data de início de contrato")]
        public DateTime DataInicioContrato { get; set; }

        [Column("Data_Fim_Contrato", TypeName = "datetime")]
        [Display(Name = "Data de fim de contrato")]
        public DateTime? DataFimContrato { get; set; }

        [Required(ErrorMessage = "Deve preencher a morada de faturação.")]
        [Column("Morada_Faturacao")]
        [StringLength(100)]
        [Display(Name = "Morada de Faturação")]
        public string MoradaFaturacao { get; set; }

        [Column("Data_Fidelizacao", TypeName = "date")]
        [Display(Name = "Data de fidelização")]
        public DateTime? DataFidelizacao { get; set; }

        [Column("Preco_Base_Inicio_Contrato", TypeName = "decimal(4, 2)")]
        [Display(Name = "Preço Base de Inicio de contrato")]
        public decimal PrecoBaseInicioContrato { get; set; }

        [Column("Preco_Total", TypeName = "decimal(5, 2)")]
        [Display(Name = "Preço Total")]
        public decimal PrecoTotal { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Utilizador.ContratoIdClienteNavigation))]
        public virtual Utilizador IdClienteNavigation { get; set; }

        [ForeignKey(nameof(IdOperador))]
        [InverseProperty(nameof(Utilizador.ContratoIdOperadorNavigation))]
        public virtual Utilizador IdOperadorNavigation { get; set; }

        [ForeignKey(nameof(IdPacoteComercialPromocao))]
        [InverseProperty(nameof(PacoteComercialPromocao.Contrato))]
        public virtual PacoteComercialPromocao IdPacoteComercialPromocaoNavigation { get; set; }

        [InverseProperty("IdContratoNavigation")]
        public virtual ICollection<ContratoConteudo> ContratoConteudo { get; set; }
    }
}
