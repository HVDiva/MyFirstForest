using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest.Data;

namespace Forest.Services.IService
{
    public interface IUserService
    {
        IList<User> GetUsers();
        void AddUser(User user);
    }
}
