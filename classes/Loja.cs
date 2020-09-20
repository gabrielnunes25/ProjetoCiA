using System;
using System.Collections.Generic;

public class Loja
{
    //VARIÁVEIS
    public string nomeFilial {get; set;}
    public string local {get; set;}
    public Estoque estoque {get; set;}
    public List<Pedido> listaPedidos {get; set;}

    //CONSTRUTOR
    public Loja(){}
    public Loja(string nomeFilial, string local, Estoque estoque, List<Pedido> listaPedidos)
    {
        this.nomeFilial = nomeFilial;
        this.local = local;
        this.estoque = estoque;
        this.listaPedidos = listaPedidos;
    }

    //MÉTODODS
    public void itensEstoque()
    {
        Console.WriteLine($"Estoque da filial {this.nomeFilial}");
        this.estoque.resumoGeral();
    }
    public void relatorioVendas()
    {
        Console.WriteLine("\nRelatório de vendas:\n");
        foreach(Pedido pedido in listaPedidos)
        {
                pedido.resumoGeral();
                Console.WriteLine("====================");
        }
    }
    public void relatorioPediosEnviados()
    {
        Console.WriteLine("\nRelatório de pedidos enviados:\n");
        foreach(Pedido pedido in listaPedidos)
        {
            if(pedido.enviado)
            {
                pedido.resumoGeral();
                Console.WriteLine("====================");
            }
        }
    }
    public void relatorioPediosPendentesEnvio()
    {
        Console.WriteLine("\nRelatório de pedidos pendetes de envio:\n");
        foreach(Pedido pedido in listaPedidos)
        {
            if(!pedido.enviado)
            {
                pedido.resumoGeral();
                Console.WriteLine("====================");
            }
        }

    }
    public Loja TrocarFilial(Loja filialParaTroca, int idItem, int quantidadeTroca)
    {
        List<ItemProduto> listaItemProduto = this.estoque.listaItemProduto;
        
        List<ItemProduto> listaItemProdutoFilial = filialParaTroca.estoque.listaItemProduto;

        bool bandeira = false;

        foreach(ItemProduto itemProduto in listaItemProduto)
        {
            if(itemProduto.id == idItem)
            {
                listaItemProduto.Remove(itemProduto);
                itemProduto.quantidade = itemProduto.quantidade - quantidadeTroca;
                listaItemProduto.Add(itemProduto);
                this.estoque.listaItemProduto =  listaItemProduto;
            }
            
        }
        foreach(ItemProduto itemProduto in listaItemProdutoFilial)
        {
            if(itemProduto.id == idItem)
            {
                listaItemProdutoFilial.Remove(itemProduto);
                itemProduto.quantidade = itemProduto.quantidade + quantidadeTroca;
                listaItemProdutoFilial.Add(itemProduto);
                filialParaTroca.estoque.listaItemProduto = listaItemProdutoFilial;
            }
        }

        if(bandeira)
        {
            Console.WriteLine("Item trocado com sucesso!");
        }
        else
        {
            Console.WriteLine("Item não encontrado!");
        }

        return filialParaTroca;
    }

}
