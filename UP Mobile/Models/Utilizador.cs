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
            ReclamacaoIdClienteNavigation = new HashSet<Reclamacao>();
            ReclamacaoIdOperadorNavigation = new HashSet<Reclamacao>();
        }

        [Key]
        [Column("Id_Utilizador")]
        [Display(Name = "Número")]
        public int IdUtilizador { get; set; }

        [Required(ErrorMessage = "Deve preencher o nome.")]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Data_Nascimento", TypeName = "date")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Deve preencher a morada.")]
        [StringLength(100)]
        [Display(Name = "Morada")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Deve preencher o contacto.")]
        [StringLength(9)]
        [Display(Name = "Contacto")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "Deve preencher o email.")]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Deve preencher o número de contribuinte.")]
        [Column("N_Contribuinte")]
        [StringLength(9)]
        [Display(Name = "Nº de Contribuinte")]
        public string NContribuinte { get; set; }

        [Required(ErrorMessage = "Deve preencher o número de identificação.")]
        [Column("N_Identificacao")]
        [StringLength(8)]
        [Display(Name = "Nº de Identificação")]
        public string NIdentificacao { get; set; }

        [Display(Name = "Ativo/Inativo")]
        public bool Ativo { get; set; }

        [Column("Local_Trabalho")]
        [StringLength(100)]
        [Display(Name = "Local de Trabalho")]
        public string LocalTrabalho { get; set; }

        [Column("Id_Role")]
        public int IdRole { get; set; }

        [Column("Data_Criacao", TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }

        [Column("Id_Distrito")]
        public int IdDistrito { get; set; }

        [ForeignKey(nameof(IdDistrito))]
        [InverseProperty(nameof(Distrito.Utilizador))]
        public virtual Distrito IdDistritoNavigation { get; set; }
        [ForeignKey(nameof(IdRole))]
        [InverseProperty(nameof(Role.Utilizador))]
        public virtual Role IdRoleNavigation { get; set; }
        [InverseProperty(nameof(Contrato.IdClienteNavigation))]
        public virtual ICollection<Contrato> ContratoIdClienteNavigation { get; set; }
        [InverseProperty(nameof(Contrato.IdOperadorNavigation))]
        public virtual ICollection<Contrato> ContratoIdOperadorNavigation { get; set; }
        [InverseProperty(nameof(Reclamacao.IdClienteNavigation))]
        public virtual ICollection<Reclamacao> ReclamacaoIdClienteNavigation { get; set; }
        [InverseProperty(nameof(Reclamacao.IdOperadorNavigation))]
        public virtual ICollection<Reclamacao> ReclamacaoIdOperadorNavigation { get; set; }
    }
}
