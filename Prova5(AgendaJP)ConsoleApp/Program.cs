using ClubeLeitura.ConsoleApp.Compartilhado;
using Prova5_AgendaJP_ConsoleApp.Compartilhado;
using Prova5_AgendaJP_ConsoleApp.ModuloContato;
using System;

namespace Prova5_AgendaJP_ConsoleApp
{
    internal class Program
    {
        static TelaMenuPrincipal telaMenuPrincipal = new TelaMenuPrincipal(new Notificador());
        
        static void Main(string[] args)
        {
            
            while (true)
            {
                TelaBase telaSelecionada = telaMenuPrincipal.ObterTela();

                if (telaSelecionada is null)
                    return;
               
                string opcaoSelecionada = telaSelecionada.MostrarOpcoes();

                if (telaSelecionada is ICadastroBasico)
                {
                    ICadastroBasico telaCadastroBasico = (ICadastroBasico)telaSelecionada;

                    if (opcaoSelecionada == "1")
                        telaCadastroBasico.Inserir();

                    if (opcaoSelecionada == "2")
                        telaCadastroBasico.Editar();

                    if (opcaoSelecionada == "3")
                        telaCadastroBasico.Excluir();

                    if (opcaoSelecionada == "4")
                        telaCadastroBasico.VisualizarRegistros("Tela");
                }
                
                else if(telaSelecionada is TelaCadastroContato)
                {
                        TelaCadastroContato telaCadastroContato = telaSelecionada as TelaCadastroContato;

                        if (opcaoSelecionada == "1")
                            telaCadastroContato.Inserir();

                        if (opcaoSelecionada == "2")
                            telaCadastroContato.Editar();

                        if (opcaoSelecionada == "3")
                           telaCadastroContato.Excluir();

                        if (opcaoSelecionada == "4")
                            telaCadastroContato.VisualizarRegistros("Tela");

                        if (opcaoSelecionada == "5")
                           telaCadastroContato.VisualizarPorCargo("Tela");
                    
                }
            }
        }
    }
}
