using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSCCommon;
using MSCDAL;


namespace MSCBL
{
    public class UtilsBL
    {
        public static List<TimeZones> GetAllTimeZone()
        {
            return UtilsDAL.GetAllTimeZone();
        }

        public static List<LanguageCulture> GetAllLanguageCulture()
        {
            return UtilsDAL.GetAllLanguageCulture();
        }

        public static AppData GetAppData()
        {
            return UtilsDAL.GetAppData();
        }
    }
}
