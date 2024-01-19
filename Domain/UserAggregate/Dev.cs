namespace Domain.UserAggregate
{
    internal class Dev : User
    {
        public Dev(string login, string nome, string senha, Cargo cargo) : base(login, nome, senha, cargo)
        {
        }

    }
}
