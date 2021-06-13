using MiniInvoiceAPI.Model.Authentication;
using MiniInvoiceAPI.Model.UserMgt;
using System.Collections.Generic;

namespace MiniInvoiceAPI.Interface.IUserMgt
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
