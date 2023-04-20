using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class TelaRevista : Tela
    {
        public RepositorioRevista repositorioRevista;
        public RepositorioCaixa repositorioCaixa;
        public TelaCaixa telaCaixa;

        public TelaRevista(RepositorioRevista repositorioRevista, 
            RepositorioCaixa repositorioCaixa, TelaCaixa telaCaixa)
        {
            this.repositorioRevista = repositorioRevista;
            this.repositorioCaixa = repositorioCaixa;
            this.telaCaixa = telaCaixa;
        }

        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine( "Cadastro de Revistas \n" );

            Console.WriteLine("Digite 1 para Inserir Revista");
            Console.WriteLine("Digite 2 para Visualizar Revistas");
            Console.WriteLine("Digite 3 para Editar Revistas");
            Console.WriteLine("Digite 4 para Excluir Revistas");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovaRevista()
        {
            MostrarCabecalho("Cadastro de Revistas", "Inserindo uma nova revista...");

            Revista revista = ObterRevista();

            repositorioRevista.Inserir(revista);

            MostrarMensagem("Revista inserida com sucesso!", ConsoleColor.Green);
        }

        private Revista ObterRevista()
        {
            telaCaixa.VisualizarCaixas(false);

            Console.Write( "Digite o id da caixa: " );
            int idCaixa = Convert.ToInt32(Console.ReadLine());            
            Caixa caixa = repositorioCaixa.SelecionarPorId(idCaixa);

            Console.Write("Digite o título: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o ano: ");
            int ano = Convert.ToInt32( Console.ReadLine() );

            Console.Write("Digite a edição: ");
            int edicao = Convert.ToInt32(Console.ReadLine());

            Revista revista = new Revista(titulo, edicao, ano, caixa);

            return revista;
        }

        public void VisualizarRevistas(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Revistas", "Visualizando revistas já cadastradas...");

            ArrayList revistas = repositorioRevista.SelecionarTodos();

            if (revistas.Count == 0)
            {
                MostrarMensagem("Nenhuma revista cadastrada", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(revistas);
        }

        private void MostrarTabela(ArrayList revistas)
        {
            Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", "Id", "Título", "Cor da Caixa");

            Console.WriteLine("---------------------------------------------------------");

            foreach (Revista revista in revistas)
            {
                Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", revista.id, revista.titulo, revista.caixa.cor);
            }
        }

        public void EditarRevistas()
        {
            MostrarCabecalho("Cadastro de Revistas", "Editando uma revista já cadastrada...");

            VisualizarRevistas(false);

            Console.WriteLine();

            Console.Write("Digite o id da revista: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Revista revistaAtualizada = ObterRevista();

            repositorioRevista.Editar(id, revistaAtualizada);

            MostrarMensagem("Revista editada com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirRevistas()
        {
            MostrarCabecalho("Cadastro de Revistas", "Excluindo uma revista já cadastrada...");

            VisualizarRevistas(false);

            Console.WriteLine();

            Console.Write("Digite o id da revista: ");
            int id = Convert.ToInt32(Console.ReadLine());

            repositorioRevista.Excluir(id);

            MostrarMensagem("Revista excluída com sucesso!", ConsoleColor.Green);
        }
    }
}
