using GerenciadorDeTarefas.Tarefas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Usuarios
{
    internal class Desenvolvedor : Usuario
    {
        public Desenvolvedor(string nomeDeUsuario, string nome, string senha, Cargo cargo) : base (nomeDeUsuario, nome, senha, cargo)
        {

        }

        public static Desenvolvedor BuscarPorLogin(string nomeDeUsuario)
        {
            LerUsuarioCSV lerusuarios = new LerUsuarioCSV();
            List<Desenvolvedor> listaDevs = lerusuarios.RetornarListaDevs();

            foreach (Desenvolvedor desenvolvedor in listaDevs)
            {
                if (desenvolvedor.NomeDeUsuario == nomeDeUsuario)
                {
                    return desenvolvedor;
                }
            }

            return null;
        }

        public static Desenvolvedor PedirLoginDev()
        {
            Console.WriteLine($"\nNome de usuário do desenvolvedor:");
            string? loginDev = Console.ReadLine();
            while (string.IsNullOrEmpty(loginDev))
            {
                Console.WriteLine("O campo responsavel não pode ser vázio, digite novamente:");
                loginDev = Console.ReadLine();
            }

            Desenvolvedor desenvolvedor = Desenvolvedor.BuscarPorLogin(loginDev);
            while (desenvolvedor == null)
            {
                Console.Write($"Desenvolvedor {loginDev} não encontrada. Tente novamente.");
                desenvolvedor = Desenvolvedor.BuscarPorLogin(loginDev);
            }

            return desenvolvedor;
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

            Desenvolvedor responsavel = this;

            Tarefa tarefaNova = new Tarefa(nome, descricao, responsavel);
            RelacaoTarefas.AdicionarTarefa(tarefaNova);
        }

        public void ImprimirTarefas()
        {
            RelacaoTarefas.ImprimirTarefasDev(this);
        }

    }
}
