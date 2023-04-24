using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa  : RepositorioBase
    {
        public RepositorioCaixa(ArrayList lista) : base(lista)
        {
        }

        public override Caixa SelecionarPorId(int id)
        {
            Caixa caixaSelecionada = (Caixa)base.SelecionarPorId(id);

            return caixaSelecionada;
        }
    }
}