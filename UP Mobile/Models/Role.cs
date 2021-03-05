using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    public partial class Role
    {
        public Role()
        {
            Utilizador = new HashSet<Utilizador>();
        }

        [Key]
        [Column("Id_Role")]
        public int IdRole { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }


        [InverseProperty("IdRoleNavigation")]
        public virtual ICollection<Utilizador> Utilizador { get; set; }
    }
}
