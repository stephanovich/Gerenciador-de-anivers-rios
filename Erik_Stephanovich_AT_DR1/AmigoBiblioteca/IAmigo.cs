using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoBiblioteca
{
    interface IAmigo
    {
        void CadastrarPessoa(string nome, string sobrenome, DateTime dataNascimento);
        List<Amigo> BuscarPessoas(string nome);
        void ExcluirPessoa(int id);
        void EditarPessoa(int id, string nome, string sobrenome, DateTime dataNascimento);
    }
}
