using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest.Data;
using Forest.Data.DAO;
using Forest.Data.IDAO;
using Forest.Services.IService;

namespace Forest.Services.Service
{
    public class UserService : IUserService
    {
        private IUserDAO _dao;
        public UserService()
        {
            _dao = new UserDAO();
        }
        public IList<User> GetUsers()
        {
            return _dao.GetUsers();
        }
        public void AddUser(User user)
        {
            _dao.AddUser(user);
        }
    }
}
