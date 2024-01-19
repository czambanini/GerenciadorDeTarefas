using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Usuarios
{
    public class GestorDeUsuarios
    {

        private List<Desenvolvedor> listaDesenvolvedores;
        private List<TechLeader> listaTechLeaders;

        public GestorDeUsuarios()
        {
            LerUsuario lerUsuarioCSV = new LerUsuario();
            listaDesenvolvedores = lerUsuarioCSV.RetornarListaDevs();
            listaTechLeaders = lerUsuarioCSV.RetornarListaLeaders();
        }

        public void LerTodosDesenvolvedores()
        {
            try
            {
                foreach (var desenvolvedor in listaDesenvolvedores)
                {
                    desenvolvedor.ExibirInformacoes();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao exibir os detalhes dos funcionários: " + ex.Message);
            }
        }

        public void LerTodosTechLeaders()
        {
            try
            {
                foreach (var techLeader in listaTechLeaders)
                {
                    techLeader.ExibirInformacoes();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao exibir os detalhes dos funcionários: " + ex.Message);
            }
        }

        public void CadastrarNovoDev()
        {
            Console.WriteLine("\nCADASTRAR NOVO DESENVOLVEDOR:");

            Console.WriteLine("Nome de Usuário:");
            string? nomeDeUsuario = Console.ReadLine();
            bool validar = ValidarNomeUsuario(nomeDeUsuario);
            while (string.IsNullOrEmpty(nomeDeUsuario) || validar == false)
            {
                Console.WriteLine("O campo nome não pode ser vázio, digite novamente:");
                nomeDeUsuario = Console.ReadLine();
            }

            Console.WriteLine("Nome:");
            string? nome = Console.ReadLine();
            while (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("O campo nome não pode ser vázio, digite novamente:");
                nome = Console.ReadLine();
            }

            Console.WriteLine("Senha:");
            string? senha = Console.ReadLine();
            while (string.IsNullOrEmpty(senha))
            {
                Console.WriteLine("O campo nome não pode ser vázio, digite novamente:");
                nome = Console.ReadLine();
            }

            Cargo cargo = Cargo.Desenvolvedor;

            Usuario usuarioNovo = new Usuario(nomeDeUsuario, nome, senha, cargo);

            LerUsuario lerUsuarioCSV = new LerUsuario();
            lerUsuarioCSV.AdicionarNovoFuncionario(usuarioNovo);
        }

        private bool ValidarNomeUsuario(string? loginParaValidar)
        {
            bool validar = true;
            if (loginParaValidar == null) validar = false;
            foreach (Desenvolvedor desenvolvedor in listaDesenvolvedores)
            {
                if (loginParaValidar == desenvolvedor.NomeDeUsuario)
                {
                validar = false;
                Console.WriteLine("Nome de usuário já cadastrado.");
                }
            }
            foreach (TechLeader techLeader in listaTechLeaders)
            {
                if (loginParaValidar == techLeader.NomeDeUsuario)
                {
                    validar = false;
                    Console.WriteLine("Nome de usuário já cadastrado.");
                }
            }
            return validar;
        }

    }
}
