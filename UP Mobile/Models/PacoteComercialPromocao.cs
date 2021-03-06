﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    [Table("Pacote_Comercial_Promocao")]
    public partial class PacoteComercialPromocao
    {
        public PacoteComercialPromocao()
        {
            Contrato = new HashSet<Contrato>();
        }

        [Key]
        [Column("Id_Pacote_Comercial_Promocao")]
        public int IdPacoteComercialPromocao { get; set; }

        [Display(Name = "Promoção")]
        [Column("Id_Promocao")]
        public int IdPromocao { get; set; }

        [Display(Name = "Pacote")]
        [Column("Id_Pacote")]
        public int IdPacote { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Preço Total")]
        [Column("Preco_total_pacote", TypeName = "decimal(5, 2)")]
        public decimal PrecoTotalPacote { get; set; }

        [Display(Name = "Distrito")]
        [Column("Id_Distrito")]
        public int IdDistrito { get; set; }

        [ForeignKey(nameof(IdDistrito))]
        [InverseProperty(nameof(Distrito.PacoteComercialPromocao))]
        public virtual Distrito IdDistritoNavigation { get; set; }
        [ForeignKey(nameof(IdPacote))]
        [InverseProperty(nameof(PacoteComercial.PacoteComercialPromocao))]
        public virtual PacoteComercial IdPacoteNavigation { get; set; }
        [ForeignKey(nameof(IdPromocao))]
        [InverseProperty(nameof(Promocao.PacoteComercialPromocao))]
        public virtual Promocao IdPromocaoNavigation { get; set; }
        [InverseProperty("IdPacoteComercialPromocaoNavigation")]
        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
