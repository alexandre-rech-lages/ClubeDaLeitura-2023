namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class Tela
    {
        public void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();

            Console.WriteLine(titulo + "\n");

            Console.WriteLine(subtitulo + "\n");
        }

        public void MostrarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
