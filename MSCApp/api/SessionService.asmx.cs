using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Text;
using System.Xml.Serialization;
using MSCCommon;
using MSCBL;

namespace MSCApp.api
{
    /// <summary>
    /// Summary description for SessionService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class SessionService : System.Web.Services.WebService
    {
        public SessionService()
        {
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public Session Get(long wId)
        {
            return MSCBL.SessionBL.Get(wId);
        }

        public Session GetFormWizIQ(long wId)
        {
            MSCCommon.Session _session = new MSCCommon.Session();
            string returnXml = MSCServices.WizIQClass.GetSessionDetailsById(wId);
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(returnXml);
            XmlNode root = xDoc.SelectSingleNode("rsp");
            string status = root.Attributes["status"].Value;
            long SessionId = status == "ok" ? MSCCommon.Session.ParseSessionWId(root) : 0;
            _session = SessionId > 0 ? MSCCommon.Session.ParseSession(root) : MSCBL.SessionBL.Get(wId);
            return _session;
        }

        [WebMethod]
        public List<Session> GetAll()
        {
            return MSCBL.SessionBL.GetAll();
        }

        [WebMethod]
        public Response Create(Session session)
        {
            Response _response = new Response();
            try
            {
                string returnXml = MSCServices.WizIQClass.AddSession(session);
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(returnXml);
                XmlNode root = xDoc.SelectSingleNode("rsp");
                string status = root.Attributes["status"].Value;
                long sessionId = status == "ok" ? MSCCommon.Session.ParseSessionWId(root) : 0;
                if (sessionId > 0)
                {
                    MSCCommon.Session _session = MSCCommon.Session.ParseSession(root);
                    session.wId = _session.wId;
                    session.recordingLink = _session.recordingLink;
                    session.tutorLink = _session.tutorLink;
                    _response = MSCBL.SessionBL.Create(session);
                    AddAttendees(_session.wId, session.batchId, session.languageCultureName);
                    MSCCommon.Mail.SendMail("amit49499@gmail.com", session.tutorEmail, "New Class Scheduled", "<hr><br>" + session.title + " @ " + session.startTime + "Has been scheduled.<br><br> Here is your link to join the class : " + _session.tutorLink + "<hr>");

                }
                else
                {
                    _response = Response.ParseErrorResponse(root);
                }
            }
            catch (Exception ex)
            {
                _response = Response.ParseException(ex);
            }
            return _response;
        }

        [WebMethod]
        public Response Update(Session session)
        {
            Response _response = new Response(200, "Class Updated Successfully", false);
            try
            {
                string returnXml = MSCServices.WizIQClass.UpdateSession(session);
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(returnXml);
                XmlNode root = xDoc.SelectSingleNode("rsp");
                string status = root.Attributes["status"].Value;
                _response = status == "ok" ? MSCBL.SessionBL.Update(session) : MSCCommon.Session.ParseErrorResponse(root);
            }
            catch (Exception ex)
            {
                _response = Response.ParseException(ex);
            }
            return _response;

        }

        [WebMethod]
        public Response Delete(Session session)
        {
            Response _response = new Response(200, "Class Deleted Successfully.", false);
            string returnXml = MSCServices.WizIQClass.DeleteSession(session);
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(returnXml);
            XmlNode root = xDoc.SelectSingleNode("rsp");
            string status = root.Attributes["status"].Value;
            _response = status == "ok" ? MSCBL.SessionBL.Delete(1) : _response;
            return _response;

        }

        [WebMethod]
        public Response Cancel(Session session)
        {
            Response _response = new Response(200, "Class Canceled Successfully.", false);
            string returnXml = MSCServices.WizIQClass.CancelSession(session);
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(returnXml);
            XmlNode root = xDoc.SelectSingleNode("rsp");
            string status = root.Attributes["status"].Value;
            _response = status == "ok" ? MSCBL.SessionBL.Cancel(session) : MSCCommon.Session.ParseErrorResponse(root);
            return _response;
        }

        [WebMethod]
        public void AddAttendees(long sessionWId, long batchId, string languageCultureName)
        {
            List<Student> _studentList = MSCBL.StudentBL.GetStudentByBatchId(batchId);
            StringBuilder attendeesXml = new StringBuilder();
            foreach (Student student in _studentList)
            {
                string attendeeXML = CreateAttendeeXML(student.id, student.name, languageCultureName);
                attendeesXml.Append(attendeeXML);
            }
            string attendeeListXml = "<attendee_list>" + attendeesXml.ToString() + "</attendee_list>";
            string returnXml = MSCServices.WizIQClass.AddAttendees(sessionWId, attendeeListXml.ToString());
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(returnXml);
            XmlNode root = xDoc.SelectSingleNode("rsp");
            string status = root.Attributes["status"].Value;
            List<StudentSession> _studentSessionList = status == "ok" ? MSCCommon.StudentSession.ParseStudentSessionXML(returnXml) : new List<StudentSession>();
            if (_studentSessionList.Count > 0)
            {
                foreach (StudentSession studentSession in _studentSessionList)
                {
                    MSCBL.StudentBL.CreateStudentSession(studentSession);
                }
            }
        }

        public static string CreateAttendeeXML(long studentId, string studentName, string languageCultureName)
        {
            StringBuilder attendeeXml = new StringBuilder();
            attendeeXml.Append("<attendee>");
            string studentFirstName = studentName.Split(null)[0] == "" ? "STUDENT" : studentName.Split(null)[0];
            attendeeXml.Append("<attendee_id><![CDATA[" + studentId + "]]></attendee_id>");
            attendeeXml.Append("<screen_name><![CDATA[" + studentFirstName + "_" + studentId + "_Attendee]]></screen_name>");
            attendeeXml.Append("<language_culture_name><![CDATA[" + languageCultureName + "]]></language_culture_name>");
            attendeeXml.Append("</attendee>");
            return attendeeXml.ToString();
        }

        public void DownloadRecording(long wId)
        {
            string returnXml = MSCServices.WizIQClass.DownloadRecording(wId);
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(returnXml);
            XmlNode root = xDoc.SelectSingleNode("rsp");
            string stat = root.Attributes["status"].Value;
            if (stat == "ok")
            {
                //Once you call method, it creates recording package. <message> node in response xml will shows related messages. 
                //< status_xml_path> will contain http xml path which will have all the information of recording package.
                //process xml
            }
            else
            {

            }
        }

        public void GetClassData()
        {
            string returnXml = "";// MSCServices.WizIQClass.GetData();
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(returnXml);
            XmlNode root = xDoc.SelectSingleNode("rsp");
            string stat = root.Attributes["status"].Value;
            if (stat == "ok")
            {
                //process xml
            }
            else
            {

            }
        }

        [WebMethod]
        public List<Session> SyncClasses()
        {
            string returnXml = MSCServices.WizIQClass.GetAllSessions();
            List<Session> sessionList = MSCCommon.Session.ParseSessionList(returnXml);
            foreach (Session _session in sessionList)
            {
                MSCBL.SessionBL.SyncClasses(_session);
            }
            return sessionList;
        }
    }
}
