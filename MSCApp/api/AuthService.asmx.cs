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
    }
}
