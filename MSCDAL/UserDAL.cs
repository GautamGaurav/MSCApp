using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSCCommon;
using System.Data;
using System.Data.SqlClient;


namespace MSCDAL
{
    public class UserDAL
    {

        static readonly UserDAL _userDAL = new UserDAL();

        private UserDAL() { }

        public static UserDAL GetInstance { get { return _userDAL; } }

        public static Users Login(string userName, string password)//Ver
        {
            Users _user = new Users();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("LoginUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Email", userName));
                cmd.Parameters.Add(new SqlParameter("@Password", password));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _user.id = Convert.ToInt32(reader["Id"]);
                        _user.name = Convert.ToString(reader["Name"]);
                        _user.email = Convert.ToString(reader["Email"]);
                        _user.password = Convert.ToString(reader["Password"]);
                        _user.phoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        _user.timeZone = Convert.ToString(reader["TimeZone"]);
                        _user.userRole = Convert.ToInt32(reader["UserRole"]);
                        _user.userType = Convert.ToInt32(reader["UserType"]);
                        _user.isActive = Convert.ToBoolean(reader["IsActive"]);
                        _user.userId = Convert.ToInt32(reader["UserId"]);
                        _user.status = 200;
                        _user.message = "Login successfully";
                        _user.isError = false;
                    }
                }
                else
                {
                    _user.status = 204;
                    _user.message = "User Not Found - ( Invalid Credentials Supplied )";
                    _user.isError = true;
                }
                con.Close();
            }
            return _user;
        }

        public static bool Logout(int id)
        {
            bool isLogout = true;
            return isLogout;
        }

        public Users GetUserById(int id)//Ver
        {
            Users _user = new Users();
            return _user;


        }
    }


}
