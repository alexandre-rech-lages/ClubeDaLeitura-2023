using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista
    {
        private ArrayList listaRevistas;

        private int contador;

        public RepositorioRevista(ArrayList lista)
        {
            this.listaRevistas = lista;
        }

        public void Inserir(Revista revista)
        {
            contador++;

            revista.id = contador;

            listaRevistas.Add(revista);
        }

        internal void Editar(int id, Revista revistaAtualizada)
        {
            Revista revistaSelecionada = SelecionarPorId(id);

            revistaSelecionada.titulo = revistaAtualizada.titulo;
            revistaSelecionada.ano = revistaAtualizada.ano;
            revistaSelecionada.edicao = revistaAtualizada.edicao;
            revistaSelecionada.caixa = revistaAtualizada.caixa;
        }

        public Revista SelecionarPorId(int id)
        {
            Revista revistaSelecionada = null;

            foreach (Revista c in listaRevistas)
            {
                if (c.id == id)
                {
                    revistaSelecionada = c;
                    break;
                }
            }

            return revistaSelecionada;
        }
        public ArrayList SelecionarTodos()
        {
            return listaRevistas;
        }

        public void Excluir(int id)
        {
            Revista revista = SelecionarPorId(id);

            listaRevistas.Remove(revista);
        }

        public bool EstaCaixaTemRevista(Caixa caixa)
        {
            bool caixaTemRevista = false;

            foreach (Revista revista in listaRevistas)
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
