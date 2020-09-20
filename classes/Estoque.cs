using System;
using System.Collections.Generic;

public class Estoque
{
    //VARIÁVEIS
    public List<ItemProduto> listaItemProduto {get; set;}

    //CONSTRUTOR
    public Estoque(List<ItemProduto> listaItemProduto)
    {
        this.listaItemProduto = listaItemProduto;
    }


    //MÉTODODS
    public void resumoGeral()
    {
        // Console.WriteLine("Estes são os items em estoque:\n");
        foreach(ItemProduto itemProduto in listaItemProduto)
        {
            itemProduto.dados();
            Console.WriteLine("...");
        }
    }

}
