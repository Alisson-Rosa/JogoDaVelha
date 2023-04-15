namespace JogoDaVelha
{
    class Jogo
    {
        public void IniciarJogo()
        {
            Console.WriteLine();
            Console.WriteLine("\t\tBem vindo ao Jogo da Velha Dos Devs!\n\n");
            Jogador jogador1 = FormularioJogador(1);
            Jogador jogador2 = FormularioJogador(2);
            bool jogar = true;
            do
            {
                Partida(jogador1, jogador2);
                isJogarNovamente(out jogar, jogador1, jogador2);
            } while(jogar);

        }

        public void Partida(Jogador jogador1, Jogador jogador2)
        {
            Tabuleiro tabuleiro = new Tabuleiro();
            tabuleiro.Limpar();
            char simboloVencedor;
            int vez = jogador1.Simbolo == 'X' ? 1 : 2;
            Jogador jogadorAtual;
            bool isEmpate = false;
            do
            {
                tabuleiro.GerarTabuleiro(jogador1, jogador2, vez, true);
                jogadorAtual = vez == jogador1.Numero ? jogador1 : jogador2;
                vez = fazerJogada(vez, jogadorAtual, tabuleiro);
            } while (!tabuleiro.TemVencedor(out simboloVencedor) && tabuleiro.PodeTerVencedor(out isEmpate));

            tabuleiro.GerarTabuleiro(jogador1, jogador2, vez, false);

            if (isEmpate)
            {
                Console.WriteLine("\n\nO Jogo Empatou!");
                Console.WriteLine(jogador1.jogadorStr() + ":\nSimobolo atual: " + jogador1.Simbolo + "\nPontos: " + jogador1.Pontos + "\n\n");
                Console.WriteLine(jogador2.jogadorStr() + ":\nSimobolo atual: " + jogador2.Simbolo + "\nPontos: " + jogador2.Pontos + "\n\n");
                return;
            }
            
            if(simboloVencedor == jogador1.Simbolo)
            {   
                jogador1.SomarPontos();
                Console.WriteLine("\n\nParabéns " + jogador1.Nome + ". Você é o Vencedor!");
                Console.WriteLine(jogador1.jogadorStr() + ":\nSimobolo atual: " + jogador1.Simbolo + "\nPontos: " + jogador1.Pontos + "\n\n");
                Console.WriteLine(jogador2.jogadorStr() + ":\nSimobolo atual: " + jogador2.Simbolo + "\nPontos: " + jogador2.Pontos + "\n\n");
            }
            else
            {
                jogador2.SomarPontos();
                Console.WriteLine("\n\nParabéns " + jogador2.Nome + ". Você é o Vencedor!");
                Console.WriteLine(jogador1.jogadorStr() + ":\nSimobolo atual: " + jogador1.Simbolo + "\nPontos: " + jogador1.Pontos + "\n\n");
                Console.WriteLine(jogador2.jogadorStr() + ":\nSimobolo atual: " + jogador2.Simbolo + "\nPontos: " + jogador2.Pontos + "\n\n");
            }
        }

        public int fazerJogada(int vez, Jogador jogador, Tabuleiro tabuleiro) {
            string linhaStr;
            string colunaStr;
            int linha;
            int coluna;
            do
            {
                String text = "\nInsira a linha que deseja jogar (de 0 à 2)";
                InputTextos(text, out linhaStr);
                text = "\nInsira a coluna que deseja jogar (de 0 à 2)";
                InputTextos(text, out colunaStr);
            } while (!tabuleiro.ValidaJogada(linhaStr, colunaStr, out linha, out coluna));

            char simbolo = jogador.Simbolo;
            tabuleiro.RealizarJogada(linha, coluna, simbolo);
            return vez == 1 ? 2 : 1;
        }

        public Jogador FormularioJogador(int i)
        {
            string text = "Insira o nome do jogador: ";
            string nome;
            InputTextos(text, out nome);
           
             
            int numero = i;
            char simbolo = i == 1 ? 'X' : 'O';

            Console.WriteLine("Parabéns, você será o jogador " + numero + " e ira jogar com o simbolo: " + simbolo + "\n\n");
            return new Jogador(nome, simbolo, numero);
        }

        public void isJogarNovamente(out bool jogar, Jogador jogador1, Jogador jogador2)
        {
            string text = "\n\nDeseja jogar novamente? (S/N)";
            char resposta;

            InputResposta(text, out resposta);
            Console.WriteLine("\n");
            
            jogar = resposta == 'S' ? true : false;
            if (jogar)
            {
                Console.Clear();
                alternarSimbolo(jogador1, jogador2);
            }
        }

        public void InputTextos(string texto, out string input)
        {
            do
            {
                Console.WriteLine(texto);
                input = Console.ReadLine();
            } while (isBlank(input));

        }

        public void alternarSimbolo(Jogador jogador1, Jogador jogador2)
        {
            if(jogador1.Simbolo == 'X')
            {
                jogador1.Simbolo = 'O';
                jogador2.Simbolo = 'X';
            } else {
                jogador1.Simbolo = 'X';
                jogador2.Simbolo = 'O';
            }
        }


        public void InputResposta(string texto, out char input)
        {
            do
            {
                Console.WriteLine(texto);
                ConsoleKeyInfo tecla = Console.ReadKey();
                input = tecla.KeyChar;
            } while (respostaIvalida(input));

        }

        public bool isBlank(String input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("\nO valor precisa ser preenchido. Tente novamente!");
                return true;
            }

            return false;
        }

        public bool respostaIvalida(char input)
        {
            input = Char.ToUpper(input);
            if (input != 'S' && input != 'N')
            {
                Console.WriteLine("\nA resposta só pode ser 'S' ou 'N' . Tente novamente!");
                return true;
            }

            return false;
        }
    }
}