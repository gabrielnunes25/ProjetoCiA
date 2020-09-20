using System;
using System.Collections.Generic;

public class Pedido
{
    //VARIÁVEIS
    public string cliente {get; set;}
    public List<ItemProduto> listaItemProduto {get; set;}
    public bool enviado {get; private set;}

    //CONSTRUTOR
    public Pedido(string cliente, List<ItemProduto> listaItemProduto)
    {
        this.cliente = cliente;
        this.listaItemProduto = listaItemProduto;
        this.enviado = false;
    }


    //MÉTODODS
    public void despachar()
    {
        Console.WriteLine("Seu pedido foi enviado para o cliente!");
        this.enviado = true;

    }
    public void resumoGeral()
    {
        float precoTotalPedido = 0;

        Console.WriteLine($"Pedido do cliente: {this.cliente}");
        Console.WriteLine($"Os produtos pedidos foram:\n");
        foreach(ItemProduto itemProduto in listaItemProduto)
        {
            itemProduto.dados(); 

            Console.WriteLine("...");


            precoTotalPedido += itemProduto.precoItemProduto();
        }
        Console.WriteLine($"O preço total do Pedido foi de {precoTotalPedido}");

        if (this.enviado)
        {
            Console.WriteLine("\nO pedido já foi enviado!");
        }
        else
        {
            Console.WriteLine("\nO pedido ainda não foi enviado!");
        }

    }

}