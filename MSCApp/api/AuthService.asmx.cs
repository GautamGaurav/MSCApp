using System;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using MSCCommon;
using MSCBL;
using MSCServices;

namespace MSCApp.api
{
    /// <summary>
    /// Summary description for AuthService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class AuthService : System.Web.Services.WebService
    {

        public AuthService()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public Users Login(string userName, string password)
        {
            Users _user = new Users();
            try
            {
                //string decryptedPassword = MSCServices.AuthBase.DecryptText(password);
                _user = UsersBL.Login(userName, MSCServices.AuthBase.EncryptText(password));
            }
            catch (Exception ex)
            {
                Response _response = Response.ParseException(ex);
                _user.isError = true;
                _user.status = 500;
                _user.message = _response.message;
            }
            return _user;
        }

        [WebMethod]
        public Response ChangePassword(string oldPassword, string newPassword, int userId, string userEmail)
        {
            Response _response = new Response();
            try
            {
                //string decryptedPassword = MSCServices.AuthBase.DecryptText(oldPassword);
                string encryptedOldPassword = MSCServices.AuthBase.EncryptText(oldPassword);
                string encryptedNewPassword = MSCServices.AuthBase.EncryptText(newPassword);
                _response = UsersBL.ChangePassword(encryptedOldPassword, encryptedNewPassword, userId, userEmail);
            }
            catch (Exception ex)
            {
                _response = Response.ParseException(ex);
            }
            return _response;
        }

        [WebMethod]
        public string DecryptText(string inputText)
        {
            return MSCServices.AuthBase.DecryptText(inputText);
        }

        [WebMethod]
        public string EncryptText(string inputText)
        {
            return MSCServices.AuthBase.EncryptText(inputText);
        }
    }
}
