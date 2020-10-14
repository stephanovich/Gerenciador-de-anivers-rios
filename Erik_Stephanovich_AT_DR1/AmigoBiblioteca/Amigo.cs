using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoBiblioteca
{
    public class Amigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }

        private int CalcularAniversario()
        {
            DateTime hoje = DateTime.Today;
            DateTime proxNiver = DataNascimento.AddYears(hoje.Year - DataNascimento.Year);

            if (proxNiver < hoje)
                proxNiver = proxNiver.AddYears(1);

            int dias = (proxNiver - hoje).Days;

            return dias;
        }
        public override string ToString()
        {
            string format = "Nome completo: " + Nome + " " + Sobrenome + "\nData de Nascimento: " + DataNascimento.ToString("d");
            format += $"\nFaltam {CalcularAniversario()} dias para seu proximo aniversario.";
            return format;
        }
        public string AniverssarianteDoDia()
        {
            return $"{Nome} {Sobrenome} faz aniverssário hoje.\nDe parabéns a ele";
        }
    }
}
