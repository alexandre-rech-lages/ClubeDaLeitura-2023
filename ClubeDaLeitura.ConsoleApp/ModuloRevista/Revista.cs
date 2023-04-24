using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class Revista : Entidade
    {
        public string titulo;
        public int edicao;
        public int ano;
        public Caixa caixa;

        public Revista(string titulo, int edicao, int ano, Caixa caixa)
        {
            this.titulo = titulo;
            this.edicao = edicao;
            this.ano = ano;
            this.caixa = caixa;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Revista revistaAtualizada = (Revista)registroAtualizado;

            this.titulo = revistaAtualizada.titulo;
            this.ano = revistaAtualizada.ano;
            this.edicao = revistaAtualizada.edicao;
            this.caixa = revistaAtualizada.caixa;
        }
    }
}
