using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimo
    {
        private ArrayList listaEmprestimos;

        public RepositorioEmprestimo(ArrayList listaEmprestimos)
        {
            this.listaEmprestimos = listaEmprestimos;
        }

        private int contador;
        public void Inserir(Emprestimo emprestimo)
        {
            contador++;

            emprestimo.id = contador;

            listaEmprestimos.Add(emprestimo);
        }

        public ArrayList SelecionarTodos()
        {
            return listaEmprestimos;
        }

        public void Editar(int id, Emprestimo emprestimoAtualizado)
        {
            Emprestimo emprestimo = SelecionarPorId(id);

            emprestimo.amiguinho = emprestimoAtualizado.amiguinho;
            emprestimo.revista = emprestimoAtualizado.revista;
            emprestimo.dataEmprestimo = emprestimoAtualizado.dataEmprestimo;
            emprestimo.dataDevolucao = emprestimoAtualizado.dataDevolucao;
        }

        public void Excluir(int id)
        {
            Emprestimo emprestimo = SelecionarPorId(id);

            listaEmprestimos.Remove(emprestimo);
        }

        public Emprestimo SelecionarPorId(int id)
        {
            Emprestimo emprestimo = null;

            foreach (Emprestimo e in listaEmprestimos)
            {
                if (e.id == id)
                {
                    emprestimo = e;
                    break;
                }
            }

            return emprestimo;
        }

        public ArrayList SelecionarEmprestimosEmAberto()
        {
            ArrayList emprestimoEmAberto = new ArrayList();

            foreach (Emprestimo e in listaEmprestimos)
            {
                if (e.estaAberto)
                    emprestimoEmAberto.Add(e);
            }

            return emprestimoEmAberto;
        }

        public ArrayList SelecionarEmprestimosEmAbertoNoDia(DateTime data)
        {
            ArrayList emprestimoEmAberto = new ArrayList();

            foreach (Emprestimo e in listaEmprestimos)
            {
                if (e.estaAberto && e.dataEmprestimo.Date == data.Date)
                    emprestimoEmAberto.Add(e);
            }

            return emprestimoEmAberto;
        }

        public ArrayList SelecionarEmprestimosDoMes(int mes, int ano)
        {
            ArrayList emprestimosDoMes = new ArrayList();

            foreach (Emprestimo e in listaEmprestimos)
            {
                if (e.dataEmprestimo.Month == mes && e.dataEmprestimo.Year == ano)
                    emprestimosDoMes.Add(e);
            }

            return emprestimosDoMes;
        }
    }
}
