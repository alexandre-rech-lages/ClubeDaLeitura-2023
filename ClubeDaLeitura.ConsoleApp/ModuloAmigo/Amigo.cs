namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class Amigo
    {
        public int id;
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;

        public Amigo(string nome, string nomeResponsavel, string telefone, string endereco)
        {
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }
    }
}
