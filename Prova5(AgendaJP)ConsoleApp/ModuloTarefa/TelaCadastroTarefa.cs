using ClubeLeitura.ConsoleApp.Compartilhado;
using Prova5_AgendaJP_ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova5_AgendaJP_ConsoleApp.ModuloTarefa
{
    public class TelaCadastroTarefa : TelaBase ,ICadastroBasico
    {
        private readonly IRepositorio<Tarefa> _repositorioTarefa;
        private readonly Notificador _notificador;

        public TelaCadastroTarefa(IRepositorio<Tarefa> repositorioTarefa, Notificador notificador) : base(" Cadastro de Tarefas ")
        {
            _repositorioTarefa = repositorioTarefa;
            _notificador = notificador;
        }

     
        public void Inserir()
        {
            MostrarTitulo("Cadastro de Tarefas");

            Tarefa novaTarefa = ObterTarefa();
            _repositorioTarefa.Inserir(novaTarefa);
            _notificador.ApresentarMensagem("Tarefa cadastrada com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Tarefa");

            bool temFilmesCadastrados = VisualizarRegistros("Pesquisando");

            if (temFilmesCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhuma Tarefa cadastrada para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroTarefa = ObterNumeroRegistro();

            Tarefa tarefaAtualizada = ObterTarefa();

            bool conseguiuEditar = _repositorioTarefa.Editar(numeroTarefa, tarefaAtualizada);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Tarefa editada com sucesso!", TipoMensagem.Sucesso);
        }

        
        public void Excluir()
        {
            MostrarTitulo("Excluindo Tarefa");

            bool temFilmesCadastrados = VisualizarRegistros("Pesquisando");

            if (temFilmesCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhuma tarefa cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroFilme = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioTarefa.Excluir(numeroFilme);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Tarefa excluído com sucesso", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizado)
        {
            if (tipoVisualizado == "Tela")
                MostrarTitulo("Visualização de Tarefas");
            
            List<Tarefa> tarefas = _repositorioTarefa.SelecionarTodos();
            tarefas.Sort();

            if (tarefas.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma tarefa disponível.", TipoMensagem.Atencao);
                return false;
            }

          
            foreach (Tarefa tarefa in tarefas)
                
                Console.WriteLine(tarefa.ToString());

            Console.ReadLine();

            return true;
        }

        public Tarefa ObterTarefa()
        {
            int categoria = ObterCategoriaTarefa();

            Console.Write("Digite o Titulo da tarefa: ");
            string titulo = Console.ReadLine();

            DateTime dataCriacao = DateTime.Now;

            Console.Write("Digite a Data de Conclusão da tarefa: ");
            DateTime dataConclusao = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite o percentual de conclusão da tarefa: ");
            int percentualConcluido = Convert.ToInt32(Console.ReadLine());

            return new Tarefa(categoria, titulo, dataCriacao, dataConclusao, percentualConcluido);

        }

        public int ObterCategoriaTarefa()
        {
            string categoria = "";
            int numCategoria = 0;
            bool categoriaValida = true;
            while (categoriaValida)
            {
                Console.Write("Digite a Categoria da tarefa (Alta,Media,Baixa): ");
                categoria = Console.ReadLine();

                if (categoria == "Alta" || categoria == "alta")
                    numCategoria += 3;
                
                else if (categoria == "Média" || categoria == "média")
                    numCategoria += 2;
               
                else if (categoria == "Baixa" || categoria == "baixa")
                    numCategoria += 1;
                
                else if (categoria != "Alta" || categoria != "Média" || categoria != "Baixa" || categoria != "alta" || categoria != "média" || categoria != "baixa")
                {
                    _notificador.ApresentarMensagem("Valor invalido! Digite novamente", TipoMensagem.Atencao);
                    continue;
                }
                categoriaValida = false;
               
            }

            
            return numCategoria;
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID da Tarefa que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioTarefa.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID da Tarefa não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

        
    }
}
