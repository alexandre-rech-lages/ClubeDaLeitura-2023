using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista : RepositorioBase
    {
        public RepositorioRevista(ArrayList lista) : base(lista)
        {
        }

        public override Revista SelecionarPorId(int id)
        {
            Revista revistaSelecionada = (Revista)base.SelecionarPorId(id);        

            return revistaSelecionada;
        }      

        public bool EstaCaixaTemRevista(Caixa caixa)
        {
            bool caixaTemRevista = false;

            foreach (Revista revista in listaRegistros)
            {
                if (revista.caixa.id == caixa.id)
                {
                    caixaTemRevista = true;
                    break;
                }
            }

            return caixaTemRevista;
        }
    }
}
