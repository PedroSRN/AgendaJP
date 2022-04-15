using ClubeLeitura.ConsoleApp.Compartilhado;
using Prova5_AgendaJP_ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova5_AgendaJP_ConsoleApp.ModuloTarefa
{
    public class Tarefa : EntidadeBase, IComparable<Tarefa>
    {
        private readonly int _categoria;// alta=3, media=2, baixa=1   
        private readonly string _titulo;
        private readonly DateTime _dataCriacao;
        private readonly DateTime _dataConclusao;
        private readonly int _percentualConcluido;

        public int Categoria { get => _categoria;  }
        public string Titulo { get => _titulo; }
        public DateTime DataCRIACAO { get => _dataCriacao; }
        public DateTime DataCONCLUSAO { get => _dataConclusao; }
        public int PercentualConcluido { get => _percentualConcluido; }

        public Tarefa(int categoria, string titulo, DateTime dataCriacao, DateTime dataConclusao, int percentualConcluido)
        {
            _categoria = categoria;
            _titulo = titulo;
            _dataCriacao = dataCriacao;
            _dataConclusao = dataConclusao;
            _percentualConcluido = percentualConcluido;
        }
        
        public override string ToString()
        {
            return "Id: " + ID + Environment.NewLine +
                "Categoria: " + Categoria + Environment.NewLine + 
                "Titulo: " + Titulo + Environment.NewLine +
                "Data Criação: " + DataCRIACAO.ToString("dd/MM/yy") + Environment.NewLine +
                "Data Conclusão: " + DataCONCLUSAO.ToString("dd/MM/yy") + Environment.NewLine +
                "Percentual: " + PercentualConcluido + Environment.NewLine;
        }

        public int CompareTo(Tarefa other)
        {
           if(_categoria > other._categoria)
            {
                return -1;
            }
            if (_categoria < other._categoria)
            {
                return 1;
            }
            return 0;
        }
    }
}
