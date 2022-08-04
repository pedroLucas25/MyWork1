using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_My_Work_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOrganizationService service = ConnectionFactory.GetService();

            int option;

            const int pequena = 552280000;
            const int media = 552280001;
            const int grande = 552280002;

            var alex = new Guid("80ac35a0-01af-ea11-a812-000d3a8b3ec6");
            var avery = new Guid("79ae8582-84bb-ea11-a812-000d3a8b3ec6");
            var cacilia = new Guid("d1bf9a01-b056-e711-abaa-00155d701c02");

            do
            {
                Console.WriteLine("Olá, bem vindo ao primeiro trabalho do curso para desenvolvedor Dynamics!");
                Console.WriteLine("Por favor indique uma das opções abaixo:");
                Console.WriteLine("1 - Adicionar uma nova conta.");
                Console.WriteLine("2 - Sair do programa.");
                Console.Write("Digite sua opção: ");
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    ///////////////// Insira o código aqui //////////////////
                    Console.Clear();

                    Console.Write("Por favor, informe o nome da Conta: ");
                    var nome_conta = Console.ReadLine();
                    Console.Write("Por favor, informe o número de telefone da conta: ");
                    var numero_telefone = Console.ReadLine();
                    Console.Write("Por favor, informe a taxa de câmbio da conta: ");
                    var cambio = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Por favor, informe total de produtos da conta: ");
                    var numero_produtos = Convert.ToInt32(Console.ReadLine());
                    

                    Console.WriteLine("Indique o porte da empresa, sendo:");
                    Console.WriteLine("1 - Pequena");
                    Console.WriteLine("2 - Média");
                    Console.WriteLine("3 - Grande");
                    Console.Write("Código: ");
                    option = Convert.ToInt32(Console.ReadLine());

                    OptionSetValue porte_empresa = new OptionSetValue();

                    while (option != 1 && option != 2 && option != 3)
                    {
                        Console.Write("Opção inválida!! Digite novamente: ");
                        option = Convert.ToInt32(Console.ReadLine());
                    }

                    if (option == 1)
                    {
                        porte_empresa = new OptionSetValue(pequena);
                    }
                    if (option == 2)
                    {
                        porte_empresa = new OptionSetValue(media);
                    }
                    if (option == 3)
                    {
                        porte_empresa = new OptionSetValue(grande);
                    }

                    Console.WriteLine("Indique um dos contatos abaixo:");
                    Console.WriteLine("1 - Alex");
                    Console.WriteLine("2 - Avery");
                    Console.WriteLine("3 - Cacilia");
                    Console.Write("Código: ");
                    option = Convert.ToInt32(Console.ReadLine());

                    while (option != 1 && option != 2 && option != 3)
                    {
                        Console.Write("Opção inválida!! Digite novamente: ");
                        option = Convert.ToInt32(Console.ReadLine());
                    }

                    Entity conta = new Entity("account");

                    if (option == 1)
                    {
                        conta["primarycontactid"] = new EntityReference("contact", alex);
                    }
                    if (option == 2)
                    {
                        conta["primarycontactid"] = new EntityReference("contact", avery);
                    }
                    if (option == 3)
                    {
                        conta["primarycontactid"] = new EntityReference("contact", cacilia);
                    }                    

                    conta["name"] = nome_conta;
                    conta["telephone1"] = numero_telefone;
                    conta["exchangerate"] = cambio;
                    conta["pedro_totaldeprodutos"] = numero_produtos;
                    conta["pedro_portedaempresa"] = porte_empresa;

                    Console.WriteLine("Você deseja criar um contato para essa conta? (s/n)");
                    var create_contact = Console.ReadLine();

                    while (create_contact != "s" && create_contact != "n")
                    {
                        Console.Write("Opção inválida!! Digite novamente: ");
                        create_contact = Console.ReadLine();
                    }                    
                    

                    if (create_contact == "s")
                    {
                        Guid accountId = service.Create(conta);

                        Console.Clear();

                        Console.Write("Por favor, informe o primeiro nome: ");
                        var primeiro_nome = Console.ReadLine();
                        Console.Write("Por favor, informe o sobrenome: ");
                        var sobrenome = Console.ReadLine();
                        Console.Write("Por favor, informe o número de telefone do contato: ");
                        var telefone_contato = Console.ReadLine();

                        Entity contato = new Entity("contact");

                        contato["firstname"] = primeiro_nome;
                        contato["lastname"] = sobrenome;
                        contato["telephone1"] = telefone_contato;
                        contato["parentcustomerid"] = new EntityReference("account", accountId);

                        service.Create(contato);

                        Console.WriteLine("Conta adicionada com sucesso!!");
                        Console.WriteLine("Contato adicionado com sucesso!!");
                        Console.WriteLine("Pressione qualquer tecla para sair!");
                        Console.ReadKey();
                        break;
                    }
                    if (create_contact == "n")
                    {
                        service.Create(conta);

                        Console.WriteLine("Conta adicionada com sucesso!!");
                        Console.WriteLine("Pressione qualquer tecla para sair!");
                        Console.ReadKey();
                        break;
                    }

                    //////////////////////////////////////////////////////////
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar o progama!");
                    Console.WriteLine("Pressione qualquer tecla para sair!");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para voltar!");
                    Console.ReadKey();
                    Console.Clear();
                }             

            } while (option != 2);
                
        }
        
    }
}
