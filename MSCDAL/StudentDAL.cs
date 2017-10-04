using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSCCommon;
using MSCServices;
using System.Data;
using System.Data.SqlClient;


namespace MSCDAL
{
    public class StudentDAL
    {
        static readonly StudentDAL _studentDAL = new StudentDAL();
        private StudentDAL() { }
        public static StudentDAL GetInstance { get { return _studentDAL; } }
        public static Student Get(int id)
        {
            Student _student = new Student();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetStudentById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _student.id = Convert.ToInt32(reader["Id"]);
                        _student.name = Convert.ToString(reader["Name"]);
                        _student.email = Convert.ToString(reader["Email"]);
                        _student.phoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        _student.address = Convert.ToString(reader["Address"]);
                        _student.timeZone = Convert.ToString(reader["TimeZone"]);
                        _student.batchName = Convert.ToString(reader["BatchName"]);
                        _student.batchId = Convert.ToInt32(reader["BatchId"]);
                        _student.gradeName = Convert.ToString(reader["GradeName"]);
                        _student.gradeId = Convert.ToInt32(reader["GradeId"]);
                        _student.courseName = Convert.ToString(reader["CourseName"]);
                        _student.courseId = Convert.ToInt32(reader["CourseId"]);
                        _student.status = 200;
                        _student.message = _student.name + " (" + _student.email + ")" + " Student found.";
                        _student.isError = false;
                    }
                }
                else
                {
                    _student.status = 400;
                    _student.message = "No Teahcer Found.";
                    _student.isError = true;
                }
                con.Close();
            }
            return _student;
        }
        public static List<Student> GetAll()
        {
            List<Student> StudentList = new List<Student>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetAllStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student _student = new Student();
                        _student.id = Convert.ToInt32(reader["Id"]);
                        _student.name = Convert.ToString(reader["Name"]);
                        _student.email = Convert.ToString(reader["Email"]);
                        _student.phoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        _student.address = Convert.ToString(reader["Address"]);
                        _student.timeZone = Convert.ToString(reader["TimeZone"]);
                        _student.batchId = Convert.ToInt16(reader["BatchId"]);
                        _student.batchName = Convert.ToString(reader["BatchName"]);
                        _student.courseId = Convert.ToInt16(reader["CourseId"]);
                        _student.courseName = Convert.ToString(reader["CourseName"]);
                        _student.gradeId = Convert.ToInt16(reader["GradeId"]);
                        _student.gradeName = Convert.ToString(reader["GradeName"]);
                        _student.status = 200;
                        _student.message = "Student Found.";
                        _student.isError = false;
                        StudentList.Add(_student);
                    }
                }
                con.Close();
            }
            return StudentList;
        }
        public static List<StudentSession> GetStudentSession()
        {
            List<StudentSession> studentSession = new List<StudentSession>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetStudentSession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StudentSession _studentSession = new StudentSession();
                        _studentSession.studentId = Convert.ToInt32(reader["Id"]);
                        _studentSession.studnetName = Convert.ToString(reader["Name"]);
                        _studentSession.studentEmail = Convert.ToString(reader["Email"]);
                        _studentSession.studentPhoneNumber = Convert.ToString(reader["PhoneNumber"]);

                        //_student.status = 200;
                        //_student.message = "Student Found.";
                        //_student.isError = false;
                        studentSession.Add(_studentSession);
                    }
                }
                con.Close();
            }
            return studentSession;
        }
        public static List<StudentSession> GetUpcomingSessionByStudentId(int id)
        {
            List<StudentSession> studentSession = new List<StudentSession>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetUpcomingSessionByStudentId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@StudentId", id));
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StudentSession _studentSession = new StudentSession();
                        _studentSession.studentId = Convert.ToInt32(reader["StudentId"]);
                        _studentSession.studnetName = Convert.ToString(reader["StudentName"]);
                        _studentSession.studentEmail = Convert.ToString(reader["StudentEmail"]);
                        _studentSession.studentPhoneNumber = Convert.ToString(reader["StudentPhoneNumber"]);
                        _studentSession.attendeeLink = Convert.ToString(reader["AttendeesLink"]);
                        _studentSession.duration = Convert.ToString(reader["Duration"]);
                        _studentSession.recordingLink = Convert.ToString(reader["RecordingLink"]);
                        _studentSession.title = Convert.ToString(reader["Title"]);
                        _studentSession.startTime = Convert.ToString(reader["StartTime"]);
                        _studentSession.languageCultureName = Convert.ToString(reader["LanguageCultureName"]);
                        _studentSession.timeZone = Convert.ToString(reader["TimeZone"]);
                        _studentSession.status = 200;
                        _studentSession.message = "Session Student Found.";
                        _studentSession.isError = false;
                        studentSession.Add(_studentSession);
                    }
                }
                con.Close();
            }
            return studentSession;
        }
        public static List<StudentSession> GetLiveSessionByStudentId(int id)
        {
            List<StudentSession> studentSession = new List<StudentSession>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetLiveSessionByStudentId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@StudentId", id));
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StudentSession _studentSession = new StudentSession();
                        _studentSession.studentId = Convert.ToInt32(reader["StudentId"]);
                        _studentSession.studnetName = Convert.ToString(reader["StudentName"]);
                        _studentSession.studentEmail = Convert.ToString(reader["StudentEmail"]);
                        _studentSession.studentPhoneNumber = Convert.ToString(reader["StudentPhoneNumber"]);
                        _studentSession.attendeeLink = Convert.ToString(reader["AttendeesLink"]);
                        _studentSession.duration = Convert.ToString(reader["Duration"]);
                        _studentSession.recordingLink = Convert.ToString(reader["RecordingLink"]);
                        _studentSession.title = Convert.ToString(reader["Title"]);
                        _studentSession.startTime = Convert.ToString(reader["StartTime"]);
                        _studentSession.languageCultureName = Convert.ToString(reader["LanguageCultureName"]);
                        _studentSession.timeZone = Convert.ToString(reader["TimeZone"]);
                        _studentSession.status = 200;
                        _studentSession.message = "Session Student Found.";
                        _studentSession.isError = false;
                        studentSession.Add(_studentSession);
                    }
                }
                con.Close();
            }
            return studentSession;
        }
        public static List<StudentSession> GetRecordedSessionByStudentId(int id)
        {
            List<StudentSession> studentSession = new List<StudentSession>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetRecordedSessionByStudentId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@StudentId", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StudentSession _studentSession = new StudentSession();
                        _studentSession.studentId = Convert.ToInt32(reader["StudentId"]);
                        _studentSession.studnetName = Convert.ToString(reader["StudentName"]);
                        _studentSession.studentEmail = Convert.ToString(reader["StudentEmail"]);
                        _studentSession.studentPhoneNumber = Convert.ToString(reader["StudentPhoneNumber"]);
                        _studentSession.attendeeLink = Convert.ToString(reader["AttendeesLink"]);
                        _studentSession.duration = Convert.ToString(reader["Duration"]);
                        _studentSession.recordingLink = Convert.ToString(reader["RecordingLink"]);
                        _studentSession.title = Convert.ToString(reader["Title"]);
                        _studentSession.startTime = Convert.ToString(reader["StartTime"]);
                        _studentSession.languageCultureName = Convert.ToString(reader["LanguageCultureName"]);
                        _studentSession.timeZone = Convert.ToString(reader["TimeZone"]);
                        _studentSession.status = 200;
                        _studentSession.message = "Session Student Found.";
                        _studentSession.isError = false;
                        studentSession.Add(_studentSession);
                    }
                }
                con.Close();
            }
            return studentSession;
        }
        public static Response CreateStudentSession(StudentSession studentSession)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreateStudentSession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@SessionWId", studentSession.wId));
                cmd.Parameters.Add(new SqlParameter("@SessionWMasterId", studentSession.wMasterId));
                cmd.Parameters.Add(new SqlParameter("@StudentId", studentSession.studentId));
                cmd.Parameters.Add(new SqlParameter("@AttendeesLink", studentSession.attendeeLink));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
                _response.status = 200;
                _response.message = "Student Session Created Successfully";
                _response.isError = false;
            }
            return _response;
        }
        public static List<Student> GetStudentByBatchId(long batchId)
        {
            List<Student> _studentList = new List<Student>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetStudentByBatchId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@BatchId", batchId));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student _student = new Student();
                        _student.id = Convert.ToInt32(reader["Id"]);
                        _student.name = Convert.ToString(reader["Name"]);
                        _student.email = Convert.ToString(reader["Email"]);
                        _studentList.Add(_student);
                    }
                }
                con.Close();
            }
            return _studentList;
        }
        public static Response Create(Student student)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", student.name));
                cmd.Parameters.Add(new SqlParameter("@Email", student.email));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", student.phoneNumber));
                cmd.Parameters.Add(new SqlParameter("@BatchId", student.batchId));
                cmd.Parameters.Add(new SqlParameter("@CourseId", student.courseId));
                cmd.Parameters.Add(new SqlParameter("@TimeZone", student.timeZone));
                cmd.Parameters.Add(new SqlParameter("@Address", MSCServices.Utils.CheckForBlank(student.address)));
                cmd.Parameters.Add(new SqlParameter("@PhotoPath", MSCServices.Utils.CheckForBlank(student.photoPath)));
                cmd.Parameters.Add(new SqlParameter("@Password", MSCServices.AuthBase.EncryptText(student.password)));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
                _response.status = 200;
                _response.message = "Student Created Successfully";
                _response.isError = false;
            }
            return _response;
        }
        public static Response Update(Student student)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.Parameters.Add(new SqlParameter("@StudentId", student.id));
                cmd.Parameters.Add(new SqlParameter("@Name", student.name));
                cmd.Parameters.Add(new SqlParameter("@Email", student.email));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", student.phoneNumber));
                cmd.Parameters.Add(new SqlParameter("@BatchId", student.batchId));
                cmd.Parameters.Add(new SqlParameter("@CourseId", student.courseId));
                cmd.Parameters.Add(new SqlParameter("@TimeZone", student.timeZone));
                cmd.Parameters.Add(new SqlParameter("@Address", MSCServices.Utils.CheckForBlank(student.address)));
                cmd.Parameters.Add(new SqlParameter("@PhotoPath", MSCServices.Utils.CheckForBlank(student.photoPath)));
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                _response.status = 200;
                _response.message = "Student Updated Successfully.";
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
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        response.status = 200;
                        response.message = "Login successfully";
                        response.isError = false;
                    }
                }
                con.Close();
            }
            return response;
        }
        public static void SyncStudents(Student Student)
        {
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SyncStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", Student.name));
                cmd.Parameters.Add(new SqlParameter("@Email", Student.email));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", Student.phoneNumber));
                cmd.Parameters.Add(new SqlParameter("@Address", ""));
                cmd.Parameters.Add(new SqlParameter("@PhotoPath", ""));
                cmd.Parameters.Add(new SqlParameter("@TimeZone", Student.timeZone));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
            }
        }
    }
}
