using Prova5_AgendaJP_ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova5_AgendaJP_ConsoleApp.ModuloContato
{
    public class Contato : EntidadeBase, IComparable<Contato>
    {
        private readonly string _nome;
        private readonly string _telefone;
        private readonly string _email;
        private readonly string _empresa;
        private readonly string _cargoContato;

        public string Nome { get => _nome;}
        public string Telefone { get => _telefone;}
        public string Email { get => _email;}
        public string Empresa { get => _empresa;}
        public string CargoContato { get => _cargoContato;}
      
        public Contato(string nome, string telefone, string email, string empresa, string cargoContato)
        {
            _nome = nome;
            _telefone = telefone;
            _email = email;
            _empresa = empresa;
            _cargoContato = cargoContato;
        }

        public override string ToString()
        {
            return "Id: " + ID + Environment.NewLine +
                "Nome: " + Nome + Environment.NewLine +
                "Telefone: " + Telefone + Environment.NewLine +
                "Email: " + Email + Environment.NewLine +
                "Empresa: " + Empresa + Environment.NewLine +
                "Cargo Contato: " + CargoContato + Environment.NewLine;
        }

       public int CompareTo(Contato other)
        {
            if(CargoContato == other.CargoContato)
                return 1;
            if (CargoContato != other.CargoContato)
                return -1;

            return 0;
        }
    }
}
