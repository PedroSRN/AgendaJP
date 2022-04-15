using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova5_AgendaJP_ConsoleApp.Compartilhado
{
    public class RepositorioBase<T> : IRepositorio<T> where T : EntidadeBase
    {
        protected readonly List<T> registros;

        protected int contadorNumero;

        public RepositorioBase()
        {
            registros = new List<T>();
        }

        public virtual void Inserir(T entidade)
        {
            entidade.ID = ++contadorNumero;
            registros.Add(entidade);

            
        }
        public bool Editar(int idSelecionado, T novaEntidade)
        {
            foreach(T entidade in registros)
            {
                if(idSelecionado == entidade.ID)
                {
                    novaEntidade.ID = entidade.ID;

                    int posicaoParaEditar = registros.IndexOf(entidade);
                    registros[posicaoParaEditar] = novaEntidade;

                    return true;
                }
            }
            return false;
        }

        public bool Excluir(int idSelecionado)
        {
            foreach(T entidade in registros)
            {
                if(idSelecionado == entidade.ID)
                {
                    registros.Remove(entidade);
                    return true;
                }
            }
            return false;
        }

        public bool ExisteRegistro(int idSelecionado)
        {
            foreach (T entidade in registros)
            {
                if (idSelecionado == entidade.ID)
                {
                    return true;
                }
            }
            return false;
        }

        public List<T> SelecionarTodos()
        {
          return registros;
        }

        
    }
}   
