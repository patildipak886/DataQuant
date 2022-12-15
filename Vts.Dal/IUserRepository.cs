using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vts.Entites;

namespace Vts.Dal
{
    public interface IUserRepository
    {
        DataTable GetUsers();

        User GetUsers(int UserId);

        int InsertUser(User User);
        int UpdateUser(User User);
        int DeleteUser(int UserId);

    }
}
