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
                Desenvolvedor desenvolvedor = (Desenvolvedor)login;
                InterfaceDev.MenuDesenvolvedor(desenvolvedor);
            } else if (login is TechLeader)
            {
                TechLeader techLeader = (TechLeader)login;
                InterfaceLeader.MenuTechLeader(techLeader);
            } else
            {
                Console.WriteLine("Usuário não encontrado");
            }

        }
    }
}
