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
            Console.WriteLine($"\nInsira nome de usuário do desenvolvedor:");
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

        //"submeter criação" de tarefas (automaticamente responsavel e quem decide o tempo é o techleader)
        //ver suas tarefas ou relacionadas com a sua
    }
}
