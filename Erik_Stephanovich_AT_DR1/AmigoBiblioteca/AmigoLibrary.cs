using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoBiblioteca
{
    public class AmigoLibrary : IAmigo
    {
        private static List<Amigo> Amigos = new List<Amigo>();
        private static readonly string Caminho = @"C:\\Data";
        private static readonly string Completo = "Lista.txt";

        public AmigoLibrary()
        {
            if (!Directory.Exists(Caminho))
                Directory.CreateDirectory(Caminho);
        }

        private static int GerarID()
        {
            int id;
            if (!Amigos.Any())
                id = 0;
            else
                id = Amigos[Amigos.Count - 1].Id + 1;
            return id;
        }

        public void CadastrarPessoa(string nome, string sobrenome, DateTime dataNascimento)
        {
            int id = GerarID();
            Amigo p = new Amigo
            {
                Id = id,
                Nome = nome,
                Sobrenome = sobrenome,
                DataNascimento = dataNascimento
            };
            Amigos.Add(p);
        }

        public void ExcluirPessoa(int id)
        {
            foreach (var item in Amigos)
            {
                if (item.Id == id)
                {
                    Amigos.Remove(item);
                    break;
                }
            }
        }

        public List<Amigo> BuscarPessoas(string nome)
        {
            List<Amigo> ps = new List<Amigo>();
            foreach (var p in Amigos)
            {
                string nomeCompleto = p.Nome + " " + p.Sobrenome;
                if (nomeCompleto.Contains(nome))
                {
                    ps.Add(p);
                }
            }
            return ps;
        }
        public List<Amigo> ListarAniversariantes()
        {
            List<Amigo> ps = new List<Amigo>();
            DateTime dataAtual = DateTime.Today;
            foreach (var a in Amigos)
            {
                if(a.DataNascimento.Day == dataAtual.Day & a.DataNascimento.Month == dataAtual.Month)
                {
                    ps.Add(a);
                }
            }
            return ps;
        }

        public void EditarPessoa(int id, string nome, string sobrenome, DateTime dataNascimento)
        {
            foreach (var _ in Amigos)
            {
                if(_.Id == id)
                {
                    _.Nome = nome;
                    _.Sobrenome = sobrenome;
                    _.DataNascimento = dataNascimento;
                    break;
                }
            }
        }

        public void GravarArquivo()
        {
            Repository rep = new Repository(Path.Combine(Caminho, Completo));
            rep.SalvarArquivo(Amigos);
        }

        public void LerArquivo()
        {
            List<Amigo> amigosTemp = new List<Amigo>();
            Repository rep = new Repository(Path.Combine(Caminho, Completo));
            amigosTemp = rep.LerArquivo();
            Amigos = amigosTemp;
        }
    }
}