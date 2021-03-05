using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    public partial class Promocao
    {
        public Promocao()
        {
            PacoteComercialPromocao = new HashSet<PacoteComercialPromocao>();
        }

        [Key]
        [Column("Id_Promocao")]
        [Display(Name = "Nº da Promoção")]
        public int IdPromocao { get; set; }

        [Required(ErrorMessage = "Deve preencher o nome.")]
        [StringLength(50)]
        [Display(Name = "Nome da Promoção")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Deve preencher a descrição.")]
        [StringLength(500)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("Data_Inicio", TypeName = "date")]
        [Display(Name = "Data de Inicio de Comercialização")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Column("Data_Fim", TypeName = "date")]
        [Display(Name = "Data de Fim de Comercialização")]
        [DataType(DataType.Date)]
        public DateTime? DataFim { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        [Display(Name = "Valor")]
        public decimal Preco { get; set; }

        [StringLength(50)]
        [Display(Name = "Conteúdo")]
        public string Conteudo { get; set; }

        public bool Ativo { get; set; }

        [InverseProperty("IdPromocaoNavigation")]
        public virtual ICollection<PacoteComercialPromocao> PacoteComercialPromocao { get; set; }
    }
}
