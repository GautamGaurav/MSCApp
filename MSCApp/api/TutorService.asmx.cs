using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Xml;
using MSCCommon;

namespace MSCApp.api
{
    /// <summary>
    /// Summary description for TutorService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class TutorService : System.Web.Services.WebService
    {

        public TutorService() { }

        [WebMethod]
        public Teacher GetByWId(int wId)
        {
            Teacher _teacher = new Teacher();
            string returnXml = MSCServices.WizIQClass.GetTeacherDetailById(wId);
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(returnXml);
            XmlNode root = xDoc.SelectSingleNode("rsp");
            string status = root.Attributes["status"].Value;
            long teacherId = status == "ok" ? Teacher.ParseTeacherWId(root) : 0;
            _teacher = teacherId > 0 ? Teacher.ParseTeacher(root) : MSCBL.TeacherBL.GetByWid(wId);
            return _teacher;
        }

        [WebMethod]
        public Teacher Get(int id)
        {
            return MSCBL.TeacherBL.Get(id);
        }

        [WebMethod]
        public List<Teacher> GetAll()
        {
            return MSCBL.TeacherBL.GetAll();
        }

        [WebMethod]
        public List<TeacherSession> getTeacherSession(int id)
        {
            List<TeacherSession> TeacherSessions = new List<TeacherSession>();
            TeacherSessions = MSCBL.TeacherBL.GetTeacherSession();
            return TeacherSessions;
        }

        [WebMethod]
        public List<TeacherSession> GetUpcomingSessionByTeacherId(int id)
        {
            List<TeacherSession> TeacherSessions = new List<TeacherSession>();
            TeacherSessions = MSCBL.TeacherBL.GetUpcomingSessionByTeacherId(id);
            return TeacherSessions;
        }


        [WebMethod]
        public List<TeacherSession> GetLiveSessionByTeacherId(int id)
        {
            List<TeacherSession> TeacherSessions = new List<TeacherSession>();
            TeacherSessions = MSCBL.TeacherBL.GetLiveSessionByTeacherId(id);
            return TeacherSessions;
        }

        [WebMethod]
        public List<TeacherSession> GetRecordedSessionByTeacherId(int id)
        {
            List<TeacherSession> TeacherSessions = new List<TeacherSession>();
            TeacherSessions = MSCBL.TeacherBL.GetRecordedSessionByTeacherId(id);
            return TeacherSessions;
        }

        [WebMethod]
        public Response Create(Teacher teacher)
        {
            Response _response = new Response();
            try
            {
                string returnXml = MSCServices.WizIQClass.AddTeacher(teacher);
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(returnXml);
                XmlNode root = xDoc.SelectSingleNode("rsp");
                string status = root.Attributes["status"].Value;
                teacher.wId = status == "ok" ? Teacher.ParseTeacherWId(root) : 0;
                _response = teacher.wId > 0 ? MSCBL.TeacherBL.Create(teacher) : Response.ParseErrorResponse(root);
            }
            catch (Exception ex)
            {
                _response = Response.ParseException(ex);
            }
            return _response;
        }

        [WebMethod]
        public Response Update(Teacher teacher)
        {
            Response _response = new Response();
            try
            {
                string returnXml = MSCServices.WizIQClass.EditTeacher(teacher);
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(returnXml);
                XmlNode root = xDoc.SelectSingleNode("rsp");
                string status = root.Attributes["status"].Value;
                _response = status == "ok" ? MSCBL.TeacherBL.Update(teacher) : Response.ParseErrorResponse(root);
            }
            catch (Exception ex)
            {
                _response = Response.ParseException(ex);
            }
            return _response;
        }

        [WebMethod]
        public Response Delete(int id)
        {
            return MSCBL.TeacherBL.Delete(id);
        }

        [WebMethod]
        public List<Teacher> SyncTeachers()
        {
            string returnXml = MSCServices.WizIQClass.GetAllTeachers();
            List<Teacher> teacherList = Teacher.ParseTeacherList(returnXml);
            foreach (Teacher _teacher in teacherList)
            {
                Response response = MSCBL.TeacherBL.SyncTeachers(_teacher);
            }
            return teacherList;
        }

    }

}
