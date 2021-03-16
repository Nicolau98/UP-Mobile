using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    [Index(nameof(Nome), Name = "IX_Distrito", IsUnique = true)]
    public partial class Distrito
    {
        public Distrito()
        {
            PacoteComercialPromocao = new HashSet<PacoteComercialPromocao>();
            Utilizador = new HashSet<Utilizador>();
        }

        [Key]
        [Column("Id_Distrito")]
        public int IdDistrito { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [InverseProperty("IdDistritoNavigation")]
        public virtual ICollection<PacoteComercialPromocao> PacoteComercialPromocao { get; set; }
        [InverseProperty("IdDistritoNavigation")]
        public virtual ICollection<Utilizador> Utilizador { get; set; }
    }
}
