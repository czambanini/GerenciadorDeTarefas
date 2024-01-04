using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Tarefas
{
    internal class GeradorId
    {
        static int nextId;
        public int Id { get; set; }

        public int AtribuirId()
        {
            Id = Interlocked.Increment(ref nextId);
            return Id;
        }
    }
}
