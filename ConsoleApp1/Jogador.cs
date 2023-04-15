namespace JogoDaVelha
{
    class Jogador
    {
        private string nome;
        private char simbolo;
        private int numero;
        private int pontos = 0;

        public string Nome
        {
            get { return nome; }
            set { this.nome = value; }
        }

        public char Simbolo
        {
            get { return simbolo; }
            set { this.simbolo = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { this.numero = value; }
        }

        public int Pontos
        {
            get { return pontos; }
            set { this.pontos = value; }
        }

        public Jogador(string nome, char simbolo, int numero)
        {
            this.nome = nome;
            this.simbolo = simbolo;
            this.numero = numero;
        }

        public void SomarPontos()
        {
            this.pontos = this.pontos + 1;
        }

        public string jogadorStr()
        {
            return "Jogador " + numero + " (" + nome + ")";
        }
    }
}