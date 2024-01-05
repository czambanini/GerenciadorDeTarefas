using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GerenciadorDeTarefas.Usuarios
{
    internal class LerUsuarioCSV
    {
        private string arquivoJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Usuarios", "ListaDeUsuarios.json");
        private List<Usuario> listaUsuarios;
        private List<Desenvolvedor> listaDesenvolvedores;
        private List<TechLeader> listaTechLeaders;

        public LerUsuarioCSV()
        {
            arquivoJson = arquivoJson.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "GerenciadorDeTarefas");
            listaDesenvolvedores = InicializarUsuarios2().Item1;
            listaTechLeaders = InicializarUsuarios2().Item2;
        }

        public List<Desenvolvedor> RetornarListaDevs()
        {
            listaDesenvolvedores = InicializarUsuarios2().Item1;
            return listaDesenvolvedores;
        }

        public List<TechLeader> RetornarListaLeaders()
        {
            listaTechLeaders = InicializarUsuarios2().Item2;
            return listaTechLeaders;
        }

        private (List<Desenvolvedor>, List<TechLeader>) InicializarUsuarios2()
        {
            try
            {
                string json = File.ReadAllText(arquivoJson);
                Desenvolvedor[] arrayUsuarios = JsonConvert.DeserializeObject<Desenvolvedor[]>(json);
                List<Desenvolvedor> ListaDesenvolvedores = arrayUsuarios.Where(usuario => usuario.Cargo == Cargo.Desenvolvedor).ToList();

                TechLeader[] arrayUsuarios2 = JsonConvert.DeserializeObject<TechLeader[]>(json);
                List<TechLeader> ListaTechLeaders = arrayUsuarios2.Where(techleader => techleader.Cargo == Cargo.TechLeader).ToList();

                return (ListaDesenvolvedores, ListaTechLeaders);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro na inicialização dos usuários: " + ex.Message);
                return (null, null);
            }
        }

        public void LerTodosUsuarios()
        {
            try
            {
                foreach (var usuario in listaUsuarios)
                {
                    usuario.ExibirInformacoes();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao exibir os detalhes dos funcionários: " + ex.Message);
            }
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

        public void AdicionarNovoFuncionario(Usuario novousuario)
        {
            listaUsuarios.Add(novousuario);

            string novoJson = JsonConvert.SerializeObject(listaUsuarios, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(arquivoJson, novoJson);

            Console.WriteLine("Novo usuário adicionado com sucesso!");
        }
    }
}
