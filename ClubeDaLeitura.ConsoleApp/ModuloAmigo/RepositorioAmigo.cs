using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo : RepositorioBase
    {        
        public RepositorioAmigo(ArrayList lista) : base(lista) 
        {
        }        

        public override Amigo SelecionarPorId(int id)
        {
            Amigo amigoSelecionado = (Amigo)base.SelecionarPorId(id);

            return amigoSelecionado;
        }       
    }
}
