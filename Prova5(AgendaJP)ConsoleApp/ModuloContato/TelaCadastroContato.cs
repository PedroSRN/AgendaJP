using ClubeLeitura.ConsoleApp.Compartilhado;
using Prova5_AgendaJP_ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova5_AgendaJP_ConsoleApp.ModuloContato
{
    public class TelaCadastroContato : TelaBase
    {
        private readonly IRepositorio<Contato> _repositorioContato;
        private readonly Notificador _notificador;

        public TelaCadastroContato(IRepositorio<Contato> repositorioContato, Notificador notificador) : base(" Cadastro de Contatos ")
        {
            _repositorioContato = repositorioContato;
            _notificador = notificador;
        }
        public override string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para Visualizar Contatos Agrupados por Cargo");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public void Inserir()
        {
            MostrarTitulo("Cadastro de Contatos");

            Contato novoContato = ObterContato();
            _repositorioContato.Inserir(novoContato);
            _notificador.ApresentarMensagem("Contato Inserido com sucesso!", TipoMensagem.Sucesso);

        }

       
        public void Editar()
        {
            MostrarTitulo("Editando Contato");

            bool temContatosCadastrados = VisualizarRegistros("Pesquisando");

            if (temContatosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum contato cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroContato = ObterNumeroRegistro();

            Contato ContatoAtualizado = ObterContato();

            bool conseguiuEditar = _repositorioContato.Editar(numeroContato, ContatoAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Contato editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Contato");

            bool temContatosRegistrados = VisualizarRegistros("Pesquisando");

            if(temContatosRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum contato cadastrado para excluir", TipoMensagem.Atencao);
                return;
            }

            int numeroContato = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioContato.Excluir(numeroContato);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possivel excluir. ",TipoMensagem.Erro);
            else
               _notificador.ApresentarMensagem("Contato excluido com sucesso", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizado)
        {
            if (tipoVisualizado == "Tela")
            MostrarTitulo("Visualização de Contatos");
            
            List<Contato> contatos = _repositorioContato.SelecionarTodos();

            if(contatos.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum contato disponivel", TipoMensagem.Atencao);
                return false;
            }

            foreach (Contato contato in contatos)
            {
                Console.WriteLine(contato.ToString());
            }

            Console.ReadLine();
            
            return true;
        }

        public bool VisualizarPorCargo(string tipoVisualizado)
        {
            if (tipoVisualizado == "Tela")
                MostrarTitulo("Visualização de Contatos por Cargo");

            List<Contato> contatos = _repositorioContato.SelecionarTodos();
            contatos.Sort();

            if (contatos.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum contato disponivel", TipoMensagem.Atencao);
                return false;
            }

            foreach (Contato contato in contatos)
            {
                Console.WriteLine(contato.ToString());
            }

            Console.ReadLine();

            return true;
        }
        private Contato ObterContato()
        {
            Console.Write("Digite o Nome do contato: ");
            string nome = Console.ReadLine();

            string telefone = TelefoneEhValido();

            string email = "";
            bool emailValido = true;
            while (emailValido)
            {
                Console.Write("Digite o Email do contato: ");
                email = Console.ReadLine();
                
                emailValido = email.Contains("@") && email.Contains(".com");
                
                if (emailValido == false)
                {
                    _notificador.ApresentarMensagem("O email digitado está invalido", TipoMensagem.Atencao);
                    emailValido = true;
                    continue;
                }
                if (emailValido == true)
                {
                    emailValido = false;
                }
            }
            Console.Write("Digite a Empresa onde o contato trabalha: ");
            string empresa = Console.ReadLine();

            Console.Write("Digite o Cargo do contato: ");
            string cargo = Console.ReadLine();

            return new Contato(nome, telefone, email, empresa, cargo);
        }

        private static string TelefoneEhValido()
        {
            string telefone = "";
            bool telefoneValido = true;
            while (telefoneValido)
            {
                Console.Write("Digite o Telefone do contato: ");
                telefone = Console.ReadLine();

                if (telefone.Length < 9)
                {
                    Console.WriteLine("Número de telefone invalido! Tente novamente.", TipoMensagem.Atencao);
                    continue;
                }
                telefoneValido = false;
            }

            return telefone;
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do Contato que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioContato.ExisteRegistro(numeroRegistro);

                if( numeroRegistroEncontrado == false)
                {
                    _notificador.ApresentarMensagem("ID do Contato não foi encontrado, digite novamente",TipoMensagem.Atencao);
                }

            }while(numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

    }
}
