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

            InsereDistritos(context);
            InserePacotesComerciaisFicticios(context);
            InserePromoesFicticias(context);

            InsereRolesFicticios(context);
            InsereUtilizadoresFicticios(context);
            InsereOperadoresFicticiasParaTestar(context);

            InsereConteudoExtraFicticias(context);
            //InserePacotePromocoaoFicticias(context);
            //InsereContratoFicticias(context);

            


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
            Distrito Guarda = context.Distrito.FirstOrDefault(r => r.Nome == "Guarda");
            Distrito Viseu = context.Distrito.FirstOrDefault(r => r.Nome == "Viseu");
            Distrito Lisboa = context.Distrito.FirstOrDefault(r => r.Nome == "Lisboa");
            Distrito Leiria = context.Distrito.FirstOrDefault(r => r.Nome == "Leiria");
            Distrito Porto = context.Distrito.FirstOrDefault(r => r.Nome == "Porto");

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
                        IdRoleNavigation = rolecliente,
                        DataCriacao = new DateTime(1994, 09, 14),
                        IdDistritoNavigation = Guarda,

                    },

                    new Utilizador
                    {
                        Nome ="Maria da Conceição Santos Nunes" ,
                        DataNascimento = new DateTime(1987, 12, 29),
                        Morada ="Avenida da Fortaleza, nº2, 2º direito, 2340-786 Oliveira do Hospital",
                        Contacto = "961370629",
                        Email ="operador@upmobile.com" ,
                        NContribuinte = "267093158",
                        NIdentificacao = "10679234",
                        Ativo = true,
                        LocalTrabalho = "",
                        IdRoleNavigation = roleoperador,
                        DataCriacao = new DateTime(1994, 09, 14),
                        IdDistritoNavigation = Viseu,
                    },

                    new Utilizador
                    {
                        Nome ="João Felix Antunes" ,
                        DataNascimento = new DateTime(1987, 12, 10),
                        Morada ="Avenida da Mira, nº4, 2340-786 Oliveira do Hospital",
                        Contacto = "961370529",
                        Email ="jantunes@upmobile.com" ,
                        NContribuinte = "206905068",
                        NIdentificacao = "10679231",
                        Ativo = true,
                        LocalTrabalho = "",
                        IdRoleNavigation = roleoperador,
                        DataCriacao = new DateTime(1994, 09, 10),
                        IdDistritoNavigation = Lisboa,
                    },

                    new Utilizador
                    {
                        Nome ="Rui Fonseca Pires" ,
                        DataNascimento = new DateTime(1988, 08, 15),
                        Morada ="Rua Gizo, nº6, 2340-786 Oliveira do Hospital",
                        Contacto = "961360529",
                        Email ="rpires@upmobile.com" ,
                        NContribuinte = "230965520",
                        NIdentificacao = "10679232",
                        Ativo = true,
                        LocalTrabalho = "",
                        IdRoleNavigation = roleoperador,
                        DataCriacao = new DateTime(1992, 10, 10),
                        IdDistritoNavigation = Leiria,
                    },

                    new Utilizador
                    {
                        Nome ="Rute Fonseca Lopes" ,
                        DataNascimento = new DateTime(1986, 03, 22),
                        Morada ="Rua Vai e Vem, nº6, 2340-786 Oliveira do Hospital",
                        Contacto = "931360529",
                        Email ="Rlopes@upmobile.com" ,
                        NContribuinte = "274099063",
                        NIdentificacao = "10679233",
                        Ativo = true,
                        LocalTrabalho = "",
                        IdRoleNavigation = roleoperador,
                        DataCriacao = new DateTime(1990, 01, 02),
                        IdDistritoNavigation = Porto,
                    }


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


        private static void InsereOperadoresFicticiasParaTestar(UPMobileContext context)
        {
            if (context.Utilizador.Any()) return;

            Role roleoperador = context.Role.FirstOrDefault(r => r.Nome == "Operador");
            Distrito Guarda = context.Distrito.FirstOrDefault(r => r.Nome == "Guarda");
            Distrito Viseu = context.Distrito.FirstOrDefault(r => r.Nome == "Viseu");
            Distrito Leiria = context.Distrito.FirstOrDefault(r => r.Nome == "Leiria");

            for (int i = 0; i < 9; i++)
            {
                context.Utilizador.Add(new Utilizador
                {
                    Nome = "Pedro Miguel Lopes " + i,
                    DataNascimento = new DateTime(1994, 09, 03).AddDays(i),
                    Morada = "Praça da Alegria, 9, 1980-330 Sarzedo " + i,
                    Contacto = "91830619" + i,
                    Email = "Plopes@sapo.pt" + i,
                    NContribuinte = "26665980" + i,
                    NIdentificacao = "1173920" + i,
                    Ativo = true,
                    LocalTrabalho = "",
                    IdRoleNavigation = roleoperador,
                    DataCriacao = new DateTime(1994, 09, 02).AddDays(i),
                    IdDistritoNavigation = Guarda,
                });
            }

            for (int i = 0; i < 9; i++)
            {
                context.Utilizador.Add(new Utilizador
                {
                    Nome = "João António Miguel " + i,
                    DataNascimento = new DateTime(1990, 05, 01).AddDays(i),
                    Morada = "Praça da Paez, 9, 1980-330 Mocho " + i,
                    Contacto = "93830629" + i,
                    Email = "jmiguel@sapo.pt" + i,
                    NContribuinte = "28064366" + i,
                    NIdentificacao = "1273920" + i,
                    Ativo = true,
                    LocalTrabalho = "",
                    IdRoleNavigation = roleoperador,
                    DataCriacao = new DateTime(1988, 08, 02).AddDays(i),
                    IdDistritoNavigation = Viseu,
                });
            }

            for (int i = 0; i < 9; i++)
            {
                context.Utilizador.Add(new Utilizador
                {
                    Nome = "Rute Fonseca Dias " + i,
                    DataNascimento = new DateTime(1987, 02, 02).AddDays(i),
                    Morada = "Rua Paz, 8, 1980-330 Figueiras " + i,
                    Contacto = "92830629" + i,
                    Email = "rdias@sapo.pt" + i,
                    NContribuinte = "28207738" + i,
                    NIdentificacao = "1275720" + i,
                    Ativo = true,
                    LocalTrabalho = "",
                    IdRoleNavigation = roleoperador,
                    DataCriacao = new DateTime(2004, 09, 07).AddDays(i),
                    IdDistritoNavigation = Leiria,
                });
            }

            context.SaveChanges();

        }



        private static void InsereConteudoExtraFicticias(UPMobileContext context)
        {
            if (context.ConteudoExtra.Any()) return;

            context.ConteudoExtra.AddRange(new ConteudoExtra[]
            {
                new ConteudoExtra
                {
                    Nome = "Sport TV",
                    Descricao = "Adira aos canais SportTV. São 6 canais totalmente dedicados ao desporto",
                    DataInicioComercializacao=new DateTime(2021, 01, 01),
                    DataFimComercializacao=new DateTime(2021, 12, 31),
                    Preco=27.99M,
                    Ativo = true
                },

                new ConteudoExtra
                {
                    Nome = "Netflix",
                    Descricao = "Veja séries e filmes originais na Netflix Portugal, na Tv Box da UPmobile",
                    DataInicioComercializacao=new DateTime(2021, 01, 01),
                    DataFimComercializacao=new DateTime(2021, 12, 31),
                    Preco=13.99M,
                    Ativo = true
                },

                new ConteudoExtra
                {
                    Nome = "Amazon Prime",
                    Descricao = "Aproveite o conteúdo exclusivo que a Amazon tem para si. Séries de TV e filmes populares e originais únicos.",
                    DataInicioComercializacao=new DateTime(2021, 01, 01),
                    DataFimComercializacao=new DateTime(2021, 12, 31),
                    Preco=5.99M,
                    Ativo = true
                },

                new ConteudoExtra
                {
                    Nome = "Playboy TV",
                    Descricao = "O melhor conteúdo da industria porno está na Playboy TV. Disponível na sua Tv Box também em HD",
                    DataInicioComercializacao=new DateTime(2021, 01, 01),
                    DataFimComercializacao=new DateTime(2021, 12, 31),
                    Preco=15.99M,
                    Ativo = true
                },

                new ConteudoExtra
                {
                    Nome = "Benfica TV",
                    Descricao = "Não perca os jogos do S.L. Benfica em casa e ainda as prestações do seu clube em várias outras modalidades",
                    DataInicioComercializacao=new DateTime(2021, 01, 01),
                    DataFimComercializacao=new DateTime(2021, 12, 31),
                    Preco=9.99M,
                    Ativo = true
                },

                new ConteudoExtra
                {
                    Nome = "Dog TV",
                    Descricao = "Se o animal de quatro patas é o seu melhor amigo, susbcreva o Dog TV. Gargalhadas, shows e ensinamentos, não vão faltar",
                    DataInicioComercializacao=new DateTime(2021, 01, 01),
                    DataFimComercializacao=new DateTime(2021, 12, 31),
                    Preco=5.99M,
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

                    Nome = "SportTV",
                    Descricao = "Oferta dos canais SportTV. Oferta válida para os Pacotes UP Mega, UP Mega C, UP TV e UP Max.",
                    DataInicio = new DateTime(2021, 01, 01),
                    DataFim= new DateTime(2021, 12, 31),
                    Preco= 0,
                    Conteudo="Oferta dos canais SportTV",
                    Ativo = true

                },

                new Promocao
                {

                    Nome = "Tchill",
                    Descricao = "É no sofá que te sentes bem? Então relaxa. Adere a um pacote UPmobile e tem oferta de Netflix e HBO por 3 meses. Oferta válida para os Pacotes UP Smile, UP Super, UP Mega, UP Mega C, UP TV e UP Max.",
                    DataInicio = new DateTime(2021, 01, 01),
                    DataFim= new DateTime(2021, 12, 31),
                    Preco= 0,
                    Conteudo="Oferta de Netflix e HBO",
                    Ativo = true

                },

                
                new Promocao
                {

                    Nome = "Móvel Grátis",
                    Descricao = "Fala, escreve, navega pela Internet sem pagares nada. Oferta de um serviço móvel. Oferta válida para os Pacotes UP Mega, UP Mega C, UP TV e UP Max.",
                    DataInicio = new DateTime(2021, 01, 01),
                    DataFim= new DateTime(2021, 12, 31),
                    Preco=10,
                    Conteudo="Oferta de um serviço móvel gratuito",
                    Ativo = true

                },

                new Promocao
                {

                    Nome = "Desconto UP-15",
                    Descricao = "Como presente de Boas-Vindas à UPmobile, fazemos questão de te oferecer um desconto de 15€ no 1º mês. Oferta válida para os Pacotes UP Smile, UP Super, UP Mega, UP Mega C, UP TV e UP Max.",
                    DataInicio = new DateTime(2021, 01, 01),
                    DataFim= new DateTime(2021, 12, 31),
                    Preco=15,
                    Conteudo="Desconto de  15€ no 1º mês.",
                    Ativo = true

                },

                new Promocao
                {

                    Nome = "Desconto UP-5",
                    Descricao = "É fazer as contas! Durante 12 meses damos-te um desconto de 5€ mensalmente. Oferta válida para os Pacotes UP Mega, UP Mega C, UP TV e UP Max.",
                    DataInicio = new DateTime(2021, 01, 01),
                    DataFim= new DateTime(2021, 12, 31),
                    Preco=5,
                    Conteudo="Desconto de 5€ durante 12 meses.",
                    Ativo = true

                },

                new Promocao
                {

                    Nome = "Sem Promoção",
                    Descricao = "Se nenhuma das nossas promoções se adequa a ti, não te preocupes. Se prometemos ser UP, cumprimos. Contacta-nos e descobre ofertas especiais que temos para ti.",
                    DataInicio = new DateTime(2021, 01, 01),
                    DataFim= new DateTime(2021, 12, 31),
                    Preco= 0,
                    Conteudo="Mediante consulta.",
                    Ativo = true

                }

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

        private static void InsereDistritos(UPMobileContext context)
        {
            if (context.Distrito.Any()) return;

            context.Distrito.AddRange(new Distrito[]
            {
                new Distrito
                {
                    Nome = "Aveiro",
                },

                new Distrito
                {
                    Nome = "Beja",
                },

                new Distrito
                {
                    Nome = "Bragança",
                },

                new Distrito
                {
                    Nome = "Castelo Branco",
                },

                new Distrito
                {
                    Nome = "Coimbra",
                },

               
                new Distrito
                {
                    Nome = "Évora",
                },

                new Distrito
                {
                    Nome = "Faro",
                },

                new Distrito
                {
                    Nome = "Guarda",
                },

                new Distrito
                {
                    Nome = "Leiria",
                },

                new Distrito
                {
                    Nome = "Lisboa",
                },

                new Distrito
                {
                    Nome = "Portalegre",
                },

                new Distrito
                {
                    Nome = "Porto",
                },

                new Distrito
                {
                    Nome = "Santarém",
                },

                new Distrito
                {
                    Nome = "Setúbal",
                },

                new Distrito
                {
                    Nome = "Viana do Castelo",
                },

                new Distrito
                {
                    Nome = "Vila Real",
                },

                new Distrito
                {
                    Nome = "Viseu",
                },
            });  

            context.SaveChanges();
        }

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
                        Internet = "250 MB",
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


        //private static void InsereContratoFicticias(UPMobileContext context)

        //{
        //    if (context.Contrato.Any()) return;

        //    context.Contrato.AddRange(new Contrato[]
        //    {
        //        new Contrato
        //        {
        //            IdCliente = 2004,
        //            IdOperador = null,
        //            IdPacoteComercialPromocao = 1,
        //            DataInicioContrato = new DateTime(2021, 10, 15),
        //            DataFimContrato = null,
        //            MoradaFaturacao = "dada",
        //            DataFidelizacao = null,
        //            PrecoBaseInicioContrato = 12.20M,
        //            PrecoTotal = 12.20M

        //        }
        //        });

        //    context.SaveChanges();
        //}


        //private static void InserePacotePromocoaoFicticias(UPMobileContext context)

        //{
        //    if (context.PacoteComercialPromocao.Any()) return;

        //    context.PacoteComercialPromocao.AddRange(new PacoteComercialPromocao[]
        //    {
        //        new PacoteComercialPromocao
        //        {
        //            IdPromocao = 1,
        //            IdPacote = 1002,
        //            PrecoTotalPacote = 25.20M

        //        }
        //        });

        //    context.SaveChanges();
        //}



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






