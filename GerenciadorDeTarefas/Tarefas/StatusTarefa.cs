using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Tarefas
{
    enum StatusTarefa
    {
        AguardadoAprovacaoInicial = 1,
        EmAndamento = 2,
        Atrasada = 3,
        Cancelada = 4,
        Impedida = 5,
        EmAnalise = 6,
        Concluida = 7,
    }
}
