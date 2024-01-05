using GerenciadorDeTarefas.Tarefas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Usuarios
{
    internal class TechLeader : Usuario
    {
        public TechLeader(string nomeDeUsuario, string nome, string senha, Cargo cargo) : base(nomeDeUsuario, nome, senha, cargo)
        {

        }

        public static TechLeader BuscarPorLogin(string nomeDeUsuario)
        {
            LerUsuarioCSV lerusuarios = new LerUsuarioCSV();
            List<TechLeader> listaTech = lerusuarios.RetornarListaLeaders();

            foreach (TechLeader techLeader in listaTech)
            {
                if (techLeader.NomeDeUsuario == nomeDeUsuario)
                {
                    return techLeader;
                }
            }

            return null;
        }

        public void CriarTarefa()
        {
            Console.WriteLine("\nCRIAR NOVA TAREFA:");

            Console.WriteLine("Nome:");
            string? nome = Console.ReadLine();
            while (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("O campo nome não pode ser vázio, digite novamente:");
                nome = Console.ReadLine();
            }

            Console.WriteLine("Descrição:");
            string? descricao = Console.ReadLine();
            if (string.IsNullOrEmpty(descricao))
            {
                descricao = " - ";
            }

            Console.WriteLine("Responsavel:");
            Desenvolvedor responsavel = Desenvolvedor.PedirLoginDev();

            DateTime datalimite = Tarefa.PedirDataLimite();

            Tarefa tarefaNova = new Tarefa(nome, descricao, responsavel, datalimite);
            RelacaoTarefas.AdicionarTarefa(tarefaNova);
        }

        public void AssumirTarefa(Tarefa tarefaEscolhida)
        {
            tarefaEscolhida.AssumirResponsabilidade(this);
            tarefaEscolhida.ExibirInformacoes();
        }

        public void MudarResponsavel(Tarefa tarefaEscolhida)
        {
            Desenvolvedor devResponsavel = Desenvolvedor.PedirLoginDev();
            tarefaEscolhida.MudarResponsavel(devResponsavel);
            tarefaEscolhida.ExibirInformacoes();
        }

        public void AdicionarPrerequisito(Tarefa tarefaEscolhida)
        {
            tarefaEscolhida.AdicionarPreRequisito();
            tarefaEscolhida.ExibirInformacoes();
        }

        public void AprovarTarefa(Tarefa tarefaEscolhida)
        {
            DateTime datalimite = Tarefa.PedirDataLimite();
            tarefaEscolhida.AprovarTarefa(datalimite);
        }

        public void ConcluirTarefa(Tarefa tarefaEscolhida)
        {
            tarefaEscolhida.ConcluirTarefa();
        }

        public void CancelarTarefa(Tarefa tarefaEscolhida)
        {
            tarefaEscolhida.CancelarTarefa();
        }
        public void ExibirDadosGerais()
        {
            EstatisticasTarefas estatisticas = new EstatisticasTarefas();
            estatisticas.MostrarDadosGerais();
        }

        public void ExibirTarefasFiltradas(StatusTarefa status)
        {
            EstatisticasTarefas estatisticas = new EstatisticasTarefas();
            List<Tarefa> listafiltrada = new List<Tarefa>();

            if (status == StatusTarefa.AguardadoAprovacaoInicial) listafiltrada.AddRange(estatisticas.TarefasAguardandoAprovacaoInicial());
            else if (status == StatusTarefa.EmAndamento) listafiltrada.AddRange(estatisticas.TarefasEmAndamento());
            else if (status == StatusTarefa.Atrasada) listafiltrada.AddRange(estatisticas.TarefasAtrasadas());
            else if (status == StatusTarefa.Impedida) listafiltrada.AddRange(estatisticas.TarefasImpedidas());
            else if (status == StatusTarefa.EmAnalise) listafiltrada.AddRange(estatisticas.TarefasEmAnalise());
            else if (status == StatusTarefa.Concluida) listafiltrada.AddRange(estatisticas.TarefasConcluidas());
            else if (status == StatusTarefa.Cancelada) listafiltrada.AddRange(estatisticas.TarefasCanceladas());

            foreach (Tarefa tarefa in listafiltrada)
            {
                tarefa.ExibirInformacoes();
            }
        }
    }


        //acessar estatisticas (atrasos, concluidas, abandonadas, impedimento, em analise)
        //adicionar desenvolvedores ao txt/json
 }
