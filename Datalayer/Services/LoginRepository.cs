using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Datalayer.Services.LoginRepository;

namespace Datalayer.Services
{
    public class LoginRepository : ILoginRepository
    {
        private MyFirstWebAppContext db;

        public LoginRepository(MyFirstWebAppContext context)
        {
            db = context;
        }
        public bool IsExistUser(string username, string password)
        {
            return db.AdminLogin.Any(u => u.UserName == username && u.Password == password);
        }
    }
}
