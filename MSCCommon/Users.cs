using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
/// 
namespace MSCCommon
{
    public class Users : Response
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public string timeZone { get; set; }
        public int userRole { get; set; }
        public int userType { get; set; }
        public int userId { get; set; }
        public bool isActive { get; set; }

        public Users() { }

        public Users(int _id, string _name, string _email, string _password, string _phoneNumber, string _timeZone, int _userRole, int _userType, int _userId, bool _isActive)
        {
            id = _id;
            name = _name;
            email = _email;
            password = _password;
            phoneNumber = _phoneNumber;
            timeZone = _timeZone;
            userRole = userRole;
            userType = _userType;
            userId = _userId;
            isActive = _isActive;
        }
    }
}