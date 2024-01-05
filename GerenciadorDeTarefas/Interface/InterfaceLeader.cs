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
            Console.WriteLine($"1. Exibir Todas as Tarefas Ativas \n2. Filtros e Estatísticas \n3. Criar nova tarefa \n4. Selecionar Tarefa");
            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.Write("Digite o número correspondente à sua escolha: ");
            }

            switch (opcao)
            {
                case 1:
                    RelacaoTarefas.ImprimirTodasAsTarefas();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuTechLeader(techLeaderLogado);
                    return;
                case 2:
                    MenuEstatisticas(techLeaderLogado);
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuTechLeader(techLeaderLogado);
                    return;
                case 3:
                    techLeaderLogado.CriarTarefa();
                    MenuTechLeader(techLeaderLogado);
                    return;
                case 4:
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
            Console.WriteLine($"1. Assumir Responsabilidade \n2. Mudar Responsável \n3. Adicionar Correlação \n4. Cancelar Tarefa");
            if (tarefaEscolhida.StatusTarefa == StatusTarefa.AguardadoAprovacaoInicial) Console.WriteLine($"5. Autorizar Inicio");
            if (tarefaEscolhida.StatusTarefa == StatusTarefa.EmAnalise) Console.WriteLine($"6. Aprovar Conclusão");
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
                    techLeaderLogado.CancelarTarefa(tarefaEscolhida);
                    MenuTarefa(techLeaderLogado, tarefaEscolhida);
                    return;
                case 5:
                    techLeaderLogado.AprovarTarefa(tarefaEscolhida);
                    MenuTarefa(techLeaderLogado, tarefaEscolhida);
                    return;
                case 6:
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

        internal static void MenuEstatisticas(TechLeader techLeaderLogado)
        {
            Console.Clear();
            EstatisticasTarefas estatisticas = new EstatisticasTarefas();

            Console.WriteLine($"EXIBIR TAREFAS E ESTATÍSTICAS:");
            Console.WriteLine($"1. Dados Gerais \n2. Tarefas Aguardando Aprovação Inicial \n3. Tarefas em Andamento " +
                $"\n4. Tarefas Atrasadas \n5. Tarefas Impedidas \n6. Tarefas em Analise \n7. Tarefas Concluídas \n8. Tarefas Canceladas \n0. VOLTAR");
            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.Write("Digite o número correspondente à sua escolha: ");
            }

            switch (opcao)
            {
                case 1:
                    techLeaderLogado.ExibirDadosGerais();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuEstatisticas(techLeaderLogado);
                    return;
                case 2:
                    Console.WriteLine($"\nTarefas Aguardando Aprovação Inicial");
                    techLeaderLogado.ExibirTarefasFiltradas(StatusTarefa.AguardadoAprovacaoInicial);
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuEstatisticas(techLeaderLogado);
                    return;
                case 3:
                    Console.WriteLine($"\nTarefas em Andamento");
                    techLeaderLogado.ExibirTarefasFiltradas(StatusTarefa.EmAndamento);
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuEstatisticas(techLeaderLogado);
                    return;
                case 4:
                    Console.WriteLine($"\nTarefas Atrasadas");
                    techLeaderLogado.ExibirTarefasFiltradas(StatusTarefa.Atrasada);
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuEstatisticas(techLeaderLogado);
                    return;
                case 5:
                    Console.WriteLine($"\nTarefas Impedidas");
                    techLeaderLogado.ExibirTarefasFiltradas(StatusTarefa.Impedida);
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuEstatisticas(techLeaderLogado);
                    return;
                case 6:
                    Console.WriteLine($"\nTarefas em Analise");
                    techLeaderLogado.ExibirTarefasFiltradas(StatusTarefa.EmAnalise);
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuEstatisticas(techLeaderLogado);
                    return;
                case 7:
                    Console.WriteLine($"\nTarefas Concluidas");
                    techLeaderLogado.ExibirTarefasFiltradas(StatusTarefa.Concluida);
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuEstatisticas(techLeaderLogado);
                    return;
                case 8:
                    Console.WriteLine($"\nTarefas Canceladas");
                    techLeaderLogado.ExibirTarefasFiltradas(StatusTarefa.Cancelada);
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuEstatisticas(techLeaderLogado);
                    return;
                case 0:
                    MenuTechLeader(techLeaderLogado);
                    return;
                default:

                    break;
            }
        }
    }
}
