using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    public class TelaReserva : TelaBase
    {
        private RepositorioReserva repositorioReserva;

        private TelaRevista telaRevista;
        private RepositorioRevista repositorioRevista;

        private RepositorioAmigo repositorioAmigo;
        private TelaAmigo telaAmigo;

        public TelaReserva(
            RepositorioReserva repositorioReserva,
            TelaRevista telaRevista, 
            RepositorioRevista repositorioRevista, 
            RepositorioAmigo repositorioAmigo, 
            TelaAmigo telaAmigo)
        {
            this.repositorioBase = repositorioReserva;

            this.telaRevista = telaRevista;
            this.repositorioRevista = repositorioRevista;
            this.repositorioAmigo = repositorioAmigo;
            this.telaAmigo = telaAmigo;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine();

            Console.WriteLine("{0, -10} | {1, -40} | {2, -20} | {3, -20}", "Id", "Revista", "Amigo", "Data do Reserva");

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");

            foreach (Reserva reserva in registros)
            {
                Console.WriteLine("{0, -10} | {1, -40} | {2, -20} | {3, -20}",
                    reserva.id, reserva.revista.titulo, reserva.amigo.nome, reserva.dataReserva);
            }
        }

        protected override EntidadeBase ObterRegistro()
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
            DateTime dataReserva = Convert.ToDateTime(Console.ReadLine());

            return new Reserva(revista, amigo, dataReserva);
        }
    }
}
