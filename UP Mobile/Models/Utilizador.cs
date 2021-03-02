using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    [Index(nameof(NContribuinte), Name = "UN_Contribuinte", IsUnique = true)]
    [Index(nameof(NIdentificacao), Name = "UN_Identificacao", IsUnique = true)]
    public partial class Utilizador
    {
        public Utilizador()
        {
            ContratoIdClienteNavigation = new HashSet<Contrato>();
            ContratoIdOperadorNavigation = new HashSet<Contrato>();
        }

        [Key]
        [Column("Id_Utilizador")]
        public int IdUtilizador { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Column("Data_Nascimento", TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
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
        [Column("N_Contribuinte")]
        [StringLength(9)]
        [Display(Name = "Número de Contribuinte")]
        public string NContribuinte { get; set; }

        [Required]
        [Column("N_Identificacao")]
        [StringLength(8)]
        [Display(Name = "Cartão de Cidadão")]
        public string NIdentificacao { get; set; }

        public bool Ativo { get; set; }

        [Column("Local_Trabalho")]
        [StringLength(100)]
        public string LocalTrabalho { get; set; }

        [Column("Id_Role")]
        public int IdRole { get; set; }


        [ForeignKey(nameof(IdRole))]
        [InverseProperty(nameof(Role.Utilizador))]
        public virtual Role IdRoleNavigation { get; set; }
        [InverseProperty(nameof(Contrato.IdClienteNavigation))]
        public virtual ICollection<Contrato> ContratoIdClienteNavigation { get; set; }
        [InverseProperty(nameof(Contrato.IdOperadorNavigation))]
        public virtual ICollection<Contrato> ContratoIdOperadorNavigation { get; set; }
    }
}
