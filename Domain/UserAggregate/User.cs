using Domain.SeewWork;

namespace Domain.UserAggregate
{
    public class User : IAggregateRoot
    {
        public string Login { get; private set; }

        internal string _name;
        internal string? _email;
        public string Password { get; private set; }
        public Cargo Cargo { get; private set; }


        public User(string login, string name, string password, Cargo cargo) {
            Login = login;
            _name = name;
            Password = password;
            Cargo = cargo;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Login: {Login}");
            Console.WriteLine($"Nome: {_name}");
            Console.WriteLine($"Email: {_email} ");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine();
        }

    }
}
