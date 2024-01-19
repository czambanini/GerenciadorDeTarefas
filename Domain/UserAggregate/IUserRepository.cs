namespace Domain.UserAggregate
{
    public interface IUserRepository<T> where T : User
    {
        User FindByLogin(string userLogin);

        User Login(string userLogin, string password);

        void Add(User user);

        void Update(User user);

        List<User> GetAll();

    }
}
