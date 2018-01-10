using JWDB.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWDB.DataLayer.Contracts
{
    public interface IUsersRepository
    {
        IEnumerable<TaUser> GetUsers(Int32 pageNo, Int32 pageSize);
        TaUser GetUSer(Int32 id);
        void AddUser(TaUser user);
        void UpdateUser(TaUser user);
        void RemoveUser(Int32 id);
    }
}
