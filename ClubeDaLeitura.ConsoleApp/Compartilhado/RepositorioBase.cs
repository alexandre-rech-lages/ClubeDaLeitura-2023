using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class RepositorioBase
    {
        protected ArrayList listaRegistros;

        protected int contadorRegistros = 0;

        public RepositorioBase(ArrayList lista)
        {
            listaRegistros = lista;
        }

        public void Inserir(Entidade registro)
        {
            contadorRegistros++;

            registro.id = contadorRegistros;

            listaRegistros.Add(registro);
        }

        public void Editar(int id, Entidade registroAtualizado)
        {
            Entidade registro = SelecionarPorId(id);

            registro.Atualizar(registroAtualizado);            
        }

        public void Excluir(int id)
        {
            Entidade registro = SelecionarPorId(id);

            listaRegistros.Remove(registro);
        }

        public virtual Entidade SelecionarPorId(int id)
        {
            Entidade registroSelecionado = null;

            foreach (Entidade registro in listaRegistros)
            {
                if (registro.id == id)
                {
                    registroSelecionado = registro;
                    break;
                }
            }

            return registroSelecionado;
        }

        public ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }
    }
}
