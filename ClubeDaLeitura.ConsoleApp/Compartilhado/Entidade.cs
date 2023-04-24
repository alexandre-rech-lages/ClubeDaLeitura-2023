namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class EntidadeBase
    {
        public int id;

        public virtual void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {            
            //este método serve para chamar a atualização das classes filhas
        }
    }
}
