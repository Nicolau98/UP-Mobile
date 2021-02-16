using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UP_Mobile.Models;

namespace UP_Mobile.Data
{
    public class SeedData
    {
        private const string NOME_UTILIZADOR_ADMIN_PADRAO = "admin@upmobile.com";
        private const string PASSWORD_UTILIZADOR_ADMIN_PADRAO = "Password123#";

        internal static void PreencheDadosFicticios(UPMobileContext context)
        {
            InserePacotesComerciaisFicticios(context);
            InserePromoesFicticias(context);
            InsereClientesFicticias(context);
        }

        private static void InsereClientesFicticias(UPMobileContext context)
        {
            if (context.Cliente.Any()) return;

            InsereClientesFicticiasParaTestar(context);

            //context.Promocao.AddRange(new Promocao[]
            //{
            //    new Cliente
            //    {
                    //Nome = ,
                    //DataNascimento = ,
                    //Morada = ,
                    //Contacto = ,
                    //Email = ,
                    //NContribuinte = ,
                    //NIdentificacao = 

            //    }

            //});

            //context.SaveChanges();
        }

        private static void InsereClientesFicticiasParaTestar(UPMobileContext context)
        {


            for (int i = 0; i < 50; i++)
            {
                context.Cliente.Add(new Cliente
                {
                    Nome = "UP Teste" + i,
                    DataNascimento = new DateTime(2021, 02, 01),
                    Morada = "UP Rua" + i,
                    Contacto = 911111111 + i,
                    Email = "UP Email" + i,
                    NContribuinte = 1582475628 + i,
                    NIdentificacao = 15796852 + i
                });
            }

            context.SaveChanges();
        }

        private static void InserePromoesFicticias(UPMobileContext context)
        {
            if (context.Promocao.Any()) return;

            InserePromocoesFicticiasParaTestar(context);

            //context.Promocao.AddRange(new Promocao[]
            //{
            //    new Promocao
            //    {

            //        Nome = "",
            //        Descricao = "",
            //        DataInicio =,
            //        DataFim=,
            //        Preco=,
            //        Conteudo=

            //    }

            //});

            //context.SaveChanges();
        }

        private static void InserePromocoesFicticiasParaTestar(UPMobileContext context)
        {
           

            for (int i = 0; i < 10; i++)
            {
                context.Promocao.Add(new Promocao
                {
                    Nome = "UP Teste"+ i,
                    Descricao = "Promoção teste" + i,
                    DataInicio = new DateTime(2021, 02, 01),
                    DataFim = new DateTime(2021, 12, 01),
                    Preco =i+1,
                    Conteudo = "Conteudo teste"
                });
            }

            context.SaveChanges();
        }

        internal static async Task InsereAdministradorPadraoAsync(UserManager<IdentityUser> gestorUtilizadores)
        {

            IdentityUser utilizador = await gestorUtilizadores.FindByNameAsync(NOME_UTILIZADOR_ADMIN_PADRAO);

            if (utilizador == null) { 

            utilizador = new IdentityUser(NOME_UTILIZADOR_ADMIN_PADRAO);

            await gestorUtilizadores.CreateAsync(utilizador, PASSWORD_UTILIZADOR_ADMIN_PADRAO);
            }

        }


        private static void InserePacotesComerciaisFicticios(UPMobileContext context)
        {

            if (context.PacoteComercial.Any()) return;

            InserePacotesComerciaisFicticiasParaTestar(context);

            //context.PacoteComercial.AddRange(new PacoteComercial[]
            //{
            //    new PacoteComercial
            //    {

            //        Nome = "UP Teste 500MB",
            //        Descricao = "Pacote de internet e vais com sorte",
            //        DataInicioComercializacao = new DateTime(2021,02,15),
            //        DataFimComercializacao = new DateTime(2021,10,15),
            //        PrecoBase = 52,
            //        PeriodoFidelizacao = 12


            //    }

            //});

            //context.SaveChanges();
        }

        private static void InserePacotesComerciaisFicticiasParaTestar(UPMobileContext context)
        {


            for (int i = 0; i < 50; i++)
            {
                context.PacoteComercial.Add(new PacoteComercial
                {
                    Nome = "UP Teste 500MB" + i,
                    Descricao = "Pacote de internet e vais com sorte" + i,
                    DataInicioComercializacao = new DateTime(2021, 02, 15),
                    DataFimComercializacao = new DateTime(2021, 10, 15),
                    PrecoBase = 20 + i,
                    PeriodoFidelizacao = 12
                });
            }

            context.SaveChanges();
        }



    }
}

    