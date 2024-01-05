using GerenciadorDeTarefas.Tarefas;
using GerenciadorDeTarefas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Interface
{
    internal class InterfaceDev
    {
        internal static void MenuDesenvolvedor(Desenvolvedor desenvolvedorLogado)
        {
            Console.Clear();
            Console.WriteLine($"SISTEMA DE TAREFA LOGADO COM SUCESSO \nUsuário: {desenvolvedorLogado.Cargo} {desenvolvedorLogado.Nome}.");

            Console.WriteLine($"\nSELECIONE OPÇÃO DESEJADA:");
            Console.WriteLine($"1. Exibir Tarefas \n2. Criar nova tarefa \n3. Submeter tarefa para conclusão");
            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.Write("Digite o número correspondente à sua escolha: ");
            }

            switch (opcao)
            {
                case 1:
                    desenvolvedorLogado.ImprimirTarefas();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuDesenvolvedor(desenvolvedorLogado);
                    return;
                case 2:
                    desenvolvedorLogado.CriarTarefa();
                    MenuDesenvolvedor(desenvolvedorLogado);
                    return;
                case 3:
                    //Tarefa tarefaEscolhida = RelacaoTarefas.PedirIdTarefa();
                    //MenuTarefa(desenvolvedorLogado, tarefaEscolhida);
                    MenuDesenvolvedor(desenvolvedorLogado);
                    return;
                default:

                    break;
            }
        }
    }
}
