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
        [StringLength(20)]
        public string Nome { get; set; }
        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }
        [Column("Data_Inicio_Comercializacao", TypeName = "datetime")]
        public DateTime DataInicioComercializacao { get; set; }
        [Column("Data_Fim_Comercializacao", TypeName = "datetime")]
        public DateTime? DataFimComercializacao { get; set; }
        [Column("Preco_base")]
        public int PrecoBase { get; set; }
        [Column("Periodo_Fidelizacao")]
        public int? PeriodoFidelizacao { get; set; }

        [InverseProperty("IdPacoteNavigation")]
        public virtual ICollection<PacoteComercialPromocao> PacoteComercialPromocao { get; set; }
    }
}
