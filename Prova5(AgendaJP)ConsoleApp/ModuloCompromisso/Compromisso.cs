using Prova5_AgendaJP_ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova5_AgendaJP_ConsoleApp.ModuloCompromisso
{
    public class Compromisso : EntidadeBase
    {
        private readonly DateTime _horaInicio;
        private readonly DateTime _horaTermino;
        private readonly DateTime _dataCompromisso;
        private readonly string _assunto;
        private readonly string _local;

        public DateTime DataInicio { get => _horaInicio; }
        public DateTime DataTermino { get => _horaTermino; }
        public DateTime DataCompromisso { get => _dataCompromisso; }
        public string Assunto { get => _assunto; }
        public string Local { get => _local; }

        public Compromisso(string local, string assunto,DateTime horaInicio,DateTime horaTermino, DateTime dataCompromisso)
        {
            _horaInicio = horaInicio;
            _horaTermino = horaTermino;
            _dataCompromisso = dataCompromisso;
            _assunto = assunto;
            _local = local;
        }

        public override string ToString()
        {
            return "Id: " + ID + Environment.NewLine +
                "Data do Compromisso: " + DataCompromisso.ToString("dd/MM/yy") + Environment.NewLine +
                "Hora do inicio: " + DataInicio.ToString("HH:mm")  + Environment.NewLine +
                "Hora do Final: " + DataTermino.ToString("HH:mm") + Environment.NewLine +
                "Assunto: " + Assunto + Environment.NewLine +
                "Local: " + Local + Environment.NewLine;
        }
    }
}
            