﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    [Index(nameof(NContribuinte), Name = "UN_N_Contribuinte", IsUnique = true)]
    [Index(nameof(NIdentificacao), Name = "UN_N_Identificacao", IsUnique = true)]
    public partial class Cliente
    {
        public Cliente()
        {
            Contrato = new HashSet<Contrato>();
        }

        [Key]
        [Column("Id_Cliente")]
        public int IdCliente { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Column("Data_Nascimento", TypeName = "date")]
        public DateTime DataNascimento { get; set; }
        [Required]
        [StringLength(100)]
        public string Morada { get; set; }
        public int Contacto { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("N_Contribuinte")]
        public int NContribuinte { get; set; }
        [Column("N_Identificacao")]
        public int NIdentificacao { get; set; }

        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
