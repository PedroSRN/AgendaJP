using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova5_AgendaJP_ConsoleApp.Compartilhado
{
    public interface ICadastroBasico
    {
        void Inserir();
        void Editar();
        void Excluir();
        bool VisualizarRegistros(string tipoVisualizado);
    }
}
