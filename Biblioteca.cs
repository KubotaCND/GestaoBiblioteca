using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    public class Biblioteca
    {
        public List<Pessoa> Pessoas { get; set; }
        public List<Livro> Livros { get; set; }

        public Biblioteca(List<Pessoa> pessoas, List<Livro> livros)
        {
           Pessoas = pessoas;
            Livros = livros;
        }

        public void CadastrarPessoa(Pessoa pessoa)
        {   Pessoas.Add(pessoa);
            return;
        }

        public void CadastrarLivro(Livro livro)
        {   Livros.Add(livro);
            return;
        }

        public void EmprestarLivroBiblioteca(int idl,int idp)
        {
            foreach (var l in Pessoas)
            {
                if (l.IDP==idp)
                {
                    foreach (var d in Livros)
                    {
                        if (d.ID==idl)
                        {   d.EmprestarLivro(1);
                            l.AdicionarLivroLista(d);

                        }

                    }

                }

            }
            

            

        }

        public void DevolverLivroBiblioteca(int idl, int idp)
        {
            foreach (var l in Pessoas)
            {
                if (l.IDP == idp)
                {
                    foreach (var d in Livros)
                    {
                        if (d.ID == idl)
                        {
                            d.DevolverLivro(1);
                            l.RemoverLivroLista(idl);

                        }

                    }

                }

            }

        }
    }
}
