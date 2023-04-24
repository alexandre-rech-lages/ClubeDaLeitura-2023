using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaAmigo : Tela
    {
        RepositorioAmigo repositorioAmigo;

        public TelaAmigo(RepositorioAmigo repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }

        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos \n");
            Console.WriteLine("Digite 1 para Inserir Amigo");
            Console.WriteLine("Digite 2 para Visualizar Amigos");
            Console.WriteLine("Digite 3 para Editar Amigos");
            Console.WriteLine("Digite 4 para Excluir Amigos");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }


        public void InserirNovoAmigo()
        {
            MostrarCabecalho("Cadastro de Amigos", "Inserindo um novo amigo...");

            Amigo amigo = ObterAmigo();

            repositorioAmigo.Inserir(amigo);

            MostrarMensagem("Amigo inserido com sucesso!", ConsoleColor.Green);
        }

        private Amigo ObterAmigo()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo(nome, nomeResponsavel, telefone, endereco);

            return amigo;
        }

        public void EditarAmigos()
        {
            MostrarCabecalho("Cadastro de Amigos", "Inserindo um novo amigo...");

            VisualizarAmigos(false);

            Console.WriteLine();

            Console.Write("Digite o id do Amigo: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Amigo amigoAtualizado = ObterAmigo();

            repositorioAmigo.Editar(id, amigoAtualizado);

            MostrarMensagem("Amigo editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirAmigos()
        {
            MostrarCabecalho("Cadastro de Amigos", "Excluindo um amigo já cadastrado...");

            VisualizarAmigos(false);

            Console.WriteLine();

            Console.Write("Digite o id do amigo: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Amigo amigo = repositorioAmigo.SelecionarPorId(id);

            repositorioAmigo.Excluir(id);

            MostrarMensagem("Amigo excluído com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarAmigos(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Amigos", "Visualizando amigos já cadastrados...");

            ArrayList amigos = repositorioAmigo.SelecionarTodos();

            if (amigos.Count == 0)
            {
                MostrarMensagem("Nenhuma amigo cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(amigos);
        }

        private void MostrarTabela(ArrayList amigos)
        {
            Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", "Id", "Nome", "Telefone");

            Console.WriteLine("-------------------------------------------------------------------------");

            foreach (Amigo amigo in amigos)
            {
                Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", amigo.id, amigo.nome, amigo.telefone);
            }
        }
    }
}
