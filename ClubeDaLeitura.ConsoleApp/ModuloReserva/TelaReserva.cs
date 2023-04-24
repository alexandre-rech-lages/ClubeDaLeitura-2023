using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    public class TelaReserva : Tela
    {
        private TelaRevista telaRevista;
        private RepositorioRevista repositorioRevista;

        private RepositorioAmigo repositorioAmigo;
        private TelaAmigo telaAmigo;

        public TelaReserva(RepositorioReserva repositorioReserva, TelaAmigo telaAmigo, TelaRevista telaRevista, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
        {
            this.repositorioBase = repositorioReserva;
            this.telaAmigo = telaAmigo;
            this.telaRevista = telaRevista;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine();

            Console.WriteLine("{0, -10} | {1, -40} | {2, -20} | {3, -20} | {4, -10}", "Id", "Revista", "Amigo", "Data da Reserva", "Status");

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

            foreach (Reserva reserva in registros)
            {
                string status = reserva.estaAberta ? "Aberta" : "Fechada";

                Console.WriteLine("{0, -10} | {1, -40} | {2, -20} | {3, -20} | {4, -10}",
                    reserva.id, reserva.revista.titulo, reserva.amigo.nome, reserva.dataReserva, status);
            }
        }

        protected override Entidade ObterRegistro()
        {
            //Visualizar as revistas
            telaRevista.VisualizarRegistros(false);

            //escolher uma revista
            Console.Write("Digite o id da revista: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revista revista = repositorioRevista.SelecionarPorId(idRevista);

            //Visulizar os amigos

            telaAmigo.VisualizarRegistros(false);

            //escolher um amigo
            Console.Write("Digite o id do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigo amigo = repositorioAmigo.SelecionarPorId(idAmigo);

            //escolher uma data
            Console.Write("Digite a data: ");
            DateTime dataEmprestimo = Convert.ToDateTime(Console.ReadLine());

            Reserva reserva = new Reserva(revista, amigo, dataEmprestimo);

            return reserva;
        }
    }
}
