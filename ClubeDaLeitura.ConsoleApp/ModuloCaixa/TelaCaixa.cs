using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCaixa : Tela
    {
        private RepositorioCaixa repositorioCaixa;
        private RepositorioRevista repositorioRevista;

        public TelaCaixa(RepositorioCaixa repositorio, RepositorioRevista repositorioRevista)
        {
            this.repositorioCaixa = repositorio;
            this.repositorioRevista = repositorioRevista;
        }

        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Caixas \n");

            Console.WriteLine("Digite 1 para Inserir Caixa");
            Console.WriteLine("Digite 2 para Visualizar Caixas");
            Console.WriteLine("Digite 3 para Editar Caixas");
            Console.WriteLine("Digite 4 para Excluir Caixas");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovaCaixa()
        {
            MostrarCabecalho("Cadastro de Caixas", "Inserindo uma nova caixa...");

            Caixa caixa = ObterCaixa();

            repositorioCaixa.Inserir(caixa);

            MostrarMensagem("Caixa inserida com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarCaixas(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Caixas", "Visualizando caixas já cadastradas...");

            ArrayList caixas = repositorioCaixa.SelecionarTodos();

            if (caixas.Count == 0)
            {
                MostrarMensagem("Nenhuma caixa cadastrada", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(caixas);

        }

        public void EditarCaixas()
        {
            MostrarCabecalho("Cadastro de Caixas", "Editando uma caixa já cadastrada...");

            VisualizarCaixas(false);

            Console.WriteLine();

            Console.Write("Digite o id da caixa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Caixa caixaAtualizada = ObterCaixa();

            repositorioCaixa.Editar(id, caixaAtualizada);

            MostrarMensagem("Caixa editada com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirCaixas()
        {
            MostrarCabecalho("Cadastro de Caixas", "Excluindo uma caixa já cadastrada...");

            VisualizarCaixas(false);

            Console.WriteLine();

            Console.Write("Digite o id da caixa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = repositorioCaixa.SelecionarPorId(id);

            bool caixaTemRevista = repositorioRevista.EstaCaixaTemRevista(caixa);

            if (caixaTemRevista)
            {
                MostrarMensagem("Esta caixa tem revista", ConsoleColor.DarkYellow);
                return;
            }

            repositorioCaixa.Excluir(id);

            MostrarMensagem("Caixa excluída com sucesso!", ConsoleColor.Green);
        }

        private void MostrarTabela(ArrayList caixas)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Etiqueta", "Cor");

            Console.WriteLine("---------------------------------------------------------");

            foreach (Caixa caixa in caixas)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", caixa.id, caixa.etiqueta, caixa.cor);
            }
        }

        private Caixa ObterCaixa()
        {
            Console.Write("Digite a cor: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a etiqueta: ");
            string etiqueta = Console.ReadLine();

            Caixa caixa = new Caixa(cor, etiqueta);

            return caixa;
        }
    }
}