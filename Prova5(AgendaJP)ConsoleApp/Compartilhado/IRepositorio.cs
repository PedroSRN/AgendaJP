using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova5_AgendaJP_ConsoleApp.Compartilhado
{
    public interface IRepositorio<T> where T: EntidadeBase
    {
        void Inserir(T entidade);
        bool Editar(int idSelecionado, T novaEntidade);
        bool Excluir(int idSelecionado);
        bool ExisteRegistro(int idSelecionado);
        List<T> SelecionarTodos();
    }
}
