using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo(new ArrayList());
            RepositorioCaixa repoCaixa = new RepositorioCaixa(new ArrayList());
            RepositorioRevista repositorioRevista = new RepositorioRevista(new ArrayList());
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo(new ArrayList());

            PopularRepositorios(repositorioAmigo, repoCaixa, repositorioRevista, repositorioEmprestimo);

            TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
            TelaCaixa telaCaixa = new TelaCaixa(repoCaixa, repositorioRevista);
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, repoCaixa, telaCaixa);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo
                (repositorioEmprestimo, telaRevista, repositorioRevista, telaAmigo, repositorioAmigo);

            TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (true)
            {                
                string opcao = telaPrincipal.ApresentarMenu();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string opcaoCaixa = telaCaixa.ApresentarMenu();

                    if (opcaoCaixa == "1")
                    {
                        telaCaixa.InserirNovaCaixa();
                    }
                    else if (opcaoCaixa == "2")
                    {
                        telaCaixa.VisualizarCaixas(true);
                        Console.ReadLine();
                    }
                    else if (opcaoCaixa == "3")
                    {
                        telaCaixa.EditarCaixas();
                    }
                    else if (opcaoCaixa == "4")
                    {
                        telaCaixa.ExcluirCaixas();
                    }

                    continue;
                }
                else if (opcao == "2")
                {
                    string opcaoAmigo = telaAmigo.ApresentarMenu();

                    if (opcaoAmigo == "1")
                    {
                        telaAmigo.InserirNovoAmigo();
                    }
                    else if (opcaoAmigo == "2")
                    {
                        telaAmigo.VisualizarAmigos(true);
                        Console.ReadLine();
                    }
                    else if (opcaoAmigo == "3")
                    {
                        telaAmigo.EditarAmigos();
                    }
                    else if (opcaoAmigo == "4")
                    {
                        telaAmigo.ExcluirAmigos();
                    }

                    continue;
                }
                else if (opcao == "3")
                {

                    string opcaoRevista = telaRevista.ApresentarMenu();

                    if (opcaoRevista == "1")
                    {
                        telaRevista.InserirNovaRevista();
                    }
                    else if (opcaoRevista == "2")
                    {
                        telaRevista.VisualizarRevistas(true);
                        Console.ReadLine();
                    }
                    else if (opcaoRevista == "3")
                    {
                        telaRevista.EditarRevistas();
                    }
                    else if (opcaoRevista == "4")
                    {
                        telaRevista.ExcluirRevistas();
                    }

                    continue;
                }
                else if (opcao == "4")
                {

                    string opcaoEmprestimo = telaEmprestimo.ApresentarMenu();

                    if (opcaoEmprestimo == "1")
                    {
                        telaEmprestimo.AbrirNovoEmprestimo();
                    }
                    else if (opcaoEmprestimo == "2")
                    {
                        telaEmprestimo.VisualizarEmprestimos(true);
                        Console.ReadLine();
                    }
                    else if (opcaoEmprestimo == "3")
                    {
                        telaEmprestimo.VisualizarEmprestimosNoMes();
                        Console.ReadLine();
                    }
                    else if (opcaoEmprestimo == "4")
                    {
                        telaEmprestimo.VisualizarEmprestimosEmAbertoNoDia();
                        Console.ReadLine();
                    }
                    else if (opcaoEmprestimo == "5") 
                    {
                        telaEmprestimo.FecharEmprestimo();
                    }
                    else if (opcaoEmprestimo == "6")
                    {
                        telaEmprestimo.EditarEmprestimos();
                    }
                    else if (opcaoEmprestimo == "7")
                    {
                        telaEmprestimo.ExcluirEmprestimos();
                    }
                    

                    continue;
                }
            }
        }

        private static void PopularRepositorios(
            RepositorioAmigo repositorioAmigo, RepositorioCaixa repositorioCaixa,
            RepositorioRevista repositorioRevista, RepositorioEmprestimo repositorioEmprestimo)
        {
            Amigo amigo1 = new Amigo("Gabriel Barbosa", "Jorge Sampaoli", "99999999", "Gávea");

            Amigo amigo2 = new Amigo("Bruno Henrique", "Jorge Sampaoli", "99999999", "Gávea");

            Amigo amigo3 = new Amigo("Pedro Quexada", "Jorge Sampaoli", "99999999", "Gávea");

            repositorioAmigo.Inserir(amigo1);
            repositorioAmigo.Inserir(amigo2);
            repositorioAmigo.Inserir(amigo3);

            Caixa caixa = new Caixa("Verde", "abc-123");

            repositorioCaixa.Inserir(caixa);

            Revista revista1 = new Revista("Batman Begins", 10, 2010, caixa);

            repositorioRevista.Inserir(revista1);

            Revista revista2 = new Revista("As aventuras de superman", 10, 2010, caixa);

            repositorioRevista.Inserir(revista2);

            Revista revista3 = new Revista("Turma da Monica", 10, 2010, caixa);

            repositorioRevista.Inserir(revista3);

            DateTime hoje = new DateTime(2023, 4, 19);

            Emprestimo emprestimo1 = new Emprestimo(hoje, revista1, amigo1);

            repositorioEmprestimo.Inserir(emprestimo1);

            DateTime ontem = new DateTime(2023, 3, 18);
            Emprestimo emprestimo2 = new Emprestimo(ontem, revista2, amigo2);

            repositorioEmprestimo.Inserir(emprestimo2);

            DateTime anteOntem = new DateTime(2022, 1, 17);
            Emprestimo emprestimo3 = new Emprestimo(anteOntem, revista3, amigo3);

            repositorioEmprestimo.Inserir(emprestimo3);
        }
    }
}