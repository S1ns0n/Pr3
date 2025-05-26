using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr3_IGORA.Database;

namespace Pr3_IGORA.Classes
{
    internal class ConnectBase
    {
        public static igoraEntities entObj;

        static ConnectBase()
        {
            entObj = new igoraEntities();
        }
    }
}
