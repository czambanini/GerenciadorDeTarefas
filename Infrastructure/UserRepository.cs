using Domain.UserAggregate;
using GerenciadorDeTarefas.Usuarios;

namespace AdaTech.AdaShop.Infra.Data.Repository
{
    public class UserRepository<T> : Domain.UserAggregate.IUserRepository<T> where T : User

    {
        LerUsuario lerUsuario = new LerUsuario();
        private List<User> usersList;

        public UserRepository()
        {
            LerUsuario lerUsuario = new LerUsuario();
            usersList = lerUsuario.UsersList();
        }

        public User FindByLogin(string userLogin)
        {

            foreach (User user in usersList)
            {
                if (user.Login == userLogin)
                {
                    return user;
                }
            }

            return null;
        }

        public User Login(string userLogin, string password)
        {
            while (true)
            {
                Console.WriteLine("Insira nome de login:");
                string nomeLogin = Console.ReadLine()!;
                Console.WriteLine("Senha:");
                string senha = Console.ReadLine()!;

                foreach (User user in usersList)
                {
                    if (user.Login == nomeLogin && user.Password == senha)
                    {
                        return user;
                    }
                }

                Console.WriteLine("Usuário não identificado. Login ou senha incorretos.");
            }
        }

        public void Add(User user)
        {
            usersList.Add(user);
            lerUsuario.SalvarJsonUsuarios(usersList);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return usersList;
        }

    }
}
