using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa : Entidade
    {
        //atributos
        public string cor;
        public string etiqueta;

        public Caixa(string c, string e)
        {
            cor = c;
            etiqueta = e;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Caixa caixaAtualizada = (Caixa)registroAtualizado;

            cor = caixaAtualizada.cor;
            etiqueta = caixaAtualizada.etiqueta;
        }
    }
}
