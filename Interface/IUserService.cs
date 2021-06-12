using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAppAPI.Model;

namespace MyAppAPI.Interface
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
