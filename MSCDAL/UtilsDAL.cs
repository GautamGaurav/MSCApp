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
    public class UtilsDAL
    {

        static readonly UtilsDAL _utilsDAL = new UtilsDAL();
        private UtilsDAL() { }
        public static UtilsDAL GetInstance { get { return _utilsDAL; } }

        public static List<TimeZones> GetAllTimeZone()
        {
            List<TimeZones> timeZoneList = new List<TimeZones>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetAllTimeZone", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TimeZones _timeZones = new TimeZones();
                        _timeZones.id = Convert.ToInt16(reader["Id"]);
                        _timeZones.wId = Convert.ToInt16(reader["WId"]);
                        _timeZones.name = Convert.ToString(reader["Name"]);
                        _timeZones.code = Convert.ToString(reader["Code"]);
                        _timeZones.countryName = Convert.ToString(reader["CountryName"]);
                        _timeZones.countryCode = Convert.ToString(reader["CountryCode"]);
                        _timeZones.utcOffset = Convert.ToString(reader["UTCOffset"]);
                        _timeZones.status = 200;
                        _timeZones.message = "TimeZones Found.";
                        _timeZones.isError = false;
                        timeZoneList.Add(_timeZones);
                    }
                }
                con.Close();
            }
            return timeZoneList;
        }

        public static List<LanguageCulture> GetAllLanguageCulture()
        {
            List<LanguageCulture> languageCultureList = new List<LanguageCulture>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetAllLanguageCulture", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LanguageCulture _languageCulture = new LanguageCulture();
                        _languageCulture.id = Convert.ToInt16(reader["Id"]);
                        _languageCulture.cultureCode = Convert.ToString(reader["CultureCode"]);
                        _languageCulture.cultureName = Convert.ToString(reader["CultureName"]);
                        _languageCulture.iso639xValue = Convert.ToString(reader["ISO639xValue"]);
                        _languageCulture.displayName = Convert.ToString(reader["DisplayName"]);
                        _languageCulture.status = 200;
                        _languageCulture.message = "Language Culture Found.";
                        _languageCulture.isError = false;
                        languageCultureList.Add(_languageCulture);
                    }
                }
                con.Close();
            }
            return languageCultureList;
        }

        public static AppData GetAppData()
        {
            AppData _appData = new AppData();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetAppData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _appData.batchCount = Convert.ToInt16(reader["BatchCount"]);
                        _appData.courseCount = Convert.ToInt16(reader["CourseCount"]);
                        _appData.sessionCount = Convert.ToInt16(reader["SessionCount"]);
                        _appData.studentCount = Convert.ToInt16(reader["StudentCount"]);
                        _appData.tutorCount = Convert.ToInt16(reader["TutorCount"]);
                        _appData.status = 200;
                        _appData.message = "App Data Found.";
                        _appData.isError = false;
                    }
                }
                else
                {
                    _appData.status = 500;
                    _appData.message = "No App Data Found.";
                    _appData.isError = true;
                }
                con.Close();
            }
            return _appData;
        }
    }
}
