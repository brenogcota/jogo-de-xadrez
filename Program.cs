using System;
using tabuleiro;
using xadrez;

namespace jogo_xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8,8);

            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0,1));

            tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(0,5));
            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(3,1));

            Tela.imprimirTabuleiro(tab);

            Console.ReadLine();
        }
    }
}
