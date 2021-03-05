﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    [Table("Conteudo_Extra")]
    public partial class ConteudoExtra
    {
        public ConteudoExtra()
        {
            ContratoConteudo = new HashSet<ContratoConteudo>();
        }

        [Key]
        [Column("Id_Conteudo")]
        public int IdConteudo { get; set; }

        [Required(ErrorMessage = "Deve preencher o nome.")]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Deve preencher a descrição.")]
        [StringLength(500)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("Data_Inicio_Comercializacao", TypeName = "date")]
        public DateTime DataInicioComercializacao { get; set; }

        [Column("Data_Fim_Comercializacao", TypeName = "date")]
        public DateTime? DataFimComercializacao { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal? Preco { get; set; }
        public bool Ativo { get; set; }

        [InverseProperty("IdConteudoNavigation")]
        public virtual ICollection<ContratoConteudo> ContratoConteudo { get; set; }
    }
}
