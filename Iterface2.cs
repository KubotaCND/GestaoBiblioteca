using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    //internal class Iterface2
    {
        //static void Main(string[] args)
        {
         //   int read;
            //if(Console.ReadKey()==\esc)
            {
                // Pessoa a1 = new(0, "inicio", "888888888", "188888888888");
                // Livro l1 = new(0, "aaa", "a", "a", 0);
                // List<Pessoa> pessoas = new List<Pessoa>();
                // pessoas.Add(a1);
                // List<Livro> livros = new List<Livro>();
                // livros.Add(l1);
                // Biblioteca biblioteca=new Biblioteca(pessoas,livros);
                Biblioteca biblioteca = new Biblioteca();

                Console.WriteLine("Escolha o número da opção desejada:\n 1 - Cadastrar Pessoa\r\n 2 - Cadastrar Livro\r\n 3 - Emprestar Livro\r\n 4 - Devolver Livro\r\n 5 - Listar todos os livros\r\n 6 - Listar todas as pessoas cadastradas\r\n 7 - Listar todos os livros emprestados");
                read = int.Parse(Console.ReadLine());

                if (read == 1)
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




                }
                else if (read == 2)
                {

                }
                else if (read == 3)
                {

                }
                else if (read == 4)
                {

                }
                else if (read == 5)
                {

                }
                else if (read == 6)
                {

                }
                else if (read == 7)
                {

                }


            }
        }
    }
}