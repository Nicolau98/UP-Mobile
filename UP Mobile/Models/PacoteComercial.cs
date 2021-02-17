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
        [Display(Name = "Nº Pacote Comercial")]
        public int IdPacote { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("Data_Inicio_Comercializacao", TypeName = "date")]
        [Display(Name = "Data de início de comercialização")]
        public DateTime DataInicioComercializacao { get; set; }

        [Column("Data_Fim_Comercializacao", TypeName = "date")]
        [Display(Name = "Data de fim de comercialização")]
        public DateTime? DataFimComercializacao { get; set; }

        [Column("Preco_base", TypeName = "decimal(4, 2)")]
        [Display(Name = "Preço base")]
        public decimal PrecoBase { get; set; }

        [Column("Periodo_Fidelizacao")]
        [Display(Name = "Periodo de fidelização")]
        public int? PeriodoFidelizacao { get; set; }

        [InverseProperty("IdPacoteNavigation")]
        public virtual ICollection<PacoteComercialPromocao> PacoteComercialPromocao { get; set; }
    }
}
