using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using UP_Mobile.Models;

namespace UP_Mobile.Data
{
    public class SeedData
    {
        private const string NOME_UTILIZADOR_ADMIN_PADRAO = "admin@upmobile.com";
        private const string NOME_UTILIZADOR_CLIENTE = "cliente@upmobile.com";
        private const string NOME_UTILIZADOR_OPERADOR = "operador@upmobile.com";
        private const string PASSWORD_UTILIZADOR_ADMIN_PADRAO = "Password123#";
        private const string PASSWORD_UTILIZADOR_CLIENTE = "Password123#";
        private const string PASSWORD_UTILIZADOR_OPERADOR = "Password123#";
        private const string ROLE_ADMINISTRADOR = "Administrador";
        private const string ROLE_OPERADOR = "Operador";
        private const string ROLE_CLIENTE = "Cliente";


        internal static void PreencheDadosFicticios(UPMobileContext context)
        {

            InserePacotesComerciaisFicticios(context);
            InserePromoesFicticias(context);

            InsereRolesFicticios(context);
            InsereUtilizadoresFicticios(context);


            InsereConteudoExtraFicticias(context);


        }



        private static void InsereRolesFicticios(UPMobileContext context)
        {
            GaranteExistenciaRole(context, "Administrador");
            GaranteExistenciaRole(context, "Operador");
            GaranteExistenciaRole(context, "Cliente");
        }

        private static void GaranteExistenciaRole(UPMobileContext context, string nome)
        {
            Role role = context.Role.FirstOrDefault(c => c.Nome == nome);
            if (role == null)
            {
                role = new Role { Nome = nome };
                context.Role.Add(role);
                context.SaveChanges();
            }
        }

        private static void InsereUtilizadoresFicticios(UPMobileContext context)
        {
            if (context.Utilizador.Any()) return;


            Role rolecliente = context.Role.FirstOrDefault(r => r.Nome == "Cliente");
            Role roleoperador = context.Role.FirstOrDefault(r => r.Nome == "Operador");

            context.Utilizador.AddRange(new Utilizador[]
            {
                    new Utilizador
                    {
                        Nome ="Pedro Francisco Silva Magalhães" ,
                        DataNascimento = new DateTime(1994, 09, 14),
                        Morada ="Praça da Alegria, nº9, 6º direito, 1980-330 Sarzedo",
                        Contacto = "918306197",
                        Email ="pepemangalhanes@sapo.pt" ,
                        NContribuinte = "236194038",
                        NIdentificacao = "11739165",
                        Ativo = true,
                        LocalTrabalho = "",
                        IdRoleNavigation = rolecliente

                    },

                    new Utilizador
                    {
                        Nome ="Maria da Conceição Santos Nunes" ,
                        DataNascimento = new DateTime(1987, 12, 29),
                        Morada ="Avenida da Fortaleza, nº2, 2º direito, 2340-786 Oliveira do Hospital",
                        Contacto = "961370629",
                        Email ="marYinunex@iol.pt" ,
                        NContribuinte = "267093158",
                        NIdentificacao = "10679234",
                        Ativo = true,
                        LocalTrabalho = "",
                        IdRoleNavigation = roleoperador

                    },

            });

            context.SaveChanges();


            //private static void InsereClientesFicticias(UPMobileContext context)
            //{
            //    if (context.Cliente.Any()) return;

            //    //InsereClientesFicticiasParaTestar(context);

            //    context.Cliente.AddRange(new Cliente[]
            //    {
            //        new Cliente
            //        {
            //            Nome ="Pedro Francisco Silva Magalhães" ,
            //            DataNascimento = new DateTime(1994, 09, 14),
            //            Morada ="Praça da Alegria, nº9, 6º direito, 1980-330 Sarzedo",
            //            Contacto = "918306197",
            //            Email ="pepemangalhanes@sapo.pt" ,
            //            NContribuinte = "236194038",
            //            NIdentificacao = "11739165"

            //        },

            //        new Cliente
            //        {
            //            Nome ="Maria da Conceição Santos Nunes" ,
            //            DataNascimento = new DateTime(1987, 12, 29),
            //            Morada ="Avenida da Fortaleza, nº2, 2º direito, 2340-786 Oliveira do Hospital",
            //            Contacto = "961370629",
            //            Email ="marYinunex@iol.pt" ,
            //            NContribuinte = "267093158",
            //            NIdentificacao = "10679234"

            //        },

            //        new Cliente
            //        {
            //            Nome ="Ana Sofia Júlia dos Prazeres Rabaça David" ,
            //            DataNascimento = new DateTime(2000, 07, 18),
            //            Morada ="Rua das Mangueiras, nº68, 1º direito, 6969-096 Amadora",
            //            Contacto = "924197630",
            //            Email ="losHermanosanajulia_8@gmail.com" ,
            //            NContribuinte = "28613026",
            //            NIdentificacao = "16791206"

            //        },

            //        new Cliente
            //        {
            //            Nome ="Patrick Manuel Paiva Constantino" ,
            //            DataNascimento = new DateTime(1995, 09, 01),
            //            Morada ="Jardim dos Ramos, nº20, RC, 5780-683 Pé de Cão" ,
            //            Contacto = "936480369",
            //            Email ="patricKaestrela_97@hotmail.com" ,
            //            NContribuinte = "234910387",
            //            NIdentificacao = "14730658"

            //        },

            //        new Cliente
            //        {
            //            Nome ="Manuel Pereira Costa" ,
            //            DataNascimento = new DateTime(1974, 04, 26),
            //            Morada ="Parque do Nascimento Jesus, nº24, 12º esquerdo, 2510-125 Venda das Raparigas",
            //            Contacto = "962412493",
            //            Email ="manuelcostaapereira@sapo.pt" ,
            //            NContribuinte = "194603876",
            //            NIdentificacao = "10348610"

            //        }

            //    });

            //    context.SaveChanges();
            //}

            //private static void InsereClientesFicticiasParaTestar(UPMobileContext context)
            //{


            //    for (int i = 0; i < 50; i++)
            //    {
            //        context.Cliente.Add(new Cliente
            //        {
            //            Nome = "Luís José Raposo Godinho" + i,
            //            DataNascimento = new DateTime(2021, 02, 01),
            //            Morada = "Bairro Nossa Senhora da Grela, nº6, 1º esquerdo, 6200-456 Covilhã" + i,
            //            Contacto = 911111111 + i,
            //            Email = "godinhozé@sapo.pt" + i,
            //            NContribuinte = 1582475628 + i,
            //            NIdentificacao = 15796852 + i
            //        });
            //    }

            //    context.SaveChanges();
            //}
        }

