using System;
using System.Collections.Generic;
using System.Text;

namespace JWDB.DataLayer
{
    public interface IUserInfo
    {
        String Domain { get; set; }

        String Name { get; set; }

        String[] Roles { get; set; }
    }
}
