﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    public partial class Administrador
    {
        [Key]
        [Column("Id_Administrador")]
        public int IdAdministrador { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Column("Data_Nascimento", TypeName = "date")]
        public DateTime DataNascimento { get; set; }
        [Required]
        [StringLength(100)]
        public string Morada { get; set; }
        [Required]
        [StringLength(9)]
        public string Contacto { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("Local_Trabalho")]
        [StringLength(100)]
        public string LocalTrabalho { get; set; }
        [Column("Administrador_ativo")]
        public bool AdministradorAtivo { get; set; }
    }
}