        private static void InsereConteudoExtraFicticias(UPMobileContext context)
        {
            if (context.ConteudoExtra.Any()) return;

            context.ConteudoExtra.AddRange(new ConteudoExtra[]
            {
                new ConteudoExtra
                {
                    Nome = "Sport TV",
                    Descricao = "Por pedido do Cliente, foi adicionado o canal Sport TV.",
                    DataInicioComercializacao=new DateTime(2021, 02, 15),
                    DataFimComercializacao=new DateTime(2021, 03, 15),
                    Preco=27.99M,
                    Ativo = true
                },

                new ConteudoExtra
                {
                    Nome = "Netflix",
                    Descricao = "Por pedido do Cliente, após um mês gratuito do serviço, foi adicionado o canal Netflix.",
                    DataInicioComercializacao=new DateTime(2020, 09, 14),
                    DataFimComercializacao=new DateTime(2020, 11, 14),
                    Preco=13.99M,
                    Ativo = true
                },

                new ConteudoExtra
                {
                    Nome = "Amazon Prime Video",
                    Descricao = "Por pedido do Cliente, após um mês gratuito do serviço, foi adicionado o canal Amazon Prime Video.",
                    DataInicioComercializacao=new DateTime(2021, 01, 19),
                    DataFimComercializacao=new DateTime(2020, 03, 19),
                    Preco=5.99M,
                    Ativo = true
                },

                new ConteudoExtra
                {
                    Nome = "Pack 5 Canais Conteúdo Adulto",
                    Descricao = "Por pedido do Cliente, após dois meses gratuitos do serviço, foram adicionados os canais Playboy (SD e HD), Venus, Sextreme e Penthouse Gold.",
                    DataInicioComercializacao=new DateTime(2020, 05, 27),
                    DataFimComercializacao=new DateTime(2020, 08, 27),
                    Preco=15.99M,
                    Ativo = true
                },

                new ConteudoExtra
                {
                    Nome = "HBO",
                    Descricao = "Por pedido do Cliente, após um período gratuito de 7 dias, foi adicionado o canal HBO.",
                    DataInicioComercializacao=new DateTime(2020, 07, 07),
                    DataFimComercializacao=new DateTime(2020, 08, 14),
                    Preco=4.99M,
                    Ativo = true
                }

            });

            context.SaveChanges();
        }

