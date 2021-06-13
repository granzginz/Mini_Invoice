using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniInvoiceAPI.Model.Authentication;
using MiniInvoiceAPI.Model.UserMgt;

namespace MiniInvoiceAPI.Interface
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
