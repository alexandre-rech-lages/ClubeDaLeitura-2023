using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    public class Reserva : Entidade
    {
        public Amigo amigo;
        public Revista revista;
        public DateTime dataReserva;
        public bool estaAberta;

        public Reserva(Revista revista, Amigo amigo, DateTime dataReserva)
        {
            this.revista = revista;
            this.amigo = amigo;
            this.dataReserva = dataReserva;

            estaAberta = true;
        }
    }
}
