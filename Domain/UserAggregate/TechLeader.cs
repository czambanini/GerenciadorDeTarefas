using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserAggregate
{
    internal class TechLeader : User
    {
        public TechLeader(string login, string nome, string senha, Cargo cargo) : base(login, nome, senha, cargo)
        {
        }

    }
}
