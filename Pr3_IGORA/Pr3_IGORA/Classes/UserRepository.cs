using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr3_IGORA.Classes
{
    public static class UserRepository
    {
        public static List<UserCredentials> GetAllUserCredentials()
        {
            using (var db = ConnectBase.entObj)
            {
                var userCredentialsList = db.Employee
                    .Select(e => new UserCredentials
                    {
                        Login = e.Login,
                        Password = e.Password
                    })
                    .ToList();

                return userCredentialsList;
            }
        }
    }
}
