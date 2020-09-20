using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        //INICIALIZADORES
        Produto Produto01 = new Produto((float)25.90, "Blusa branca", "Blusa de algodão, gola V, branca basica");
        Produto Produto02 = new Produto((float)38.40, "Calça jeans", "calça slim, jeans claro");
        Produto Produto03 = new Produto((float)29.00, "Bermuda azul", "Bermudade de moletom azul");
        Produto Produto04 = new Produto((float)12.90, "Blusa verde", "Blusa de algodão, regata");
        Produto Produto05 = new Produto((float)17.50, "Bermuda preta", "Bermudade de tecido preta");
        Produto Produto06 = new Produto((float)52.00, "Casaco camuflado", "Casaco com tecito estilo militar, sem zíper");

        ItemProduto ItemProduto01 = new ItemProduto(01, Produto01, 5);
        ItemProduto ItemProduto02 = new ItemProduto(02, Produto02, 2);
        ItemProduto ItemProduto03 = new ItemProduto(03, Produto03, 7);
        ItemProduto ItemProduto04 = new ItemProduto(04, Produto04, 8);
        ItemProduto ItemProduto05 = new ItemProduto(05, Produto05, 10);
        ItemProduto ItemProduto06 = new ItemProduto(06, Produto06, 6);

        Estoque Estoque01 = new Estoque(new List<ItemProduto>{ItemProduto01, ItemProduto02, ItemProduto04});
        Estoque Estoque02 = new Estoque(new List<ItemProduto>{ItemProduto05, ItemProduto03, ItemProduto06});


        ItemProduto01 = new ItemProduto(01, Produto01, 3);
        ItemProduto02 = new ItemProduto(02, Produto02, 1);
        ItemProduto03 = new ItemProduto(03, Produto03, 6);
        ItemProduto04 = new ItemProduto(04, Produto03, 7);
        ItemProduto05 = new ItemProduto(05, Produto03, 15);
        ItemProduto06 = new ItemProduto(06, Produto03, 3);

        Pedido Pedido01 = new Pedido("Kleber Jorge", new List<ItemProduto>{ItemProduto01, ItemProduto06, ItemProduto04});
        Pedido01.despachar();
        Pedido Pedido02 = new Pedido("Ramulo Thiago", new List<ItemProduto>{ItemProduto02, ItemProduto05, ItemProduto03});

        Loja Loja01 = new Loja("CiA do Povo", "Gloria", Estoque02, new List<Pedido>{Pedido01, Pedido02});
        Loja Loja02 = new Loja("CiA da Galera", "Praia do Canto", Estoque02, new List<Pedido>{Pedido02, Pedido01});
    
        // string jsonString = JsonSerializer.Serialize(Loja01);
        // File.WriteAllText("./json/teste.json", jsonString);
        // string jsonString = File.ReadAllText("./json/loja02.json");
        // var Loja03 = JsonSerializer.Deserialize<Loja>(jsonString);


        //VARIÁVEIS
        bool bandeira = true;
        int escolha = 0;
        Loja lojaEscolhida = new Loja();

        //ESCOLHER LOJA
        Console.Clear();
        do{
            Console.WriteLine("Opção de loja:");
            Console.WriteLine("1 - CiA do Povo");
            Console.WriteLine("2 - Cia da Galera");
            Console.Write("Escolha (de 1 até 2): ");
            escolha = int.Parse(Console.ReadLine());

            Console.Clear();
            switch (escolha)
            {
                case 1:
                    lojaEscolhida = Loja01;
                    bandeira = false;
                    break;

                case 2:
                    lojaEscolhida = Loja02;
                    bandeira = false;
                    break;

                default:
                    Console.WriteLine("\nOpção não existe...");
                    Console.WriteLine("Favor escolher novamente!");
                    Console.WriteLine("------------------------------------------------");
                    break;
            }
        }while(bandeira);

        bandeira = true;
        escolha = 0;

        //REPETIÇÃO DO MENU
        Console.Clear();
        do
        {

        //MENU CENTRAL
        Console.WriteLine($"\n                 {lojaEscolhida.nomeFilial}");
        Console.WriteLine("------------------------------------------------");


            //OPÇÕES DO MENU
            Console.WriteLine("Opções de navegação");
            Console.WriteLine("1 - Estoque");
            Console.WriteLine("2 - Relatório de vendas");
            Console.WriteLine("3 - Relatório de pedidos enviados");
            Console.WriteLine("4 - Relatório de pedidos pendetes de envio");
            Console.WriteLine("5 - Trocar entre Filiais");
            Console.WriteLine("9 - Sair");
            Console.Write("Escolha (de 0 até 1): ");
            escolha = int.Parse(Console.ReadLine());


            //SELEÇÃO DA ESCOLHA DO USUÁRIO
            Console.Clear();
            switch (escolha)
            {
                case 1:
                    lojaEscolhida.itensEstoque();
                    break;
                
                case 2:  
                    lojaEscolhida.relatorioVendas();                    
                    break;

                case 3:
                    lojaEscolhida.relatorioPediosEnviados();
                    break;

                case 4:
                    lojaEscolhida.relatorioPediosPendentesEnvio();
                    break;

                case 5:
                    // Loja01.TrocarFilial(Loja02, 05, 5);
                    // Loja01.itensEstoque();
                    // Loja02.itensEstoque();
                    break;

                case 9:
                    bandeira = Program.sair();
                    break;

                default:
                    Console.WriteLine("\nOpção não existe...");
                    Console.WriteLine("Favor escolher novamente!");
                    Console.WriteLine("------------------------------------------------");
                    break;
            }

        } while (bandeira);
    }

    static bool sair()
    {
        Console.WriteLine("Obrigado por usar o nosso sistema!");
        Console.WriteLine("G.N.S Enterprise");

        return false;
    }

}