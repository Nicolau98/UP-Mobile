using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    [Table("Pacote__Comercial")]
    public partial class PacoteComercial
    {
        public PacoteComercial()
        {
            PacoteComercialPromocao = new HashSet<PacoteComercialPromocao>();
        }

        [Key]
        [Column("Id_Pacote")]
        public int IdPacote { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }
        [Column("Data_Inicio_Comercializacao", TypeName = "date")]
        public DateTime DataInicioComercializacao { get; set; }
        [Column("Data_Fim_Comercializacao", TypeName = "date")]
        public DateTime? DataFimComercializacao { get; set; }
        [Column("Preco_base", TypeName = "decimal(4, 2)")]
        public decimal PrecoBase { get; set; }
        [Column("Periodo_Fidelizacao")]
        public int PeriodoFidelizacao { get; set; }
        [Column("Id_Pacote_Comercial_Detalhes")]
        public int IdPacoteComercialDetalhes { get; set; }
        public bool Ativo { get; set; }

        [ForeignKey(nameof(IdPacoteComercialDetalhes))]
        [InverseProperty(nameof(PacoteComercialDetalhes.PacoteComercial))]
        public virtual PacoteComercialDetalhes IdPacoteComercialDetalhesNavigation { get; set; }
        [InverseProperty("IdPacoteNavigation")]
        public virtual ICollection<PacoteComercialPromocao> PacoteComercialPromocao { get; set; }
    }
}
