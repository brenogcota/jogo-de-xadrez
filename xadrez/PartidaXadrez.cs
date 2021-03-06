using System;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro tab { get; private set;}
        public int turno { get; private set;}
        public Cor jogadorAtual { get; private set;}
        public bool terminada {get; private set;}

        public PartidaXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;

            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);

            tab.colocarPeca(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();

        }

        public void validarPosicaoOrigem(Posicao pos) {
            if(tab.peca(pos) == null) {
                throw new TabuleiroException("Posicao vazia");
            }
            if(jogadorAtual != tab.peca(pos).cor){
                throw new TabuleiroException("Vez do outro jogador");
            }
            if(!tab.peca(pos).existeMovimentosPossiveis()){
                throw new TabuleiroException("Movimentacao impossivel");
            }
        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino) {
            if(!tab.peca(origem).podeMoverPara(destino)) {
                throw TabuleiroException("Posicao de destino invalida");
            }
        }

        private void mudaJogador() {
            if(jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            }
            else {
                jogadorAtual = Cor.Branca;
            }
        }

        private void colocarPecas() {
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('a',1).toPosicao());

             tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a', 8).toPosicao());
        }
    }
}