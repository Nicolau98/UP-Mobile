﻿using System;
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

        public virtual DbSet<ConteudoExtra> ConteudoExtra { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<ContratoConteudo> ContratoConteudo { get; set; }
        public virtual DbSet<PacoteComercial> PacoteComercial { get; set; }
        public virtual DbSet<PacoteComercialDetalhes> PacoteComercialDetalhes { get; set; }
        public virtual DbSet<PacoteComercialPromocao> PacoteComercialPromocao { get; set; }
        public virtual DbSet<Promocao> Promocao { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ContratoIdClienteNavigation)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contrato_Utilizador");

                entity.HasOne(d => d.IdOperadorNavigation)
                    .WithMany(p => p.ContratoIdOperadorNavigation)
                    .HasForeignKey(d => d.IdOperador)
                    .HasConstraintName("FK_Contrato_Utilizador1");

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

            modelBuilder.Entity<PacoteComercial>(entity =>
            {
                entity.HasOne(d => d.IdPacoteComercialDetalhesNavigation)
                    .WithMany(p => p.PacoteComercial)
                    .HasForeignKey(d => d.IdPacoteComercialDetalhes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pacote__Comercial_Pacote_Comercial_Detalhes");
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

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Utilizador)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Utilizador_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
