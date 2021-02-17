using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    public partial class Operador
    {
        public Operador()
        {
            Contrato = new HashSet<Contrato>();
        }

        [Key]
        [Column("Id_Operador")]
        [Display(Name = "Nº Operador")]
        public int IdOperador { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Column("Data_Nascimento", TypeName = "date")]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(100)]
        public string Morada { get; set; }

        public int Contacto { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Column("Local_Trabalho")]
        [StringLength(100)]
        [Display(Name = "Morada do local de trabalho")]
        public string LocalTrabalho { get; set; }

        [Column("Operador_ativo")]
        [Display(Name = "Operador Ativo")]
        public bool OperadorAtivo { get; set; }

        [InverseProperty("IdOperadorNavigation")]
        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
