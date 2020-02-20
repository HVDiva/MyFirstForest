using Forest.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Data.DAO
{
    public class UserDAO : IUserDAO
    {
        private ForestContext _context;
        public UserDAO()
        {
            _context = new ForestContext();
        }
        public IList<User> GetUsers()
        {
            return _context.User.ToList();
        }
        public void AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();

        }
    }
}
