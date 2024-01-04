using GerenciadorDeTarefas.Tarefas;
using GerenciadorDeTarefas.Usuarios;
using System;

namespace GerenciadorDeTarefas.Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TarefasParaExemplo.CriarTarefas();

            Console.WriteLine("BEM VINDO AO SISTEMA DE TAREFAS:\n");
            var login = Usuario.FazerLogin();
            if (login is Desenvolvedor) {
                Console.WriteLine("Identificou um dev");
            } else if (login is TechLeader)
            {
                TechLeader techLeader = (TechLeader)login;
                InterfaceLeader.MenuTechLeader(techLeader);
            } else
            {
                Console.WriteLine("Usuário não encontrado");
            }

            //LerUsuarioCSV lerUsuarios = new LerUsuarioCSV();

            //Console.WriteLine("LER TODOS DEVS");
            //lerUsuarios.LerTodosDesenvolvedores();

            //Console.WriteLine("LER TODOS TECHLEADERS");
            //lerUsuarios.LerTodosTechLeaders();


            //Console.WriteLine("LER TODOS");
            //lerUsuarios.LerTodosUsuarios();

            //Desenvolvedor dev1 = new Desenvolvedor();
            //TechLeader tech1 = new TechLeader();

            //Console.WriteLine("Hello, World!");
            

            //AutorizacaoTarefas.Correlacionar(3, 2);
            //RelacaoTarefas.ConferirAtraso(1);
            //RelacaoTarefas.ConferirImpedimento(3);

            //RelacaoTarefas.ImprimirTodasAsTarefas();

        }
    }
}
