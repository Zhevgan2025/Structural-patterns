using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyForTheIbook
{
    
   public class User
    {
        string Name { get;  }
        public bool IsRegistered { get;  }

        public bool HasBookAccess { get; }

        public User(string name, bool isRegistered, bool hasBookAcces)
        {
            Name = name;
            IsRegistered = isRegistered;
            HasBookAccess = hasBookAcces;
        }
    }


}
