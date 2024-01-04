using GerenciadorDeTarefas.Tarefas;
using GerenciadorDeTarefas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Interface
{
    internal class InterfaceLeader
    {

        internal static void MenuTechLeader(TechLeader techLeaderLogado)
        {
            Console.Clear();
            Console.WriteLine($"SISTEMA DE TAREFA LOGADO COM SUCESSO \nUsuário: {techLeaderLogado.Cargo} {techLeaderLogado.Nome}.");

            Console.WriteLine($"\nSELECIONE OPÇÃO DESEJADA:");
            Console.WriteLine($"1. Exibir Tarefas \n2. Criar nova tarefa \n3. Selecionar Tarefa");
            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.Write("Digite o número correspondente à sua escolha: ");
            }

            switch (opcao)
            {
                case 1:
                    RelacaoTarefas.ImprimirTodasAsTarefas();//mudar para menu estatistica
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuTechLeader(techLeaderLogado);
                    return;
                case 2:
                    techLeaderLogado.CriarTarefa();
                    MenuTechLeader(techLeaderLogado);
                    return;
                case 3:
                    Tarefa tarefaEscolhida = RelacaoTarefas.PedirIdTarefa();
                    MenuTarefa(techLeaderLogado, tarefaEscolhida);
                    MenuTechLeader(techLeaderLogado);
                    return;
                default:

                    break;
            }
        }

        internal static void MenuTarefa(TechLeader techLeaderLogado, Tarefa tarefaEscolhida)
        {
            Console.Clear();
            Console.WriteLine($"\nMENU DA TAREFA");
            tarefaEscolhida.ExibirInformacoes();

            Console.WriteLine($"SELECIONE OPÇÃO DESEJADA:");
            Console.WriteLine($"1. Assumir Responsabilidade \n2. Mudar Responsável \n3. Adicionar Correlação");
            if (tarefaEscolhida.StatusTarefa == StatusTarefa.AguardadoAprovacaoInicial) Console.WriteLine($"4. Autorizar Inicio");
            if (tarefaEscolhida.StatusTarefa == StatusTarefa.EmAnalise) Console.WriteLine($"5. Aprovar Conclusão");
            Console.WriteLine($"0. Voltar");

            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.Write("Digite o número correspondente à sua escolha: ");
            }

            switch (opcao)
            {
                case 1:
                    techLeaderLogado.AssumirTarefa(tarefaEscolhida);
                    MenuTarefa(techLeaderLogado, tarefaEscolhida);
                    return;
                case 2:
                    techLeaderLogado.MudarResponsavel(tarefaEscolhida);
                    MenuTarefa(techLeaderLogado, tarefaEscolhida);
                    return;
                case 3:
                    techLeaderLogado.AdicionarPrerequisito(tarefaEscolhida);
                    MenuTarefa(techLeaderLogado, tarefaEscolhida);
                    return;
                case 4:
                    techLeaderLogado.AprovarTarefa(tarefaEscolhida);
                    MenuTarefa(techLeaderLogado, tarefaEscolhida);
                    return;
                case 5:
                    techLeaderLogado.ConcluirTarefa(tarefaEscolhida);
                    MenuTarefa(techLeaderLogado, tarefaEscolhida);
                    return;
                case 0:
                    MenuTechLeader(techLeaderLogado);
                    return;
                default:
                    Console.WriteLine($"\nNúmero não corresponde as opções. Digite novamente");
                    MenuTarefa(techLeaderLogado, tarefaEscolhida);
                    break;
            }

        }

        internal static void MenuEstatisticas()
        {

        }
    }
}
