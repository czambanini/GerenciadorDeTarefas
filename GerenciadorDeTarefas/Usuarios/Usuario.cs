using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Usuarios
{
    public class Usuario
    {
        public string NomeDeUsuario { get; set; }
        public string Nome {  get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Cargo Cargo { get; set; }

        public Usuario(string nomeDeUsuario, string nome, string senha, Cargo cargo) {
            Nome = nome;
            NomeDeUsuario = nomeDeUsuario;
            Senha = senha;
            Cargo = cargo;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Nome de Usuario: {NomeDeUsuario}");
            Console.WriteLine($"Email: {Email} ");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine();
        }

        public static Usuario FazerLogin() {
            
            LerUsuario lerusuarios = new LerUsuario();
            List<Desenvolvedor> listaDevs = lerusuarios.RetornarListaDevs();
            List<TechLeader> listaLeaders = lerusuarios.RetornarListaLeaders();

            while (true)
            {
                Console.WriteLine("Insira nome de login:");
                string nomeLogin = Console.ReadLine()!;
                Console.WriteLine("Senha:");
                string senha = Console.ReadLine()!;

                foreach (Desenvolvedor desenvolvedor in listaDevs)
                {
                    if (desenvolvedor.NomeDeUsuario == nomeLogin && desenvolvedor.Senha == senha)
                    {
                        return desenvolvedor;
                    }
                }
                foreach (TechLeader techleader in listaLeaders)
                {
                    if (techleader.NomeDeUsuario == nomeLogin && techleader.Senha == senha)
                    {
                        return techleader;
                    }
                }

                Console.WriteLine("Usuário não identificado. Login ou senha incorretos.");
            }

        }



    }
}
