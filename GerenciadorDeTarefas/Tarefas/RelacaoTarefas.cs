using GerenciadorDeTarefas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GerenciadorDeTarefas.Tarefas
{
    internal static class RelacaoTarefas
    {
        public static List<Tarefa> relacaoTarefas = new List<Tarefa>();

        public static void CriarTarefaDev(string nome, string descricao, Usuario responsavel)
        {
            relacaoTarefas.Add(new Tarefa(nome, descricao, responsavel));
        }

        public static void AdicionarTarefa(Tarefa tarefaNova)
        {
            relacaoTarefas.Add(tarefaNova);
        }

        public static List<Tarefa> GetLista() 
        {
            return relacaoTarefas;
        }
            
        public static void ImprimirTodasAsTarefas()
        {
            foreach (Tarefa tarefa in relacaoTarefas)
            {
                tarefa.ExibirInformacoes();
                Console.WriteLine();
            }
        }

        public static Tarefa PedirIdTarefa()
        {
            Console.WriteLine($"\nInsira ID da tarefa:");
            int idTarefa;

            while (!int.TryParse(Console.ReadLine(), out idTarefa))
            {
                Console.Write("Entrada inválida, insira um número: ");
            }

            Tarefa tarefa = AcharTarefaPeloId(idTarefa);
            while (tarefa == null)
            {
                Console.Write($"Tarefa de id {idTarefa} não encontrada. Tente novamente.");
                tarefa = RelacaoTarefas.PedirIdTarefa();
            }

            return tarefa;
        }
        public static Tarefa AcharTarefaPeloId(int id)
        {
            foreach (Tarefa tarefa in relacaoTarefas)
            {
                if (tarefa.id == id)
                {
                    //int index = relacaoTarefas.IndexOf(tarefa);
                    //return relacaoTarefas[index];
                    return tarefa;
                }
            }
            return null;
        }





        //usadas só para criar as tarefas de exemplo
        public static void CriarTarefaExemplo(string nome, string descricao, Usuario responsavel, DateTime datalimite, StatusTarefa status)
        {
            relacaoTarefas.Add(new Tarefa(nome, descricao, responsavel, datalimite, status));
        }

    }
}
