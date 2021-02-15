using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UP_Mobile.Models;

namespace UP_Mobile.Data
{
    public class SeedData
    {

        internal static void PreencheDadosFicticios(UPMobileContext context)
        {
            InserePacotesComerciaisFicticios(context);
            InserePromoesFicticias(context);
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


        private static void InserePacotesComerciaisFicticios(UPMobileContext context)
        {

            if (context.PacoteComercial.Any()) return;

            context.PacoteComercial.AddRange(new PacoteComercial[]
            {
                new PacoteComercial
                {

                    Nome = "UP Teste 500MB",
                    Descricao = "Pacote de internet e vais com sorte",
                    DataInicioComercializacao = new DateTime(2021,02,15),
                    DataFimComercializacao = new DateTime(2021,10,15),
                    PrecoBase = 52,
                    PeriodoFidelizacao = 12


                }

            });

            context.SaveChanges();
        }



    }
}

    