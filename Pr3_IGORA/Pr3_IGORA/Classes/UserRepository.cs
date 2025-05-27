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
           
                var userCredentialsList = ConnectBase.entObj.Employee
                    .Select(e => new UserCredentials
                    {
                        Login = e.Login,
                        Password = e.Password,
                        IDPost = e.IDPost
                    })
                    .ToList();

                return userCredentialsList;
            
        }
    }
}
