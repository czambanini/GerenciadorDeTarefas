using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorDeTarefas.Tarefas;
using GerenciadorDeTarefas.Usuarios;

namespace GerenciadorDeTarefas.Interface
{
    internal class TarefasParaExemplo
    {
        public static void CriarTarefas()
        {
            //Classe criada apenas para criar algumas tarefas de exemplo

            //Obter usuários
            Desenvolvedor dev1 = Desenvolvedor.BuscarPorLogin("NatR");
            Desenvolvedor dev2 = Desenvolvedor.BuscarPorLogin("BarC");
            Desenvolvedor dev3 = Desenvolvedor.BuscarPorLogin("DanS");
            TechLeader tech1 = TechLeader.BuscarPorLogin("TamU");
            TechLeader tech2 = TechLeader.BuscarPorLogin("FabV");

            //Criar tarefas
            RelacaoTarefas.CriarTarefaExemplo("Criar classes de usuários", "Criar classe usuário, funcionário e cliente", dev1, new DateTime(2024, 01, 01), StatusTarefa.EmAndamento);

            RelacaoTarefas.CriarTarefaExemplo("Criar classes de produtos", "Criação das classes de cada produto vendido", dev2, new DateTime(2024, 01, 25), StatusTarefa.EmAnalise);

            RelacaoTarefas.CriarTarefaExemplo("Criar classe para gerenciar estoque", "Controle de estoque de cada produto vendido entradas e saídas", dev3, new DateTime(2024, 03, 01), StatusTarefa.EmAndamento);

            RelacaoTarefas.CriarTarefaExemplo("Implementar métodos de funcionário", "Implementar metodos listados para a classe", tech1, new DateTime(2024, 02, 15), StatusTarefa.AguardadoAprovacaoInicial);

            RelacaoTarefas.CriarTarefaExemplo("Criar base para a interface do Usuario", "Criar diagramas para auxiliar nessa etapa", dev2, new DateTime(2024, 02, 02), StatusTarefa.AguardadoAprovacaoInicial);

            RelacaoTarefas.CriarTarefaExemplo("Criar diagramas de classe", "Criar diagrama de classe para guiar o desenvolvimento", dev1, new DateTime(2023, 12, 20), StatusTarefa.Concluida);
            
        }


    }
}
