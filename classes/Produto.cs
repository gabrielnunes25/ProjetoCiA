using System;

public class Produto
{
    //VARIÁVEIS
    public float preco {get; set;}
    public string nome {get; set;}
    public string descricao {get; set;}

    //CONSTRUTOR
    public Produto(float preco, string nome, string descricao)
    {
        this.preco = preco;
        this.nome = nome;
        this.descricao = descricao;
    }

    //MÉTODODS
    public void dados()
    {
        Console.WriteLine("Nome: " + this.nome);
        Console.WriteLine("Descrição: " + this.descricao);
        Console.WriteLine("Preço unitário: R$ " + this.preco);
    }
    
}