        private static void InserePromoesFicticias(UPMobileContext context)
        {
            if (context.Promocao.Any()) return;

            context.Promocao.AddRange(new Promocao[]
            {
                new Promocao
                {

                    Nome = "Promoção Sport TV",
                    Descricao = "Na compra deste pacote, oferta de 6 meses de todos os canais Sport TV",
                    DataInicio =new DateTime(2021, 02, 15),
                    DataFim=new DateTime(2022, 02, 15),
                    Preco= 19.99M,
                    Conteudo="Oferta de Sport TV",
                    Ativo = true

                },

                new Promocao
                {

                    Nome = "Promoção Tchill",
                    Descricao = "Na compra deste pacote, oferta de Netflix 6 meses + HBO 24 meses",
                    DataInicio = new DateTime(2020, 11, 24),
                    DataFim= new DateTime(2021, 11, 24),
                    Preco=15.99M,
                    Conteudo="Oferta de Netflix e HBO",
                    Ativo = true

                },

                new Promocao
                {

                    Nome = "Promoção S/Promoção",
                    Descricao = " ",
                    DataInicio =new DateTime(2020, 08, 15),
                    DataFim=new DateTime(2021, 08, 15),
                    Preco=0,
                    Conteudo=" ",
                    Ativo = true

                },

                new Promocao
                {

                    Nome = "Promoção Mensal",
                    Descricao = "Na compra deste pacote, oferta de 12 meses de desconto de 5€ mensais",
                    DataInicio =new DateTime(2021, 01, 08),
                    DataFim=new DateTime(2022, 01, 08),
                    Preco=5,
                    Conteudo="Oferta de Desconto mensal",
                    Ativo = true

                },

                new Promocao
                {

                    Nome = "Promoção 1 Mensalidade",
                    Descricao = "Na compra deste pacote, oferta da primeira mensalidade",
                    DataInicio =new DateTime(2021, 02, 15),
                    DataFim=new DateTime(2022, 02, 15),
                    Preco=34.99M,
                    Conteudo="Oferta de Mensalidade",
                    Ativo = true

                },

            });

            context.SaveChanges();
        }

        //private static void InserePromocoesFicticiasParaTestar(UPMobileContext context)
        //{


        //    for (int i = 0; i < 10; i++)
        //    {
        //        context.Promocao.Add(new Promocao
        //        {
        //            Nome = "UP Teste" + i,
        //            Descricao = "Promoção teste" + i,
        //            DataInicio = new DateTime(2021, 02, 01),
        //            DataFim = new DateTime(2021, 12, 01),
        //            Preco = i + 1,
        //            Conteudo = "Conteudo teste"
        //        });
        //    }

        //    context.SaveChanges();
        //}

