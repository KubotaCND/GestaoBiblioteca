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
                Livro l1 = new(0, "aaa", "a", "a", 0);
                List<Pessoa> pessoas = new List<Pessoa>();
                pessoas.Add(a1);
                List<Livro> livros = new List<Livro>();
                livros.Add(l1);
                Biblioteca biblioteca = new Biblioteca(pessoas, livros);

                do
                {
                    Console.WriteLine("Escolha o número da opção desejada:\n 1 - Cadastrar Pessoa\r\n 2 - Cadastrar Livro\r\n 3 - Emprestar Livro\r\n 4 - Devolver Livro\r\n 5 - Listar todos os livros\r\n 6 - Listar todas as pessoas cadastradas\r\n 7 - Listar todos os livros emprestados");
                    read = Console.ReadLine();



                    while (read != "Sim")
                    {

                        if (read == "1")
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




                        else if (read == "2")
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
                        else if (read == "3")
                        {
                            int idp, idl;
                            Console.WriteLine("Digite o ID da pessoa:");
                            idp = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o ID do livro:");
                            idl = int.Parse(Console.ReadLine());
                            foreach (var item in biblioteca.Pessoas)
                            {
                                for (int a = 0; a < biblioteca.Pessoas.Count; a++)
                                {
                                    if (biblioteca.Pessoas[a].IDP != idp)
                                    {
                                        Console.WriteLine("Usuário não cadastrado");
                                        Console.WriteLine("Voltar ao menu inicial?");
                                        read = Console.ReadLine();
                                    }

                                }

                            }
                            foreach (var item in biblioteca.Livros)
                            {
                                for (int b = 0; b < biblioteca.Livros.Count; b++)
                                {
                                    if (biblioteca.Livros[b].ID != idl)
                                    {
                                        Console.WriteLine("Livro não cadastrado");
                                        Console.WriteLine("Voltar ao menu inicial?");
                                        read = Console.ReadLine();
                                    }

                                }

                            }

                            foreach (var c in biblioteca.Pessoas)
                            {
                                if (c.IDP == idp)
                                {
                                    foreach (var d in biblioteca.Livros)
                                    {
                                        if (d.ID == idl)
                                        {
                                            c.AdicionarLivroLista(d);
                                            biblioteca.EmprestarLivroBiblioteca(idl, idp);
                                            d.EmprestarLivro(1);
                                            Console.WriteLine($"O Livro {d} foi emprestado para a pessoa\r\n{c}");
                                            Console.WriteLine("Voltar ao menu inicial?");
                                            read = Console.ReadLine();

                                        }
                                    }
                                }
                            }






                        }



                        else if (read == "4")
                        {
                            int idp, idl;
                            Console.WriteLine("Digite o ID da pessoa:");
                            idp = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o ID do livro:");
                            idl = int.Parse(Console.ReadLine());
                            foreach (var item in biblioteca.Pessoas)
                            {
                                for (int a = 0; a < biblioteca.Pessoas.Count; a++)
                                {
                                    if (biblioteca.Pessoas[a].IDP != idp)
                                    {
                                        Console.WriteLine("Usuário não cadastrado");
                                        Console.WriteLine("Voltar ao menu inicial?");
                                        read = Console.ReadLine();
                                    }

                                }

                            }
                            foreach (var item in biblioteca.Livros)
                            {
                                for (int b = 0; b < biblioteca.Livros.Count; b++)
                                {
                                    if (biblioteca.Livros[b].ID != idl)
                                    {
                                        Console.WriteLine("Livro não cadastrado");
                                        Console.WriteLine("Voltar ao menu inicial?");
                                        read = Console.ReadLine();
                                    }

                                }

                            }

                            foreach (var c in biblioteca.Pessoas)
                            {
                                if (c.IDP == idp)
                                {
                                    foreach (var d in biblioteca.Livros)
                                    {
                                        if (d.ID == idl)
                                        {
                                            c.RemoverLivroLista(idl);
                                            biblioteca.DevolverLivroBiblioteca(idl, idp);
                                            d.DevolverLivro(1);
                                            Console.WriteLine($"O Livro {d} foi devolvido com sucesso.");
                                            Console.WriteLine("Voltar ao menu inicial?");
                                            read = Console.ReadLine();
                                        }
                                    }
                                }
                            }

                        }
                        else if (read == "5")
                        {
                            foreach (var item in biblioteca.Livros)
                            {
                                Console.WriteLine($"{item.Titulo}");
                                
                            }
                            Console.WriteLine("Voltar ao menu inicial?");
                            read = Console.ReadLine();

                        }
                        else if (read == "6")
                        {
                            foreach (var item in biblioteca.Pessoas)
                            {
                                Console.WriteLine($"{item.Nome}");
                                
                            }
                            Console.WriteLine("Voltar ao menu inicial?");
                            read = Console.ReadLine();
                        }
                        else if (read == "7")
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


                    }
                } while (read != "");
            }
        }
    }
}
