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
    public class TeacherDAL
    {

        static readonly TeacherDAL _teacherDAL = new TeacherDAL();
        private TeacherDAL() { }
        public static TeacherDAL GetInstance { get { return _teacherDAL; } }

        public static Teacher Get(int id)
        {
            Teacher _teacher = new Teacher();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetTeacherById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _teacher.id = Convert.ToInt32(reader["Id"]);
                        _teacher.name = Convert.ToString(reader["Name"]);
                        _teacher.email = Convert.ToString(reader["Email"]);
                        _teacher.phoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        _teacher.mobileNumber = Convert.ToString(reader["MobileNumber"]);
                        _teacher.address = Convert.ToString(reader["Address"]);
                        _teacher.timeZone = Convert.ToString(reader["TimeZone"]);
                        _teacher.aboutTheTeacher = Convert.ToString(reader["AboutTheTeacher"]);
                        _teacher.isActive = Convert.ToBoolean(reader["IsActive"]);
                        _teacher.status = 200;
                        _teacher.message = _teacher.name + " (" + _teacher.email + ")" + " teacher found.";
                        _teacher.isError = false;
                    }
                }
                else
                {
                    _teacher.status = 400;
                    _teacher.message = "No Teahcer Found.";
                    _teacher.isError = true;
                }
                con.Close();
            }
            return _teacher;
        }
        public static Teacher GetByWid(int wId)
        {
            Teacher _teacher = new Teacher();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetTeacherByWId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@WId", wId));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _teacher.id = Convert.ToInt32(reader["Id"]);
                        _teacher.name = Convert.ToString(reader["Name"]);
                        _teacher.email = Convert.ToString(reader["Email"]);
                        _teacher.phoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        _teacher.mobileNumber = Convert.ToString(reader["MobileNumber"]);
                        _teacher.address = Convert.ToString(reader["Address"]);
                        _teacher.timeZone = Convert.ToString(reader["TimeZone"]);
                        _teacher.aboutTheTeacher = Convert.ToString(reader["AboutTheTeacher"]);
                        _teacher.isActive = Convert.ToBoolean(reader["IsActive"]);
                        _teacher.status = 200;
                        _teacher.message = _teacher.name + " (" + _teacher.email + ")" + " teacher found.";
                        _teacher.isError = false;
                    }
                }
                else
                {
                    _teacher.status = 400;
                    _teacher.message = "No Teahcer Found.";
                    _teacher.isError = true;
                }
                con.Close();
            }
            return _teacher;
        }
        public static List<Teacher> GetAll()
        {
            List<Teacher> teacherList = new List<Teacher>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetAllTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Teacher _teacher = new Teacher();
                        _teacher.id = Convert.ToInt32(reader["Id"]);
                        _teacher.wId = Convert.ToInt32(reader["WId"]);
                        _teacher.name = Convert.ToString(reader["Name"]);
                        _teacher.email = Convert.ToString(reader["Email"]);
                        _teacher.phoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        _teacher.mobileNumber = Convert.ToString(reader["MobileNumber"]);
                        _teacher.address = Convert.ToString(reader["Address"]);
                        _teacher.timeZone = Convert.ToString(reader["TimeZone"]);
                        _teacher.isActive = Convert.ToBoolean(reader["IsActive"]);
                        _teacher.status = 200;
                        _teacher.message = "Teacher Found.";
                        _teacher.isError = false;
                        teacherList.Add(_teacher);
                    }
                }
                con.Close();
            }
            return teacherList;
        }
        public static List<TeacherSession> GetTeacherSession()
        {
            List<TeacherSession> TeacherSession = new List<TeacherSession>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetTeacherSession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TeacherSession _teacherSession = new TeacherSession();
                        _teacherSession.teacherId = Convert.ToInt32(reader["Id"]);
                        _teacherSession.teacherName = Convert.ToString(reader["Name"]);
                        _teacherSession.teacherEmail = Convert.ToString(reader["Email"]);
                        _teacherSession.teacherPhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        //_teacher.status = 200;
                        //_teacher.message = "Teacher Found.";
                        //_teacher.isError = false;
                        TeacherSession.Add(_teacherSession);
                    }
                }
                con.Close();
            }
            return TeacherSession;
        }
        public static List<TeacherSession> GetUpcomingSessionByTeacherId(int id)
        {
            List<TeacherSession> TeacherSession = new List<TeacherSession>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetUpcomingSessionByTeacherId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TeacherId", id));
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TeacherSession _teacherSession = new TeacherSession();
                        _teacherSession.teacherId = Convert.ToInt32(reader["Id"]);
                        _teacherSession.teacherName = Convert.ToString(reader["Name"]);
                        _teacherSession.teacherEmail = Convert.ToString(reader["Email"]);
                        _teacherSession.teacherPhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        _teacherSession.teacherMobileNumber = Convert.ToString(reader["MobileNumber"]);
                        _teacherSession.tutorLink = Convert.ToString(reader["TutorLink"]);
                        _teacherSession.duration = Convert.ToString(reader["Duration"]);
                        _teacherSession.recordingLink = Convert.ToString(reader["RecordingLink"]);
                        _teacherSession.title = Convert.ToString(reader["Title"]);
                        _teacherSession.startTime = Convert.ToString(reader["StartTime"]);
                        _teacherSession.languageCultureName = Convert.ToString(reader["LanguageCultureName"]);
                        _teacherSession.timeZone = Convert.ToString(reader["TimeZone"]);
                        _teacherSession.status = 200;
                        _teacherSession.message = "Session Teacher Found.";
                        _teacherSession.isError = false;
                        TeacherSession.Add(_teacherSession);
                    }
                }
                con.Close();
            }
            return TeacherSession;
        }
        public static List<TeacherSession> GetLiveSessionByTeacherId(int id)
        {
            List<TeacherSession> TeacherSession = new List<TeacherSession>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetLiveSessionByTeacherId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TeacherId", id));
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TeacherSession _teacherSession = new TeacherSession();
                        _teacherSession.teacherId = Convert.ToInt32(reader["Id"]);
                        _teacherSession.teacherName = Convert.ToString(reader["Name"]);
                        _teacherSession.teacherEmail = Convert.ToString(reader["Email"]);
                        _teacherSession.teacherPhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        _teacherSession.teacherMobileNumber = Convert.ToString(reader["MobileNumber"]);
                        _teacherSession.tutorLink = Convert.ToString(reader["TutorLink"]);
                        _teacherSession.duration = Convert.ToString(reader["Duration"]);
                        _teacherSession.recordingLink = Convert.ToString(reader["RecordingLink"]);
                        _teacherSession.title = Convert.ToString(reader["Title"]);
                        _teacherSession.startTime = Convert.ToString(reader["StartTime"]);
                        _teacherSession.languageCultureName = Convert.ToString(reader["LanguageCultureName"]);
                        _teacherSession.timeZone = Convert.ToString(reader["TimeZone"]);
                        _teacherSession.status = 200;
                        _teacherSession.message = "Session Teacher Found.";
                        _teacherSession.isError = false;
                        TeacherSession.Add(_teacherSession);
                    }
                }
                con.Close();
            }
            return TeacherSession;
        }
        public static List<TeacherSession> GetRecordedSessionByTeacherId(int id)
        {
            List<TeacherSession> TeacherSession = new List<TeacherSession>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetRecordedSessionByTeacherId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TeacherId", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TeacherSession _teacherSession = new TeacherSession();
                        _teacherSession.teacherId = Convert.ToInt32(reader["Id"]);
                        _teacherSession.teacherName = Convert.ToString(reader["Name"]);
                        _teacherSession.teacherEmail = Convert.ToString(reader["Email"]);
                        _teacherSession.teacherPhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        _teacherSession.teacherMobileNumber = Convert.ToString(reader["MobileNumber"]);
                        _teacherSession.tutorLink = Convert.ToString(reader["TutorLink"]);
                        _teacherSession.duration = Convert.ToString(reader["Duration"]);
                        _teacherSession.recordingLink = Convert.ToString(reader["RecordingLink"]);
                        _teacherSession.title = Convert.ToString(reader["Title"]);
                        _teacherSession.startTime = Convert.ToString(reader["StartTime"]);
                        _teacherSession.languageCultureName = Convert.ToString(reader["LanguageCultureName"]);
                        _teacherSession.timeZone = Convert.ToString(reader["TimeZone"]);
                        _teacherSession.status = 200;
                        _teacherSession.message = "Session Teacher Found.";
                        _teacherSession.isError = false;
                        TeacherSession.Add(_teacherSession);
                    }
                }
                con.Close();
            }
            return TeacherSession;
        }
        public static Response Create(Teacher teacher)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreateTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@WId", teacher.wId));
                cmd.Parameters.Add(new SqlParameter("@Name", teacher.name));
                cmd.Parameters.Add(new SqlParameter("@Email", teacher.email));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", teacher.phoneNumber));
                cmd.Parameters.Add(new SqlParameter("@MobileNumber", teacher.mobileNumber));
                cmd.Parameters.Add(new SqlParameter("@TimeZone", teacher.timeZone));
                cmd.Parameters.Add(new SqlParameter("@IsActive", teacher.isActive));
                cmd.Parameters.Add(new SqlParameter("@CanScheduleClass", teacher.canScheduleClass));                
                cmd.Parameters.Add(new SqlParameter("@AboutTheTeacher", MSCServices.Utils.CheckForBlank(teacher.aboutTheTeacher)));
                cmd.Parameters.Add(new SqlParameter("@Address", MSCServices.Utils.CheckForBlank(teacher.address)));
                cmd.Parameters.Add(new SqlParameter("@PhotoPath", MSCServices.Utils.CheckForBlank(teacher.photoPath)));
                cmd.Parameters.Add(new SqlParameter("@Password", MSCServices.AuthBase.EncryptText(teacher.password)));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _response.status = 200;
                        _response.message = "Teacher Created Successfully";
                        _response.isError = false;
                    }
                }
                con.Close();
            }
            return _response;
        }
        public static Response Update(Teacher teacher)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UpdateTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@WId", teacher.wId));
                cmd.Parameters.Add(new SqlParameter("@Id", teacher.id));
                cmd.Parameters.Add(new SqlParameter("@Name", teacher.name));
                cmd.Parameters.Add(new SqlParameter("@Email", teacher.email));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", teacher.phoneNumber));
                cmd.Parameters.Add(new SqlParameter("@MobileNumber", teacher.mobileNumber));
                cmd.Parameters.Add(new SqlParameter("@TimeZone", teacher.timeZone));
                cmd.Parameters.Add(new SqlParameter("@IsActive", teacher.isActive));
                cmd.Parameters.Add(new SqlParameter("@CanScheduleClass", teacher.canScheduleClass));
                cmd.Parameters.Add(new SqlParameter("@AboutTheTeacher", MSCServices.Utils.CheckForBlank(teacher.aboutTheTeacher)));
                cmd.Parameters.Add(new SqlParameter("@Address", MSCServices.Utils.CheckForBlank(teacher.address)));
                cmd.Parameters.Add(new SqlParameter("@PhotoPath", MSCServices.Utils.CheckForBlank(teacher.photoPath)));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                _response.status = 200;
                _response.message = "Teacher Updated successfully.";
                _response.isError = false;
                con.Close();
            }
            return _response;
        }
        public static Response Delete(int id)
        {
            Response response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        response.status = 200;
                        response.message = "Teacher Deleted successfully";
                        response.isError = false;
                    }
                }
                con.Close();
            }
            return response;
        }
        public static Response SyncTeachers(Teacher teacher)
        {
            Response _response = new Response();
            try
            {
                string cs = ConnectionDAL.GetConnectionString();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SyncTeacher", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@WId", teacher.wId));
                    cmd.Parameters.Add(new SqlParameter("@Name", teacher.name));
                    cmd.Parameters.Add(new SqlParameter("@Email", teacher.email));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNumber", teacher.phoneNumber));
                    cmd.Parameters.Add(new SqlParameter("@MobileNumber", teacher.mobileNumber));
                    cmd.Parameters.Add(new SqlParameter("@AboutTheTeacher", teacher.aboutTheTeacher));
                    cmd.Parameters.Add(new SqlParameter("@Address", MSCServices.Utils.CheckForBlank(teacher.address)));
                    cmd.Parameters.Add(new SqlParameter("@PhotoPath", MSCServices.Utils.CheckForBlank(teacher.photoPath)));
                    cmd.Parameters.Add(new SqlParameter("@TimeZone", teacher.timeZone));
                    cmd.Parameters.Add(new SqlParameter("@Password", MSCServices.AuthBase.EncryptText("teacher@123")));
                    cmd.Parameters.Add(new SqlParameter("@IsActive", teacher.isActive));
                    con.Open();
                    cmd.ExecuteReader();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                _response = Response.ParseException(ex);
            }
            return _response;

        }
    }
}