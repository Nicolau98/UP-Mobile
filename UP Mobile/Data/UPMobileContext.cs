using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UP_Mobile.Models;

#nullable disable

namespace UP_Mobile.Data
{
    public partial class UPMobileContext : DbContext
    {
        public UPMobileContext()
        {
        }

        public UPMobileContext(DbContextOptions<UPMobileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ConteudoExtra> ConteudoExtra { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<ContratoConteudo> ContratoConteudo { get; set; }
        public virtual DbSet<Fatura> Fatura { get; set; }
        public virtual DbSet<Operador> Operador { get; set; }
        public virtual DbSet<PacoteComercial> PacoteComercial { get; set; }
        public virtual DbSet<PacoteComercialPromocao> PacoteComercialPromocao { get; set; }
        public virtual DbSet<Promocao> Promocao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contrato_Cliente");

                entity.HasOne(d => d.IdOperadorNavigation)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.IdOperador)
                    .HasConstraintName("FK_Contrato_Operador");

                entity.HasOne(d => d.IdPacoteComercialPromocaoNavigation)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.IdPacoteComercialPromocao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contrato_Pacote_Comercial_Promocao");
            });

            modelBuilder.Entity<ContratoConteudo>(entity =>
            {
                entity.HasOne(d => d.IdConteudoNavigation)
                    .WithMany(p => p.ContratoConteudo)
                    .HasForeignKey(d => d.IdConteudo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contrato_Conteudo_Conteudo_Extra");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.ContratoConteudo)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contrato_Conteudo_Contrato");
            });

            modelBuilder.Entity<Fatura>(entity =>
            {
                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fatura_Contrato");
            });

            modelBuilder.Entity<PacoteComercialPromocao>(entity =>
            {
                entity.HasOne(d => d.IdPacoteNavigation)
                    .WithMany(p => p.PacoteComercialPromocao)
                    .HasForeignKey(d => d.IdPacote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pacote_Comercial_Promocao_Pacote__Comercial");

                entity.HasOne(d => d.IdPromocaoNavigation)
                    .WithMany(p => p.PacoteComercialPromocao)
                    .HasForeignKey(d => d.IdPromocao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pacote_Comercial_Promocao_Promocao");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
