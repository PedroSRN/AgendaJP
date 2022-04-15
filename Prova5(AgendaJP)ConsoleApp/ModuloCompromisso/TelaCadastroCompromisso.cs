using ClubeLeitura.ConsoleApp.Compartilhado;
using Prova5_AgendaJP_ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova5_AgendaJP_ConsoleApp.ModuloCompromisso
{
    public class TelaCadastroCompromisso : TelaBase, ICadastroBasico
    {
        private readonly IRepositorio<Compromisso> _repositorioCompromisso;
        private readonly Notificador _notificador;

        public TelaCadastroCompromisso(IRepositorio<Compromisso> repositorioCompromisso, Notificador notificador) : base(" Cadastro de Compromissos ")
        {
            _repositorioCompromisso = repositorioCompromisso;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Compromissos");

            Compromisso novoCompromisso = ObterCompromisso();

            _repositorioCompromisso.Inserir(novoCompromisso);
            _notificador.ApresentarMensagem("Compromisso Cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        
        public void Editar()
        {
            MostrarTitulo("Editando Compromisso");

            bool temCompromissosCadastrados = VisualizarRegistros("Pesquisando");

            if(temCompromissosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum Compromisso cadastrado para editar",TipoMensagem.Atencao);
                return;
            }

            int numeroCompromisso = ObterNumeroRegistro();

            Compromisso compromissoAtualizado = ObterCompromisso();

            bool conseguiuEditar = _repositorioCompromisso.Editar(numeroCompromisso, compromissoAtualizado);

            if (conseguiuEditar)
            {
                _notificador.ApresentarMensagem("Não foi possivel editar. ", TipoMensagem.Erro);
            }
            else
            {
                _notificador.ApresentarMensagem("Compromisso editado com sucesso!", TipoMensagem.Sucesso);
            }
        }

        public void Excluir()
        {
            bool temCompromissosCadastrados = VisualizarRegistros("Pesquisando");

            if (temCompromissosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum Compromisso cadastrado para excluir", TipoMensagem.Atencao);
                return;
            }

            int numeroCompromisso = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioCompromisso.Excluir(numeroCompromisso);

            if (conseguiuExcluir)
            {
                _notificador.ApresentarMensagem("Não foi possivel excluir. ", TipoMensagem.Erro);
            }
            else
            {
                _notificador.ApresentarMensagem("Compromisso excluido com sucesso!", TipoMensagem.Sucesso);
            }

        }

        public bool VisualizarRegistros(string tipoVisualizado)
        {
            if (tipoVisualizado == "Tela")
                MostrarTitulo("Visualização de Compromissos");

            List<Compromisso> compromissos = _repositorioCompromisso.SelecionarTodos();

            if(compromissos.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum compromisso disponivel. ", TipoMensagem.Atencao);
                return false;
            }

            foreach(Compromisso compromisso in compromissos)
            {
                Console.WriteLine(compromisso.ToString());
            }

            Console.ReadLine();

            return true;
        }

        private Compromisso ObterCompromisso()
        {
            Console.Write("Digite a Data do Compromisso: ");
            DateTime dataCompromisso = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a Hora do Inicio do Compromisso: ");
            DateTime horaInicio = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a Hora do Termino do Compromisso: ");
            DateTime horaTermino = Convert.ToDateTime(Console.ReadLine());

           
            Console.Write("Digite o Assunto do Compromisso: ");
            string assunto = Console.ReadLine();

            Console.Write("Digite o Local do Compromisso: ");
            string local = Console.ReadLine();

            return new Compromisso(local, assunto, horaInicio, horaTermino, dataCompromisso);
        }
        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do Compromisso que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioCompromisso.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                {
                    _notificador.ApresentarMensagem("ID do Contato não foi encontrado, digite novamente", TipoMensagem.Atencao);
                }

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

    }
}
