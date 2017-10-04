using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MSCCommon;
using MSCBL;

namespace MSCApp.api
{
    /// <summary>
    /// Summary description for StudentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class StudentService : System.Web.Services.WebService
    {
        public StudentService()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public Student Get(int id)
        {
            return MSCBL.StudentBL.Get(id); ;
        }

        [WebMethod]
        public List<Student> GetAll()
        {
            List<Student> studentList = new List<Student>();
            studentList = MSCBL.StudentBL.GetAll();
            return studentList;
        }

        [WebMethod]
        public List<StudentSession> getStudentSession(int id)
        {
            List<StudentSession> studentSessions = new List<StudentSession>();
            studentSessions = MSCBL.StudentBL.GetStudentSession();
            return studentSessions;
        }

        [WebMethod]
        public List<StudentSession> GetUpcomingSessionByStudentId(int id)
        {
            List<StudentSession> studentSessions = new List<StudentSession>();
            studentSessions = MSCBL.StudentBL.GetUpcomingSessionByStudentId(id);
            return studentSessions;
        }


        [WebMethod]
        public List<StudentSession> GetLiveSessionByStudentId(int id)
        {
            List<StudentSession> studentSessions = new List<StudentSession>();
            studentSessions = MSCBL.StudentBL.GetLiveSessionByStudentId(id);
            return studentSessions;
        }

        [WebMethod]
        public List<StudentSession> GetRecordedSessionByStudentId(int id)
        {
            List<StudentSession> studentSessions = new List<StudentSession>();
            studentSessions = MSCBL.StudentBL.GetRecordedSessionByStudentId(id);
            return studentSessions;
        }

        [WebMethod]
        public Response Create(Student student)
        {
            return MSCBL.StudentBL.Create(student);
        }

        [WebMethod]
        public Response Update(Student student)
        {
            return MSCBL.StudentBL.Update(student);
        }

        [WebMethod]
        public bool DeleteStudent()
        {
            bool isDeleted = false;


            return isDeleted;
        }

    }

}
