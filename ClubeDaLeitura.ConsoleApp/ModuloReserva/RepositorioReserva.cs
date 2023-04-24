using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    public class RepositorioReserva : RepositorioBase
    {
        public RepositorioReserva(ArrayList lista) : base(lista)
        {
        }

        public override Entidade SelecionarPorId(int id)
        {
            return (Reserva)base.SelecionarPorId(id);
        }        
    }
}
