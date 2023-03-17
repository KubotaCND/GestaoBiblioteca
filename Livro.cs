using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    public class Livro
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int QtdeExemplares { get; set; }
        public Livro(int id, string titulo, string autor, string editora, int qtdeExemplares)
        {
            ID = id;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            QtdeExemplares = qtdeExemplares;
        }

        public int EmprestarLivro(int quantidadeEmprestada)
        {   return QtdeExemplares - quantidadeEmprestada;}

        public int DevolverLivro(int quantidadeDevolvida)
        {   return QtdeExemplares + quantidadeDevolvida;}




    }
}
