using ClubeLeitura.ConsoleApp.Compartilhado;
using Prova5_AgendaJP_ConsoleApp.ModuloCompromisso;
using Prova5_AgendaJP_ConsoleApp.ModuloContato;
using Prova5_AgendaJP_ConsoleApp.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova5_AgendaJP_ConsoleApp.Compartilhado
{
    public class TelaMenuPrincipal
    {
        private IRepositorio<Tarefa> repositorioTarefa;
        private TelaCadastroTarefa telaCadastroTarefa;

        private IRepositorio<Contato> repositorioContato;
        private TelaCadastroContato telaCadastroContato;

        private IRepositorio<Compromisso> repositorioCompromisso;
        private TelaCadastroCompromisso telaCadastroCompromisso;

        public TelaMenuPrincipal()
        {
        }

        public TelaMenuPrincipal(Notificador notificador)
        {
            repositorioTarefa = new RepositorioTarefa();
            telaCadastroTarefa = new TelaCadastroTarefa(repositorioTarefa, notificador);

            repositorioContato = new RepositorioContato();
            telaCadastroContato = new TelaCadastroContato(repositorioContato, notificador);

            repositorioCompromisso = new RepositorioCompromisso();
            telaCadastroCompromisso = new TelaCadastroCompromisso(repositorioCompromisso, notificador);
        }
        public string MostrarOpcoes()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("AGENDA JP");  // substituir pelo mostrar titulo
            Console.WriteLine();

            Console.WriteLine("Digite 1 para tela de TAREFAS");
            Console.WriteLine("Digite 2 para tela de CONTATOS");
            Console.WriteLine("Digite 3 para tela de COMPROMISSOS");
            Console.WriteLine("Digite 0 para Sair da Aplicação");
            string opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public TelaBase ObterTela()
        {
            string opcao = MostrarOpcoes();

            TelaBase tela = null;

            if (opcao == "1")
                tela = telaCadastroTarefa;
            
            else if (opcao == "2")
                tela = telaCadastroContato;
            
            else if (opcao == "3")
                tela = telaCadastroCompromisso;
            
            else if (opcao == "4")
                tela = null;
            
            return tela;
        }
    }
}
