using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    public partial class Estados
    {
        public Estados()
        {
            Reclamacao = new HashSet<Reclamacao>();
        }

        [Key]
        [Column("Id_Estado")]
        public int IdEstado { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [InverseProperty("IdEstadoNavigation")]
        public virtual ICollection<Reclamacao> Reclamacao { get; set; }
    }
}