        internal static async Task InsereUtilizadoresFicticiosAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            IdentityUser cliente = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, NOME_UTILIZADOR_CLIENTE, PASSWORD_UTILIZADOR_CLIENTE);
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, cliente, ROLE_CLIENTE);

            IdentityUser operador = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, NOME_UTILIZADOR_OPERADOR, PASSWORD_UTILIZADOR_OPERADOR);
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, operador, ROLE_OPERADOR);
        }


        internal static async Task InsereRolesAsync(RoleManager<IdentityRole> gestorRoles)
        {

            await CriaRoleSeNecessario(gestorRoles, ROLE_ADMINISTRADOR);
            await CriaRoleSeNecessario(gestorRoles, ROLE_OPERADOR);
            await CriaRoleSeNecessario(gestorRoles, ROLE_CLIENTE);
        }

        private static async Task CriaRoleSeNecessario(RoleManager<IdentityRole> gestorRoles, string funcao)
        {
            if (!await gestorRoles.RoleExistsAsync(funcao))
            {
                IdentityRole role = new IdentityRole(funcao);
                await gestorRoles.CreateAsync(role);
            }
        }

        internal static async Task InsereAdministradorPadraoAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            IdentityUser utilizador = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, NOME_UTILIZADOR_ADMIN_PADRAO, PASSWORD_UTILIZADOR_ADMIN_PADRAO);

            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, utilizador, ROLE_ADMINISTRADOR);
        }

        private static async Task AdicionaUtilizadorRoleSeNecessario(UserManager<IdentityUser> gestorUtilizadores, IdentityUser utilizador, string role)
        {
            if (!await gestorUtilizadores.IsInRoleAsync(utilizador, role))
            {
                await gestorUtilizadores.AddToRoleAsync(utilizador, role);
            }
        }

        private static async Task<IdentityUser> CriaUtilizadorSeNaoExiste(UserManager<IdentityUser> gestorUtilizadores, string nomeUtilizador, string password)
        {
            IdentityUser utilizador = await gestorUtilizadores.FindByNameAsync(nomeUtilizador);

            if (utilizador == null)
            {

                utilizador = new IdentityUser(nomeUtilizador);

                await gestorUtilizadores.CreateAsync(utilizador, password);
            }

            return utilizador;
        }

        private static void InserePacotesComerciaisFicticios(UPMobileContext context)
        {

            if (context.PacoteComercial.Any()) return;


            context.PacoteComercial.AddRange(new PacoteComercial[]
            {
                new PacoteComercial
                {

                    Nome = "UP Smile",
                    Descricao = "Um pacote para deixar qualquer um com um sorriso nos lábio. Incluí Internet com velocidade de 120MB; Televisão com 90 canais; Chamadas de voz ilimitadas para qualquer rede nacional. A adesão obriga a um periodo de fidelização de 24 meses.",
                    DataInicioComercializacao = new DateTime(2021,01,01),
                    DataFimComercializacao = new DateTime(2021,12,31),
                    PrecoBase = 24,
                    PeriodoFidelizacao = 24,
                    Ativo = true,
                    Internet = "120 MB",
                    Voz = "Ilimitado",
                    Tv = "90 canais",
                    Movel = null

                    },

                    new PacoteComercial
                    {

                        Nome = "UP Super",
                        Descricao = "O pacote com o essencial para qualquer um. Internet com velocidade de 120MB; Televisão com 90 canais; 1 cartão de telemóvel com 2GB/mês de internet + 1000min/SMS para todas as redes nacionais; As chamadas de voz  do serviço fixo são ilimitadas. A adesão a este pacote obriga a um periodo de fidelização de 24 meses.",
                        DataInicioComercializacao = new DateTime(2021,01,01),
                        DataFimComercializacao = new DateTime(2021,12,31),
                        PrecoBase = 34,
                        PeriodoFidelizacao = 24,
                        Ativo = true,
                        Internet = "120 MB",
                        Voz = "Ilimitado",
                        Tv = "90 canais",
                        Movel = "2GB + 1000 Min/SMS"

                    },

                    new PacoteComercial
                    {

                        Nome = "UP Mega",
                        Descricao = "Queres gastar ainda mais? Sem problemas! Temos o Mega para ti. Internet com velocidade de 250MB; Televisão com 140 canais; 1 cartão de telemóvel com 4GB + 2000 min/SMS; s chamadas de voz  do serviço fixo são ilimitadas. A adesão a este pacote obriga a um periodo de fidelização de 24 meses.",
                        DataInicioComercializacao = new DateTime(2021,01,01),
                        DataFimComercializacao = new DateTime(2021,12,31),
                        PrecoBase = 44,
                        PeriodoFidelizacao = 12,
                        Ativo = true,
                        Internet = "250 MB",
                        Voz = "Ilimitado",
                        Tv = "140 canais",
                        Movel = "4GB + 2000 Min/SMS"

                    },

                    new PacoteComercial
                    {

                        Nome = "UP Mega C",
                        Descricao = "Este é o pacote ideal para ti e para os teus. Neste pacote podes adicionar um serviço móvel por mais 5€/mês. Contas num pacote com Internet a 250MB; Televisão com 140 canais; 2 cartões de telemóvel com 4GB + 2000min/SMS; Chamadas de voz ilimitadas; As chamadas de voz  do serviço fixo são ilimitadas. A adesão a este pacote obriga a um periodo de fidelização de 24 meses.",
                        DataInicioComercializacao = new DateTime(2021,01,01),
                        DataFimComercializacao = new DateTime(2021,12,31),
                        PrecoBase = 49,
                        PeriodoFidelizacao = 12,
                        Ativo = true,
                        Internet = "250 MB",
                        Voz = "Ilimitado",
                        Tv = "140 canais",
                        Movel = "4GB + 2000 Min/SMS"

                    },

                    new PacoteComercial
                    {

                        Nome = "UP Net",
                        Descricao = "Só te interessa teres Internet? Okay. Temos então internet ilimitada com velocidade de 250MB. A adesão a este pacote obriga a um periodo de fidelização de 12 meses.",
                        DataInicioComercializacao = new DateTime(2021,01,01),
                        DataFimComercializacao = new DateTime(2021,12,31),
                        PrecoBase = 19,
                        PeriodoFidelizacao = 12,
                        Ativo = true,
                        Internet = null,
                        Voz = null,
                        Tv = null,
                        Movel = null

                    },

                    new PacoteComercial
                    {

                        Nome = "UP Tv",
                        Descricao = "Estar no sofá em frente à televisão, é onde estás bem? Temos o pacote perfeito então. Pacote com 140 canais de televisão + 3 canais premium à escolha de oferta. Incluí duas boxes e ainda oferecemos a Netflix durante 3 meses. A adesão a este pacote obriga a um periodo de fidelização de 24 meses.",
                        DataInicioComercializacao = new DateTime(2021,03,01),
                        DataFimComercializacao = new DateTime(2021,12,31),
                        PrecoBase = 84,
                        PeriodoFidelizacao = 24,
                        Ativo = true,
                        Internet = null,
                        Voz = null,
                        Tv = "140 canais + 3 premium + Netflix",
                        Movel = null

                    },

                    new PacoteComercial
                    {

                        Nome = "UP Go",
                        Descricao = "O pacote ideal para aqueles em que os dados móveis no telemóvel nunca te chegam até ao fim do mês. Neste pacote tens, serviço móvel com 4000min/SMS para todas as redes e 20GB de Internet. A adesão a este pacote obriga a um periodo de fidelização de 12 meses.",
                        DataInicioComercializacao = new DateTime(2021,01,01),
                        DataFimComercializacao = new DateTime(2021,12,31),
                        PrecoBase = 14,
                        PeriodoFidelizacao = 12,
                        Ativo = true,
                        Internet = null,
                        Voz = null,
                        Tv = null,
                        Movel = "20GB + 4000 Min/SMS"

                    },

                    new PacoteComercial
                    {

                        Nome = "UP Max",
                        Descricao = "É tudo à grande! Neste pacote é tudo ao máximo. Internet com velocidade de 250MB; Televisão com 140 canais; 1 serviço móvel com 10GB + 4000min/SMS; Chamadas de voz ilimitadas. E ainda oferta de 3 meses de Netflix. A adesão a este pacote obriga a um periodo de fidelização de 24 meses.",
                        DataInicioComercializacao = new DateTime(2021,01,01),
                        DataFimComercializacao = new DateTime(2021,12,31),
                        PrecoBase = 64,
                        PeriodoFidelizacao = 12,
                        Ativo = true,
                        Internet = "250 MB",
                        Voz = "Ilimitado",
                        Tv = "140 canais + Netflix",
                        Movel = "10GB + 4000 Min/SMS"

                    },

                    new PacoteComercial
                    {

                        Nome = "UP Voz",
                        Descricao = "Pako pako pako.. Se a referência ao tarifário pako não faz soar nenhuma campainha, não importa, nós explicamos. O UP Voz é um serviço Pré Pago de telemóvel. Carregas quando quiseres, usas como quiseres. Carregamento mínimo de 5 euros. Preço do cartão 5 euros. Sem periodo de fidelização. Obriga apenas a um carregamento ou chamada de 3 em 3 meses para manter o serviço ativo.",
                        DataInicioComercializacao = new DateTime(2021,01,01),
                        DataFimComercializacao = new DateTime(2021,12,31),
                        PrecoBase = 5,
                        PeriodoFidelizacao = 0,
                        Ativo = true,
                        Internet = null,
                        Voz = null,
                        Tv = null,
                        Movel = "Pré-pago"

                    }

            });

            context.SaveChanges();
        }

        //private static void InserePacotesComerciaisFicticiasParaTestar(UPMobileContext context)
        //{


        //for (int i = 0; i < 50; i++)
        //{
        //    context.PacoteComercial.Add(new PacoteComercial
        //    {
        //        Nome = "UP Teste 500MB" + i,
        //        Descricao = "Pacote de internet e vais com sorte" + i,
        //        DataInicioComercializacao = new DateTime(2021, 02, 15),
        //        DataFimComercializacao = new DateTime(2021, 10, 15),
        //        PrecoBase = 20 + i,
        //        PeriodoFidelizacao = 12
        //    });
        //}

        //context.SaveChanges();

        //}

        //private static void InsereOperadoresFicticias(UPMobileContext context)
        //{
        //    if (context.Operador.Any()) return;

        //    InsereOperadoresFicticiasParaTestar(context);

        //context.Operador.AddRange(new Operador[]
        //{
        //    new Operador
        //    {

        ////        Nome = "",
        //DataNascimento = ,
        //        Morada = "",
        //        Contacto =,
        //        Email = "",
        //        LocalTrabalho = "",
        //        OperadorAtivo = true

        //    }

        //});

        //context.SaveChanges();


    }
}






