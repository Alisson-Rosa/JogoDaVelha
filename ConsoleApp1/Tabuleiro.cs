namespace JogoDaVelha
{
    class Tabuleiro
    {
        private char[,] celulas = new char[3, 3];

        public void GerarTabuleiro(Jogador jogador1, Jogador jogador2, int vez, bool isMostrarDetalhes)
        {
            if (isMostrarDetalhes)
            {
                Console.WriteLine(jogador1.jogadorStr() + ":\nSimobolo atual: " + jogador1.Simbolo + "\nPontos: " + jogador1.Pontos + "\n\n");
                Console.WriteLine(jogador2.jogadorStr() + ":\nSimobolo atual: " + jogador2.Simbolo + "\nPontos: " + jogador2.Pontos + "\n\n");
            }
            
            Console.WriteLine();
            Console.WriteLine("\t\t {0} | {1} | {2} ", celulas[0, 0], celulas[0, 1], celulas[0, 2]);
            Console.WriteLine("\t\t ---------");
            Console.WriteLine("\t\t {0} | {1} | {2} ", celulas[1, 0], celulas[1, 1], celulas[1, 2]);
            Console.WriteLine("\t\t ---------");
            Console.WriteLine("\t\t {0} | {1} | {2} ", celulas[2, 0], celulas[2, 1], celulas[2, 2]);
            Console.WriteLine();

            if (isMostrarDetalhes)
            {
                if (vez == 1)
                {
                    Console.WriteLine("\nÉ a vez do jogador 1 (" + jogador1.Nome + ")");
                }
                else
                {
                    Console.WriteLine("\nÉ a vez do jogador 2 (" + jogador2.Nome + ")");
                }
            }
        }

        public void Limpar()
        {
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    celulas[linha, coluna] = ' ';
                }
            }
        }

        public bool ValidaJogada(string linhaStr, string colunaStr, out int linha, out int coluna)
        {
            linha = 0; coluna = 0;
            if(!int.TryParse(linhaStr, out linha))
            {
                Console.WriteLine("A linha digitada não é um número inteiro válido.\nTente Novamente!");
                return false;
            }

            if (!int.TryParse(colunaStr, out coluna))
            {
                Console.WriteLine("A coluna digitada não é um número inteiro válido.\nTente Novamente!");
                return false;
            }

            if (linha < 0 || linha > 2)
            {
                Console.WriteLine("A linha não respeita o tamanho do tabuleiro (0 à 2).\nTente Novamente!");
                return false;
            }

            if(coluna < 0 || coluna > 2)
            {
                Console.WriteLine("A coluna não respeita o tamanho do tabuleiro (0 à 2).\nTente Novamente!");
                return false;
            }

            if(celulas[linha, coluna] != ' ')
            {
                Console.WriteLine("A posição selecionada já está preenchida.\nTente Novamente!");
                return false;
            }

            return true;
        }

        public void RealizarJogada(int linha, int coluna, char simbolo)
        {
            celulas[linha, coluna] = simbolo;
        }

        public bool TemVencedor(out char simboloVencedor)
        {
            // Verificar linhas
            for (int linha = 0; linha < 3; linha++)
            {
                if (celulas[linha, 0] != ' ' && celulas[linha, 0] == celulas[linha, 1] && celulas[linha, 1] == celulas[linha, 2])
                {
                    simboloVencedor = celulas[linha, 0];
                    return true;
                }
            }

            // Verificar colunas
            for (int coluna = 0; coluna < 3; coluna++)
            {
                if (celulas[0, coluna] != ' ' && celulas[0, coluna] == celulas[1, coluna] && celulas[1, coluna] == celulas[2, coluna])
                {
                    simboloVencedor = celulas[0, coluna];
                    return true;
                }
            }

            // Verificar diagonais
            if (celulas[0, 0] != ' ' && celulas[0, 0] == celulas[1, 1] && celulas[1, 1] == celulas[2, 2])
            {
                simboloVencedor = celulas[0, 0];
                return true;
            }

            if (celulas[0, 2] != ' ' && celulas[0, 2] == celulas[1, 1] && celulas[1, 1] == celulas[2, 0])
            {
                simboloVencedor = celulas[0, 2];
                return true;
            }

            simboloVencedor = ' ';
            Console.Clear();
            return false;
        }

        public bool PodeTerVencedor(out bool isEmpate)
        {
            isEmpate = false;
            List<char> simbolos = new List<char>();
            simbolos.Add('X');
            simbolos.Add('O');
            foreach (char simbolo in simbolos) { 

                // Verificar linhas
                for (int linha = 0; linha < 3; linha++)
                {   
                    if ((simbolo == celulas[linha, 0] || celulas[linha, 0] == ' ') && (simbolo == celulas[linha, 1] || ' ' == celulas[linha, 1]) && (simbolo == celulas[linha, 2] || ' ' == celulas[linha, 2]))
                    {
                        return true;
                    }
                }

                // Verificar colunas
                for (int coluna = 0; coluna < 3; coluna++) //TODO Recriar lógica para colunase diagonais
                {
                    if ((simbolo == celulas[0, coluna] || celulas[0, coluna]  == ' ') && (simbolo == celulas[1, coluna] || celulas[1, coluna] == ' ') && (simbolo == celulas[2, coluna] || celulas[2, coluna] == ' '))
                    {
                        return true;
                    }
                }

                // Verificar diagonais
                if ((celulas[0, 0] == ' ' || celulas[0, 0] == simbolo) && (celulas[1, 1] == ' ' || celulas[1, 1] == simbolo) && (celulas[2, 2] == ' ' || celulas[2, 2] == simbolo))
                {
                    return true;
                }

                if ((celulas[0, 2] == ' ' || celulas[0, 2] == simbolo) && (celulas[1, 1] == ' ' || celulas[1, 1] == simbolo) && (celulas[2, 0] == ' ' || celulas[2, 0] == simbolo))
                {
                    return true;
                }

            }
            Console.Clear();
            isEmpate = true;
            return false;
        }
    }
}