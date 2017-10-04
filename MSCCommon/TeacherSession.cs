using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace MSCCommon
{
    public class TeacherSession : Response
    {
        public long teacherId { get; set; }
        public string teacherName { get; set; }
        public string teacherEmail { get; set; }
        public string teacherPhoneNumber { get; set; }
        public string teacherMobileNumber { get; set; }        
        public long wId { get; set; }
        public long wMasterId { get; set; }
        public long sessionId { get; set; }
        public long batchId { get; set; }
        public string batchName { get; set; }
        public long gradeId { get; set; }
        public string gradeName { get; set; }
        public long courseId { get; set; }
        public string courseName { get; set; }
        public long subjectId { get; set; }
        public string subjectName { get; set; }       
        public string title { get; set; }
        public string startTime { get; set; }
        public string duration { get; set; }
        public string attendeeLink { get; set; }
        public string tutorLink { get; set; }
        public string recordingLink { get; set; }
        public bool isDelete { get; set; }
        public DateTime sessionDate { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime deletedDate { get; set; }
        public string presenterEmail { get; set; }
        public string languageCultureName { get; set; }
        public string extendDuration { get; set; }
        public string timeZone { get; set; }
        public int attendeeLimit { get; set; }
        public string presenterDefaultControls { get; set; }
        public string attendeeDefaultControls { get; set; }
        public bool createRecording { get; set; }
        public string returnUrl { get; set; }
        public string statusPingUrl { get; set; }

        public TeacherSession()
        {

        }

        public TeacherSession(long _teacherId, string _teacherName, string _teacherEmail, string _teacherPhoneNumber, string _teacherMobileNumber, long _sessionId, long _wId, long _wMasterId, int _batchId, string _batchName, int _gradeId, string _gradeName, int _courseId, string _courseName, int _subjectId, string _subjectName, string _title, DateTime _dateTime, string _startTime, string _duration, string _attendeeLink, string _tutorLink, string _recordingLink, bool _isDelete, DateTime _sessionDate, DateTime _createdDate, DateTime _deletedDate)
        {
            teacherId = _teacherId;
            teacherName = _teacherName;
            teacherEmail = _teacherEmail;
            teacherPhoneNumber = _teacherPhoneNumber;
            teacherMobileNumber = _teacherMobileNumber;
            sessionId = _sessionId;
            wId = _wId;
            wMasterId = _wMasterId;
            batchId = _batchId;
            batchName = _batchName;
            gradeId = _gradeId;
            gradeName = _gradeName;
            courseId = _courseId;
            courseName = _courseName;
            subjectId = _subjectId;
            subjectName = subjectName;
            title = _title;
            startTime = _startTime;
            duration = _duration;
            attendeeLink = _attendeeLink;
            tutorLink = _tutorLink;
            recordingLink = _recordingLink;
            isDelete = _isDelete;
            sessionDate = _sessionDate;
            createdDate = _createdDate;
            deletedDate = _deletedDate;
        }

        public static List<TeacherSession> ParseTeacherSessionXML(string root)
        {
            List<TeacherSession> TeacherSessionList = new List<TeacherSession>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(root);
            XmlNodeList nodes = xmlDoc.GetElementsByTagName("attendee");

                foreach (XmlNode node in nodes)
            {
                TeacherSession _TeacherSession = new TeacherSession();
                _TeacherSession.wId = Convert.ToInt64(xmlDoc.GetElementsByTagName("class_id")[0].InnerText);
                _TeacherSession.wMasterId = Convert.ToInt64(xmlDoc.GetElementsByTagName("class_id")[0].InnerText);  //Convert.ToInt64(xmlDoc.GetElementsByTagName("class_id")[0].InnerText);
                _TeacherSession.teacherId = Convert.ToInt64(node.ChildNodes[0].InnerText);
                _TeacherSession.attendeeLink = node.ChildNodes[1].InnerText;
                TeacherSessionList.Add(_TeacherSession);
            }
            return TeacherSessionList;
        }

    }
}
