using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Domain.UserAggregate;

namespace GerenciadorDeTarefas.Usuarios
{
    public class LerUsuario
    {
        private string arquivoJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Usuarios", "ListaDeUsuarios.json");
        private List<User> listaUsuarios;

        public LerUsuario()
        {
            arquivoJson = arquivoJson.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "GerenciadorDeTarefas");
            listaUsuarios = InicializarUsuarios();
        }

        public List<User> UsersList()
        {
            return listaUsuarios;
        }

        private List<User> InicializarUsuarios()
        {
            try
            {
                string json = File.ReadAllText(arquivoJson);
                User[] arrayUsuarios = JsonConvert.DeserializeObject<User[]>(json);
                List<User> ListaUsuarios = arrayUsuarios.ToList();

                return (ListaUsuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro na inicialização dos usuários: " + ex.Message);
                return (null);
            }
        }

        public void SalvarJsonUsuarios(List<User> listaUsuarios)
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

    }
}
