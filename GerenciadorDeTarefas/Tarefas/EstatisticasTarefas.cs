using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Tarefas
{
    public class EstatisticasTarefas
    {

        readonly List<Tarefa> relacaoTarefas = RelacaoTarefas.GetLista();

        internal List<Tarefa> TarefasAtrasadas()
        {
            List<Tarefa> tarefasAtrasadas = new List<Tarefa>();
            foreach (Tarefa tarefa in relacaoTarefas)
            {
                tarefa.ConferirAtraso();
                tarefa.ConferirImpedimento(); //defini que a prioridade é mostrar impedimento acima de atraso
                if (tarefa.StatusTarefa == StatusTarefa.Atrasada)
                {
                    tarefasAtrasadas.Add(tarefa);
                }
            }
            return tarefasAtrasadas;
        }
        internal List<Tarefa> TarefasImpedidas()
        {
            List<Tarefa> tarefasImpedidas = new List<Tarefa>();
            foreach (Tarefa tarefa in relacaoTarefas)
            {
                tarefa.ConferirImpedimento();
                if (tarefa.StatusTarefa == StatusTarefa.Impedida)
                {
                    tarefasImpedidas.Add(tarefa);
                }
            }
            return tarefasImpedidas;
        }
        internal List<Tarefa> TarefasEmAnalise()
        {
            List<Tarefa> tarefasEmAnalise = relacaoTarefas.Where(tarefa => tarefa.StatusTarefa == StatusTarefa.EmAnalise).ToList();
            return tarefasEmAnalise;
        }
        internal List<Tarefa> TarefasAguardandoAprovacaoInicial() 
        {
            List<Tarefa> tarefasAprovacaoInicial = relacaoTarefas.Where(tarefa => tarefa.StatusTarefa == StatusTarefa.AguardadoAprovacaoInicial).ToList();
            return tarefasAprovacaoInicial;
        }
        internal List<Tarefa> TarefasConcluidas() 
        {
            List<Tarefa> tarefasConcluidas = relacaoTarefas.Where(tarefa => tarefa.StatusTarefa == StatusTarefa.Concluida).ToList();
            return tarefasConcluidas;
        }
        internal List<Tarefa> TarefasEmAndamento() 
        {
            List<Tarefa> tarefasEmAndamento = relacaoTarefas.Where(tarefa => tarefa.StatusTarefa == StatusTarefa.EmAndamento).ToList();
            return tarefasEmAndamento;
        }
        internal List<Tarefa> TarefasCanceladas()
        {
            List<Tarefa> tarefasCanceladas = relacaoTarefas.Where(tarefa => tarefa.StatusTarefa == StatusTarefa.Cancelada).ToList();
            return tarefasCanceladas;
        }
        internal void MostrarDadosGerais() {
            Console.WriteLine($"\nAGUARDANDO APROVAÇÃO:");
            Console.WriteLine($"Aguardando aprovação inicial: {TarefasAguardandoAprovacaoInicial().Count}");
            Console.WriteLine($"Aguardando aprovação de conclusão: {TarefasEmAnalise().Count}");
            Console.WriteLine($"");
            Console.WriteLine($"Tarefas em Andamento: {TarefasEmAndamento().Count}");
            Console.WriteLine($"Tarefas Atrasadas: {TarefasAtrasadas().Count}");
            Console.WriteLine($"Tarefas Impedidas: {TarefasImpedidas().Count}"); 
            Console.WriteLine($"Tarefas Concluídas: {TarefasConcluidas().Count}");
            Console.WriteLine($"Tarefas Canceladas: {TarefasCanceladas().Count}");
        }
        internal void ImprimirLista(List<Tarefa> lista)
        {
            foreach(Tarefa tarefa in lista)
            {
                tarefa.ExibirInformacoes();
            }
        }

    }
}
