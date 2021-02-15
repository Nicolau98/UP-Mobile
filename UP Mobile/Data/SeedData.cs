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

    