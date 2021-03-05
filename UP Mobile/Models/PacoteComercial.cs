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

        [Required(ErrorMessage = "Deve preencher o nome.")]
        [StringLength(50)]
        [Display(Name = "Nome do Pacote")]
        public string Nome { get; set; }

        [StringLength(500)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("Data_Inicio_Comercializacao", TypeName = "date")]
        [Display(Name = "Data de Inicio de Comercialização")]
        [DataType(DataType.Date)]
        public DateTime DataInicioComercializacao { get; set; }

        [Column("Data_Fim_Comercializacao", TypeName = "date")]
        [Display(Name = "Data de Fim de Comercialização")]
        [DataType(DataType.Date)]
        public DateTime? DataFimComercializacao { get; set; }

        [Column("Preco_base", TypeName = "decimal(4, 2)")]
        [Display(Name = "Preço")]
        public decimal PrecoBase { get; set; }

        [Column("Periodo_Fidelizacao")]
        [Display(Name = "Periodo de Fidelização")]
        public int PeriodoFidelizacao { get; set; }

        public bool Ativo { get; set; }
        [StringLength(50)]
        public string Internet { get; set; }
        [StringLength(50)]
        public string Voz { get; set; }
        [StringLength(50)]
        public string Tv { get; set; }
        [StringLength(50)]
        public string Movel { get; set; }

        [InverseProperty("IdPacoteNavigation")]
        public virtual ICollection<PacoteComercialPromocao> PacoteComercialPromocao { get; set; }
    }
}
