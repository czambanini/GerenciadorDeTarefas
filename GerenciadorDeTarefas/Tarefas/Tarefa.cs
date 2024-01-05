using GerenciadorDeTarefas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Tarefas
{
    internal class Tarefa
    {
        public readonly int id;
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Usuario? Responsavel { get; set; } //só um responsavel? como aceitar tanto dev quanto tech?
        public DateTime? DataLimite { get; set; }
        public StatusTarefa StatusTarefa { get; set; }
        public Tarefa? Prerequisito { get; set; }


        GeradorId geradorIdTarefa = new GeradorId();
        public Tarefa(string nome, string descricao, Usuario responsavel)
        {
            this.id = geradorIdTarefa.AtribuirId();
            Nome = nome;
            Descricao = descricao;
            Responsavel = responsavel;
            StatusTarefa = StatusTarefa.AguardadoAprovacaoInicial;
        }

        public Tarefa(string nome, string descricao, Usuario responsavel, DateTime datalimite) //adicionar prerequisito
        {
            this.id = geradorIdTarefa.AtribuirId();
            Nome = nome;
            Descricao = descricao;
            Responsavel = responsavel;
            DataLimite = datalimite;
            StatusTarefa = StatusTarefa.EmAndamento;

        }

        public void ExibirInformacoes()
        {
            this.ConferirAtraso();
            this.ConferirImpedimento();
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Descrição: {Descricao} ");

            if (Responsavel != null && Responsavel.Nome != null) Console.WriteLine($"Responsável: {Responsavel.Nome}");
            else Console.WriteLine($"Responsável: ");

            Console.WriteLine($"Data Limite: {DataLimite}");
            Console.WriteLine($"Status: {StatusTarefa}");

            if (Prerequisito != null && Prerequisito.Nome != null) Console.WriteLine($"Prerequisito: {Prerequisito.Nome}");
            else Console.WriteLine($"Prerequisito: ");

            Console.WriteLine();
        }

        public void AprovarTarefa(DateTime datalimite)
        {
            if (this.StatusTarefa != StatusTarefa.AguardadoAprovacaoInicial)
            {
                Console.WriteLine($"Essa tarefa não está aguardando aprovação. Status atual {this.StatusTarefa}");
            } else
            {
                DataLimite = datalimite;
                StatusTarefa = StatusTarefa.EmAndamento;
                Console.WriteLine($"Tarefa {this.id} aprovada para dar andamento");
            }
        }

        public void ConcluirTarefa()
        {
            if (this.StatusTarefa != StatusTarefa.EmAnalise)
            {
                Console.WriteLine($"Essa tarefa não foi submetida para conclusão. Status atual {this.StatusTarefa}");
            }
            else
            {
                StatusTarefa = StatusTarefa.Concluida;
                Console.WriteLine($"Tarefa {this.id} mudada para concluída");
            }
        }

        public void CancelarTarefa()
        {
            if (this.StatusTarefa == StatusTarefa.Cancelada)
            {
                Console.WriteLine($"Essa tarefa já foi cancelada.");
            }
            else
            {
                StatusTarefa = StatusTarefa.Cancelada;
                Console.WriteLine($"Tarefa {this.id} mudada para cancelada.");
            }
        }

        public void MudarDataLimite(DateTime novoPrazo)
        {
            DataLimite = novoPrazo;
        }

        public void MudarResponsavel(Desenvolvedor desenvolvedor)
        {
            Responsavel = desenvolvedor;
        }

        public void AssumirResponsabilidade(TechLeader techLeader)
        {
            Responsavel = techLeader;
        }

        public void AdicionarPreRequisito()
        {
            Console.WriteLine($"\nInsira ID da tarefa pré-requisito:");
            int idPrereq;
            while (!int.TryParse(Console.ReadLine(), out idPrereq))
            {
                Console.Write("Digite o número correspondente à sua escolha: ");
            }
            Tarefa prereq = RelacaoTarefas.AcharTarefaPeloId(idPrereq);
            Prerequisito = prereq;
        }

        public void ConferirAtraso()
        {
            if (this.DataLimite < DateTime.Now && (this.StatusTarefa != StatusTarefa.Concluida && this.StatusTarefa != StatusTarefa.Cancelada))
            {
                this.StatusTarefa = StatusTarefa.Atrasada;
            }
        }

        public void ConferirImpedimento()
        {
            if (this.Prerequisito != null)
            {
                Tarefa tarefaPrereq = this.Prerequisito;
                if (tarefaPrereq.StatusTarefa != StatusTarefa.Concluida)
                {
                    this.StatusTarefa = StatusTarefa.Impedida;
                }
            }
        }

        public void SubmeterParaConclusao ()
        {
                if (StatusTarefa == StatusTarefa.EmAnalise)
                {
                    StatusTarefa = StatusTarefa.Concluida;
                }

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
        public Tarefa(string nome, string descricao, Usuario responsavel, DateTime datalimite, StatusTarefa status)
        {
            this.id = geradorIdTarefa.AtribuirId();
            Nome = nome;
            Descricao = descricao;
            Responsavel = responsavel;
            DataLimite = datalimite;
            StatusTarefa = status;

        }

    }
}
