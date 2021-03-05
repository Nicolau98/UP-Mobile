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
        public int IdPromocao { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("Data_Inicio", TypeName = "date")]
        public DateTime DataInicio { get; set; }

        [Column("Data_Fim", TypeName = "date")]
        public DateTime? DataFim { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal Preco { get; set; }

        [StringLength(50)]
        [Display(Name = "Conteúdo")]
        public string Conteudo { get; set; }

        public bool Ativo { get; set; }

        [InverseProperty("IdPromocaoNavigation")]
        public virtual ICollection<PacoteComercialPromocao> PacoteComercialPromocao { get; set; }
    }
}
