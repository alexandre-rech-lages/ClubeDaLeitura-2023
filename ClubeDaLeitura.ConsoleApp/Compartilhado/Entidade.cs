namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class Entidade
    {
        public int id;

        public virtual void Atualizar(Entidade registroAtualizado)
        {
            id = registroAtualizado.id;
        }
    }
}
