using Domain.UserAggregate;

namespace Domain.TaskAggregate
{
    public class Task
    {
        public readonly int id;
        public string Name { get; set; }
        public string Description { get; set; }
        public User? Responsible { get; set; }
        public DateTime? LimitDate { get; set; }
        public StatusTarefa TaskStatus { get; set; }
        public Task? Prerequisite { get; set; }

        GeradorId geradorIdTarefa = new GeradorId();

        //construtor para desenvolvedores
        public Task(string nome, string descricao, User responsavel)
        {
            this.id = geradorIdTarefa.AtribuirId();
            Name = nome;
            Description = descricao;
            Responsible = responsavel;
            TaskStatus = StatusTarefa.AguardadoAprovacaoInicial;
        }

        //construtor para techleaders
        public Task(string nome, string descricao, User responsavel, DateTime datalimite, Task prerequisite)
        {
            this.id = geradorIdTarefa.AtribuirId();
            Name = nome;
            Description = descricao;
            Responsible = responsavel;
            LimitDate = datalimite;
            TaskStatus = StatusTarefa.EmAndamento;
            Prerequisite = prerequisite;

        }

        public void ExibirInformacoes()
        {
            this.ConferirAtraso();
            this.ConferirImpedimento();
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Nome: {Name}");
            Console.WriteLine($"Descrição: {Description} ");

            if (Responsible != null && Responsible._name != null) Console.WriteLine($"Responsável: {Responsible._name}");
            else Console.WriteLine($"Responsável: ");

            Console.WriteLine($"Data Limite: {LimitDate}");
            Console.WriteLine($"Status: {TaskStatus}");

            if (Prerequisite != null && Prerequisite.Name != null) Console.WriteLine($"Prerequisito: {Prerequisite.Name}");
            else Console.WriteLine($"Prerequisito: ");

            Console.WriteLine();
        }

        public void AprovarTarefa(DateTime datalimite)
        {
            if (this.TaskStatus != StatusTarefa.AguardadoAprovacaoInicial)
            {
                Console.WriteLine($"Essa tarefa não está aguardando aprovação. Status atual {this.TaskStatus}");
            }
            else
            {
                LimitDate = datalimite;
                TaskStatus = StatusTarefa.EmAndamento;
                Console.WriteLine($"Tarefa {this.id} aprovada para dar andamento");
            }
        }

        public void ConcluirTarefa()
        {
            if (this.TaskStatus != StatusTarefa.EmAnalise)
            {
                Console.WriteLine($"Essa tarefa não foi submetida para conclusão. Status atual {this.TaskStatus}");
            }
            else
            {
                TaskStatus = StatusTarefa.Concluida;
                Console.WriteLine($"Tarefa {this.id} mudada para concluída");
            }
        }

        public void CancelarTarefa()
        {
            if (this.TaskStatus == StatusTarefa.Cancelada)
            {
                Console.WriteLine($"Essa tarefa já foi cancelada.");
            }
            else
            {
                TaskStatus = StatusTarefa.Cancelada;
                Console.WriteLine($"Tarefa {this.id} mudada para cancelada.");
            }
        }

        public void MudarDataLimite(DateTime novoPrazo)
        {
            LimitDate = novoPrazo;
        }

        public void MudarResponsavel(User user)
        {
            Responsible = user;
        }


        public void AdicionarPreRequisito()
        {
            Console.WriteLine($"\nInsira ID da tarefa pré-requisito:");
            int idPrereq;
            while (!int.TryParse(Console.ReadLine(), out idPrereq))
            {
                Console.Write("Digite o número correspondente à sua escolha: ");
            }
            Task prereq = RelacaoTarefas.AcharTarefaPeloId(idPrereq);
            Prerequisite = prereq;
        }

        public void ConferirAtraso()
        {
            if (this.LimitDate < DateTime.Now && (this.TaskStatus != StatusTarefa.Concluida && this.TaskStatus != StatusTarefa.Cancelada))
            {
                this.TaskStatus = StatusTarefa.Atrasada;
            }
        }

        public void ConferirImpedimento()
        {
            if (this.Prerequisite != null)
            {
                Task tarefaPrereq = this.Prerequisite;
                if (tarefaPrereq.TaskStatus != StatusTarefa.Concluida)
                {
                    this.TaskStatus = StatusTarefa.Impedida;
                }
            }
        }

        public void SubmeterParaConclusao()
        {
            TaskStatus = StatusTarefa.EmAnalise;
        }

        public static DateTime PedirDataLimite()
        {
            Console.WriteLine("Data limite (no formato dd/mm/yyyy):");
            DateTime datalimite = new DateTime();
            string input = Console.ReadLine();

            while (true)
            {
                if (DateTime.TryParse(input, out datalimite))
                {
                    return datalimite;
                }
                else
                {
                    Console.WriteLine("Formato de data inválido. Certifique-se de usar o formato dd/mm/yyyy.");
                }
            }
        } //isso esta em um lugar ruim


        //construtor usado só para as tarefas de exemplo
        public Task(string nome, string descricao, User responsavel, DateTime datalimite, StatusTarefa status)
        {
            this.id = geradorIdTarefa.AtribuirId();
            Name = nome;
            Description = descricao;
            Responsible = responsavel;
            LimitDate = datalimite;
            TaskStatus = status;

        }

    }
}
