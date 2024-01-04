using GerenciadorDeTarefas.Tarefas;
using System;
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
            string nome = Console.ReadLine();
            Console.WriteLine("Descrição:");
            string descricao = Console.ReadLine();
            Console.WriteLine("Desenvolvedor responsável (nome de usuário):");
            string nomeresponsavel = Console.ReadLine();
            Desenvolvedor responsavel = Desenvolvedor.BuscarPorLogin(nomeresponsavel);
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


        //ver tarefa de todos, criar tarefas, assumir tarefas, acessar estatisticas (atrasos, concluidas, abandonadas, impedimento, em analise)
        //autorizar o inicio de tarefas em analise, colocar um responsavel ou mudar responsavel da tarefa.
        //adiciona tempo e correlação as tarefas. Aprovar tarefas feitas.
        //adicionar desenvolvedores ao txt/json
    }
}
