namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int id;

        public abstract void AtualizarInformacoes(EntidadeBase registroAtualizado);        
    }
}
