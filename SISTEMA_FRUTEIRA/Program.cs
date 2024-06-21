using System.Net.WebSockets;

namespace SISTEMA_FRUTEIRA
{
    public class Program
    {
        struct Frutas
        {
            public int Codigo;
            public string Nome;
            public float VendaKilo;
            public float QuantidadeEstoque;
        }

        static void Main(string[] args)
        {
            Frutas[] frutas = new Frutas[2];
            int contador = 0;

            void Menu()
            {
                Console.WriteLine("Sistema de Controle de Estoque - Frutamania");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("1. Cadastro Nova Fruta");
                Console.WriteLine("2. Mostrar Frutas Cadastradas");
                Console.WriteLine("3. Compra de Frutas para estoque");
                Console.WriteLine("4. Venda de Frutas para cliente");
                Console.WriteLine("5. Sair do Sistema");
            }
            
            Menu();
            
            void Retorno()
            {
                Console.ReadKey();
                Console.Clear();
                Menu();
                return;
            }
            while(true)
            {
                Console.WriteLine("Digite a opção escolhida: ");
                int opcao = int.Parse(Console.ReadLine()!);

                if (opcao == 5)
                    Environment.Exit(0);

                OpcaoEscolhida(opcao);

                void OpcaoEscolhida(int opcao)
                {
                    switch (opcao)
                    {
                        case 1:
                            CadastroFruta();
                            break;
                        case 2:
                            MostrarFruta();
                            break;
                        case 3:
                            EfetuarCompra();
                            break;
                        case 4:
                            EfetuarVenda();
                            break;
                        default: 
                            Console.WriteLine("Opção inválida!");
                            break;
                            
                    }
                }

                void CadastroFruta()
                {

                    if(contador < frutas.Length)
                    {
                        Console.Write("Nome da fruta: ");
                        frutas[contador].Nome = Console.ReadLine()!;

                        Console.Write("Preço de venda por kg: ");
                        frutas[contador].VendaKilo = float.Parse(Console.ReadLine()!);

                        Console.Write("Quantidade em estoque (kg): ");
                        frutas[contador].QuantidadeEstoque = float.Parse(Console.ReadLine()!);
                
                        Console.WriteLine("Fruta cadastrada com sucesso");

                        frutas[contador].Codigo = contador;
                        contador++;
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                    }else
                    {
                        Console.WriteLine("Exedeu o limite de frutas cadastradas");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                    }

                }
               
                void MostrarFruta()
                {
                        if (contador == 0)
                        {
                            Console.WriteLine("Nenhum cadastro no sistema");
                            Retorno();
                        }
                            Console.WriteLine("{0,-10} {1,-20} {2,10} {3,15}", "Código", "Nome", "Preço (kg)", "Estoque (kg)");
                        for (int i = 0; i < contador; i++)
                        {
                        Console.WriteLine("{0,-10} {1,-20} {2,10:C} {3,15:N2}",
                                          frutas[i].Codigo,
                                          frutas[i].Nome,
                                          frutas[i].VendaKilo,
                                          frutas[i].QuantidadeEstoque);
                        }
                        Retorno();

                }

                void EfetuarCompra()
                {
                    if (contador == 0)
                    {
                        Console.WriteLine("Ainda não há frutas cadastradas para compra.");
                        Retorno();
                    }
                        
                    Console.Write("Digite o código da fruta que deseja comprar: ");
                    int cod = int.Parse(Console.ReadLine()!);

                    if (cod >= contador || cod < 0)
                    {
                        Console.WriteLine("Código inválido!");
                        Retorno();
                    }
                    if (cod < contador)
                    {
                        Console.Write("Quantidade a ser comprada (kg): ");
                        float aumentaEstoque = float.Parse(Console.ReadLine()!);
                        frutas[cod].QuantidadeEstoque += aumentaEstoque;
                        Console.WriteLine($"{aumentaEstoque}kg de {frutas[cod].Nome} comprados com sucesso!");
                        Retorno();
                    }
                }

                void EfetuarVenda()
                {
                    if (contador == 0)
                    {
                        Console.WriteLine("Ainda não há frutas cadastradas para venda.");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                        return;
                    }
                       
                        Console.Write("Digite o código da fruta que deseja venwder: ");
                        int cod = int.Parse(Console.ReadLine()!);

                    if (cod >= contador || cod < 0) 
                    {
                        Console.WriteLine("Código inválido!");
                        Retorno();
                    }
                    
                    if (cod < contador) 
                    { 
                        Console.Write("Quantidade a ser vendida (kg): ");
                        float diminuiEstoque = float.Parse(Console.ReadLine()!);
                        frutas[cod].QuantidadeEstoque += diminuiEstoque;
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Comprovante da Venda");
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"Produto: {frutas[cod].Nome}");
                        Console.WriteLine($"Quantidade: {diminuiEstoque}");
                        Console.WriteLine($"Valor total: R${frutas[cod].VendaKilo:F2}");
                        float valorTotal = frutas[cod].VendaKilo * diminuiEstoque;
                        Console.WriteLine($"Valor Total: R$ {valorTotal:F2}");
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Venda realizada com sucesso!");
                        Retorno();
                    }                 
                }
            }



        }
    }
}


