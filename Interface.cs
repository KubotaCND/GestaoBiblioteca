using System.Runtime.Intrinsics.Arm;

namespace GestaoBiblioteca
{
    internal class Interface
    {
        static void Main(string[] args)
        {
            string read;

            {
                Pessoa a1 = new(0, "inicio", "888888888", "188888888888");
                List<Pessoa> pessoas = new List<Pessoa>();
                pessoas.Add(a1);
                Livro l1 = new(0, "aaa", "a", "a", 0);
                List<Livro> livros = new List<Livro>();
                livros.Add(l1);
                Biblioteca biblioteca = new Biblioteca(pessoas,livros);
                
                

                do
                {
                    Console.WriteLine("Escolha o número da opção desejada:\n 1 - Cadastrar Pessoa\r\n 2 - Cadastrar Livro\r\n 3 - Emprestar Livro\r\n 4 - Devolver Livro\r\n 5 - Listar todos os livros\r\n 6 - Listar todas as pessoas cadastradas\r\n 7 - Listar todos os livros emprestados");
                    read = Console.ReadLine();



                    while (read != "Sim"&& read!="")
                    {
                        switch (read) { 
                        case "1":
                        {
                            string nome, cpf, telefone;
                            int iDP;
                            Console.WriteLine("Digite o ID da pessoa:");
                            iDP = int.Parse(Console.ReadLine());
                            foreach (var p in biblioteca.Pessoas)
                            {
                                for (int a = 0; a < biblioteca.Pessoas.Count; a++)
                                {
                                    if (a == iDP)
                                    {
                                        Console.WriteLine("Pessoa já cadastrada.");
                                        Console.WriteLine("Voltar ao menu inicial?");
                                        read = Console.ReadLine();
                                    }
                                }
                            }
                            Console.WriteLine("Digite o Nome da pessoa:");
                            nome = Console.ReadLine();
                            Console.WriteLine("Digite o CPF da pessoa:");
                            cpf = Console.ReadLine();
                            Console.WriteLine("Digite o telefone da pessoa:");
                            telefone = Console.ReadLine();

                            Pessoa pessoa = new Pessoa(iDP, nome, cpf, telefone);


                            biblioteca.CadastrarPessoa(pessoa);
                            Console.WriteLine($"{pessoa.Nome} cadastrada.");
                            Console.WriteLine("Voltar ao menu inicial?");
                            read = Console.ReadLine();
                        }
                        break;




                            case "2":
                        {
                            string titulo, editora, autor;
                            int idl, qtdex;
                            Console.WriteLine("Digite o ID do livro:");
                            idl = int.Parse(Console.ReadLine());
                            foreach (var p in biblioteca.Livros)
                            {
                                for (int a = 0; a < biblioteca.Livros.Count; a++)
                                {
                                    if (biblioteca.Livros[a].ID == idl)
                                    {
                                        Console.WriteLine("Livro já cadastrado.");
                                        Console.WriteLine("Voltar ao menu inicial?");
                                        read = Console.ReadLine();
                                    }
                                }
                            }
                            Console.WriteLine("Digite o Titulo do livro:");
                            titulo = Console.ReadLine();
                            Console.WriteLine("Digite o Autor do livro:");
                            autor = Console.ReadLine();
                            Console.WriteLine("Digite a Editora do livro:");
                            editora = Console.ReadLine();
                            Console.WriteLine("Digite a quantidade de exemplares do livro:");
                            qtdex = int.Parse(Console.ReadLine());

                            Livro livro = new Livro(idl, titulo, autor, editora, qtdex);


                            biblioteca.CadastrarLivro(livro);
                            Console.WriteLine($"{livro.Titulo} cadastrado.");
                            Console.WriteLine("Voltar ao menu inicial?");
                            read = Console.ReadLine();


                        }
                                break;


                            case "3":
                                {
                                    int idp, idl;
                                    Console.WriteLine("Digite o ID da pessoa:");
                                    idp = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Digite o ID do livro:");
                                    idl = int.Parse(Console.ReadLine());

                                    // Check if the person exists
                                    Pessoa pessoa = biblioteca.Pessoas.FirstOrDefault(p => p.IDP == idp);
                                    if (pessoa == null)
                                    {
                                        Console.WriteLine("Usuário não cadastrado");
                                        Console.WriteLine("Voltar ao menu inicial?");
                                        read = Console.ReadLine();
                                        break;
                                    }

                                    // Check if the book exists
                                    Livro livro = biblioteca.Livros.FirstOrDefault(l => l.ID == idl);
                                    if (livro == null)
                                    {
                                        Console.WriteLine("Livro não cadastrado");
                                        Console.WriteLine("Voltar ao menu inicial?");
                                        read = Console.ReadLine();
                                        break;
                                    }

                                   

                             
                                    pessoa.AdicionarLivroLista(livro);
                                    biblioteca.EmprestarLivroBiblioteca(idl, idp);
                                    livro.EmprestarLivro(1);
                                    Console.WriteLine($"O Livro {livro.Titulo} foi emprestado para a pessoa {pessoa.Nome}");
                                    Console.WriteLine("Voltar ao menu inicial?");
                                    read = Console.ReadLine();
                                }
                                break;



                            case "4":
                                {
                                    int idp, idl;
                                    Console.WriteLine("Digite o ID da pessoa:");
                                    idp = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Digite o ID do livro:");
                                    idl = int.Parse(Console.ReadLine());

                                    // Check if the person exists
                                    Pessoa pessoa = biblioteca.Pessoas.FirstOrDefault(p => p.IDP == idp);
                                    if (pessoa == null)
                                    {
                                        Console.WriteLine("Usuário não cadastrado");
                                        Console.WriteLine("Voltar ao menu inicial?");
                                        read = Console.ReadLine();
                                        break;
                                    }

                                    // Check if the book exists
                                    Livro livro = biblioteca.Livros.FirstOrDefault(l => l.ID == idl);
                                    if (livro == null)
                                    {
                                        Console.WriteLine("Livro não cadastrado");
                                        Console.WriteLine("Voltar ao menu inicial?");
                                        read = Console.ReadLine();
                                        break;
                                    }

                                    if (!pessoa.LivrosEmprestados.Contains(livro))
                                    {
                                        Console.WriteLine($"O livro {livro.Titulo} não está emprestado para a pessoa {pessoa.Nome}");
                                        Console.WriteLine("Voltar ao menu inicial?");
                                        read = Console.ReadLine();
                                        break;
                                    }

                                    pessoa.RemoverLivroLista(idl);
                                    biblioteca.DevolverLivroBiblioteca(idl, idp);
                                    livro.DevolverLivro(1);
                                    Console.WriteLine($"O Livro {livro.Titulo} foi devolvido pela pessoa {pessoa.Nome}");
                                    Console.WriteLine("Voltar ao menu inicial?");
                                    read = Console.ReadLine();
                                }
                                break;
                            case "5":
                        {
                            foreach (var item in biblioteca.Livros)
                            {
                                Console.WriteLine($"{item.Titulo}");
                               
                            }
                            Console.WriteLine("Voltar ao menu inicial?");
                            read = Console.ReadLine();

                        }
                                break;
                            case "6":
                        {
                            foreach (var item in biblioteca.Pessoas)
                            {
                                Console.WriteLine($"{item.Nome}");
                                
                            }
                            Console.WriteLine("Voltar ao menu inicial?");
                            read = Console.ReadLine();
                        }
                                break;
                            case "7":
                        {
                            foreach (var item in biblioteca.Pessoas)
                            {
                                foreach (var a in item.LivrosEmprestados)
                                {
                                    Console.WriteLine($"{a.Titulo}");
                                    Console.WriteLine("Voltar ao menu inicial?");
                                    read = Console.ReadLine();
                                }
                            }
                        }
                                break;

                            case "":
                                { read=Console.ReadLine(); }
                                break;
                                


                    }
                } 
            } while (read != "");
              
              
            }
    }
}
}
//se não tiver livro emprestado
//se não tiver livro cadastrado
//se não tiver pessoa cadastrada
//metódos não sendo chamados
//questão do void
//começar do vazio