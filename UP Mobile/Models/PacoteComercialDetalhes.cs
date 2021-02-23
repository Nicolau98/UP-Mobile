using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UP_Mobile.Models
{
    [Table("Pacote_Comercial_Detalhes")]
    public partial class PacoteComercialDetalhes
    {
        public PacoteComercialDetalhes()
        {
            PacoteComercial = new HashSet<PacoteComercial>();
        }

        [Key]
        [Column("Id_Pacote_Comercial_Detalhes")]
        public int IdPacoteComercialDetalhes { get; set; }
        [StringLength(50)]
        public string Internet { get; set; }
        [Column("TV")]
        [StringLength(50)]
        public string Tv { get; set; }
        [StringLength(50)]
        public string Voz { get; set; }
        [StringLength(50)]
        public string Movel { get; set; }

        [InverseProperty("IdPacoteComercialDetalhesNavigation")]
        public virtual ICollection<PacoteComercial> PacoteComercial { get; set; }
    }
}
