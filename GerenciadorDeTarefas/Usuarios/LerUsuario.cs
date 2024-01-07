using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Usuarios
{
    public class LerUsuario
    {
        private string arquivoJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Usuarios", "ListaDeUsuarios.json");
        private List<Usuario> listaUsuarios;
        private List<Desenvolvedor> listaDesenvolvedores;
        private List<TechLeader> listaTechLeaders;

        public LerUsuario()
        {
            arquivoJson = arquivoJson.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "GerenciadorDeTarefas");
            listaUsuarios = InicializarUsuarios().Item1;
            listaDesenvolvedores = InicializarUsuarios().Item2;
            listaTechLeaders = InicializarUsuarios().Item3;
        }

        public List<Desenvolvedor> RetornarListaDevs()
        {
            listaDesenvolvedores = InicializarUsuarios().Item2;
            return listaDesenvolvedores;
        }

        public List<TechLeader> RetornarListaLeaders()
        {
            listaTechLeaders = InicializarUsuarios().Item3;
            return listaTechLeaders;
        }

        //private (List<Usuario>, List<Desenvolvedor>, List<TechLeader>) InicializarUsuarios()
        //{
        //    try
        //    {
        //        string json = File.ReadAllText(arquivoJson);
        //        List<Usuario> listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);

        //        // Filtra a lista de usuários para obter a lista de Desenvolvedores
        //        List<Desenvolvedor> listaDesenvolvedores = listaUsuarios
        //            .Where(usuario => usuario.Cargo == Cargo.Desenvolvedor)
        //            .Select(usuario => (Desenvolvedor)usuario)
        //            .ToList();

        //        // Filtra a lista de usuários para obter a lista de TechLeaders
        //        List<TechLeader> listaTechLeaders = listaUsuarios
        //            .Where(usuario => usuario.Cargo == Cargo.TechLeader)
        //            .Select(usuario => (TechLeader)usuario)
        //            .ToList();

        //        return (listaUsuarios, listaDesenvolvedores, listaTechLeaders);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Ocorreu um erro na inicialização dos usuários: " + ex.Message);
        //        return (null, null, null);
        //    }
        //}

        private (List<Usuario>, List<Desenvolvedor>, List<TechLeader>) InicializarUsuarios()
        {
            try
            {
                string json = File.ReadAllText(arquivoJson);
                Usuario[] arrayUsuarios0 = JsonConvert.DeserializeObject<Usuario[]>(json);
                List<Usuario> ListaUsuarios = arrayUsuarios0.ToList();

                Desenvolvedor[] arrayUsuarios = JsonConvert.DeserializeObject<Desenvolvedor[]>(json);
                List<Desenvolvedor> ListaDesenvolvedores = arrayUsuarios.Where(usuario => usuario.Cargo == Cargo.Desenvolvedor).ToList();

                TechLeader[] arrayUsuarios2 = JsonConvert.DeserializeObject<TechLeader[]>(json);
                List<TechLeader> ListaTechLeaders = arrayUsuarios2.Where(techleader => techleader.Cargo == Cargo.TechLeader).ToList();

                return (ListaUsuarios, ListaDesenvolvedores, ListaTechLeaders);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro na inicialização dos usuários: " + ex.Message);
                return (null, null, null);
            }
        }

        public void SalvarJsonUsuarios(List<Usuario> listaUsuarios)
        {

            try
            {
                if (File.Exists(arquivoJson)) // conferir se vai dar erro
                {
                    // Serializa a lista de professores de volta para o formato JSON
                    string json = JsonConvert.SerializeObject(listaUsuarios, Formatting.Indented);

                    // Escreve o JSON de volta no arquivo
                    File.WriteAllText(arquivoJson, json);

                    Console.WriteLine("Alterações salvas com sucesso no arquivo JSON.");
                }
                else
                {
                    Console.WriteLine("Não foi encontrado nenhum arquivo JSON para ser atualizado.");
                }
            }
            catch (Exception ex3)
            {
                Console.WriteLine("Ocorreu um erro ao tentar salvar as alterações no arquivo JSON: " + ex3.Message);
            }
        }

        public void AdicionarNovoFuncionario(Usuario novousuario)
        {
            listaUsuarios.Add(novousuario);

            SalvarJsonUsuarios(listaUsuarios);

            Console.WriteLine("Novo usuário adicionado com sucesso!");
        }
    }
}
