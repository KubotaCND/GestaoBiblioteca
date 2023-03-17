using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    public class Pessoa
    {
        public int IDP { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public  List<Livro> LivrosEmprestados { get; set; }

        public Pessoa(int iDP, string nome, string cpf, string telefone)
        {
            IDP = iDP;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            
        }

        // pq não: public Livro AdicionarLivroLista(Livro livro)
        public void AdicionarLivroLista(Livro livro)
        {LivrosEmprestados.Add(livro);}

        public void RemoverLivroLista(int idl)
        {foreach (Livro item in LivrosEmprestados)
            {if (item.ID==idl)
                {LivrosEmprestados.Remove(item);
                Console.WriteLine($"ID do livro removido:{item.ID}");
                return;  
                }
            }
            Console.WriteLine("Livro não encontrado");
        }


    }
}


//Perguntar pro Rodrigo de void e return()
