using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Tarefas
{
    internal static class TarefaResponsavel
    {
        public static void EnviarParaAnalise(int idTarefa)
        {
            Tarefa tarefa = RelacaoTarefas.AcharTarefaPeloId(idTarefa);
            tarefa.StatusTarefa = StatusTarefa.EmAnalise;
        }

    }
}
