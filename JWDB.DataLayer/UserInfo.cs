using System;
using System.Collections.Generic;
using System.Text;

namespace JWDB.DataLayer
{
    public class UserInfo : IUserInfo
    {
        public UserInfo()
        {
        }

        public String Domain { get; set; }

        public String Name { get; set; }

        public String[] Roles { get; set; }
    }
}
