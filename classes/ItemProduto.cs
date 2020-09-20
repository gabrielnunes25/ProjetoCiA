using System;

public class ItemProduto
{
    //VARIÁVEIS
    public int id {get; set;}
    public Produto produto {get; set;}
    public int quantidade {get; set;}

    //CONSTRUTOR
    public ItemProduto(int id, Produto produto, int quantidade)
    {
        this.id = id;
        this.produto = produto;
        this.quantidade = quantidade;
    }

    //MÉTODODS
    public void dados()
    {
        Console.WriteLine("ID: " + this.id);
        this.produto.dados();
        Console.WriteLine("Quantidade: " + this.quantidade);
        Console.WriteLine($"Preço total: R$ {this.precoItemProduto()}");
    }

    public float precoItemProduto()
    {
        float precoTotal;

        precoTotal = this.quantidade * this.produto.preco;

        return precoTotal;
    }

}
