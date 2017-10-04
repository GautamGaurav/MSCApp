using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Xml;
using MSCServices;
using System.Text;
using System.IO;
using MSCCommon;
using MSCBL;

namespace MSCApp.api
{
    /// <summary>
    /// Summary description for UtilService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class UtilService : System.Web.Services.WebService
    {

        public UtilService() { }

        [WebMethod]
        public List<TimeZones> GetAllTimeZone()
        {
            return MSCBL.UtilsBL.GetAllTimeZone();
        }

        [WebMethod]
        public List<LanguageCulture> GetAllLanguageCulture()
        {
            return MSCBL.UtilsBL.GetAllLanguageCulture();
        }

        [WebMethod]
        public AppData GetAppData()
        {
            return MSCBL.UtilsBL.GetAppData();
        }

    }
}
