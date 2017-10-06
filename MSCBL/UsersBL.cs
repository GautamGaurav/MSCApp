using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSCCommon;
using MSCDAL;
/// <summary>
/// Summary description for User
/// </summary>
namespace MSCBL
{
    public class UsersBL
    {
        public static Users Login(string userName, string password)
        {

            return UserDAL.Login(userName, password);
        }

        public static Response ChangePassword(string oldPassword, string newPassword, int userId, string userEmail)
        {
            return UserDAL.ChangePassword(oldPassword, newPassword, userId, userEmail);
        }

        public static bool Logout(int id)
        {
            return UserDAL.Logout(id);
        }
    }
}