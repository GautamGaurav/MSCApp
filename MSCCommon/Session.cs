using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;


/// <summary>
/// Summary description for Session
/// </summary>
namespace MSCCommon
{
    public class Session : Response
    {
        public long wId { get; set; }
        public long wMasterId { get; set; }
        public long id { get; set; }
        public long batchId { get; set; }
        public string batchName { get; set; }        
        public long tutorId { get; set; }
        public string tutorName { get; set; }
        public string tutorEmail { get; set; }
        public string title { get; set; }
        public string startTime { get; set; }
        public string duration { get; set; }        
        public string attendeeLink { get; set; }
        public string tutorLink { get; set; }
        public string recordingLink { get; set; }
        public bool isDelete { get; set; }
        public bool isCancelled { get; set; }
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
        public string coPresenterUrl { get; set; }

        //public long gradeId { get; set; }
        //public string gradeName { get; set; }
        //public long courseId { get; set; }
        //public string courseName { get; set; }
        //public long subjectId { get; set; }
        //public string subjectName { get; set; }
        //public string[] stundetIds { get; set; }
        //public string topic { get; set; }
        //public string photoPath { get; set; }


        public Session()
        {

        }

        public Session(int _id, long _wId,long _wMasterId, int _batchId, string _batchName, int _tutorId, string _tutorName, string _tutorEmail, DateTime _dateTime, string _startTime, string _duration,  string _attendeeLink, string _tutorLink, string _recordingLink, bool _isDelete, bool _isCancelled, DateTime _sessionDate, DateTime _createdDate, DateTime _deletedDate, string _coPresenterUrl)
             //int _gradeId, string _gradeName, int _courseId, string _courseName, int _subjectId, string _subjectName, string[] _stundetIds, string _topic, string _title, string _photoPath)
        {
            id = _id;
            wId = _wId;
            wMasterId = _wMasterId;
            batchId = _batchId;
            batchName = _batchName;           
            tutorId = _tutorId;
            tutorName = _tutorName;
            tutorEmail = _tutorEmail;
            startTime = _startTime;
            duration = _duration;            
            attendeeLink = _attendeeLink;
            tutorLink = _tutorLink;
            recordingLink = _recordingLink;
            isDelete = _isDelete;
            sessionDate = _sessionDate;
            createdDate = _createdDate;
            deletedDate = _deletedDate;
            coPresenterUrl = _coPresenterUrl;
            isCancelled = _isCancelled;

            //gradeId = _gradeId;
            //gradeName = _gradeName;
            //courseId = _courseId;
            //courseName = _courseName;
            //subjectId = _subjectId;
            //subjectName = subjectName;
            //stundetIds = _stundetIds;
            //topic = _topic;
            //title = _title;
            //photoPath = _photoPath;
        }
        public static long ParseSessionWId(XmlNode root)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<root>" + root.InnerXml + "</root>");
            long classId = 0;
            XmlNodeList wIdXmlNode = xmlDoc.GetElementsByTagName("class_id");
            classId = wIdXmlNode.Count <= 1 ? Convert.ToInt64(wIdXmlNode[0].InnerText) : 0;
            return classId;
        }
        public static Session ParseSession(XmlNode root)
        {
            MSCCommon.Session _session = new MSCCommon.Session();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<root>" + root.InnerXml + "</root>");
            _session.wId = Convert.ToInt64(xmlDoc.GetElementsByTagName("class_id")[0].InnerText);
            _session.recordingLink = xmlDoc.GetElementsByTagName("recording_url")[0].InnerText;
            _session.tutorLink = xmlDoc.GetElementsByTagName("presenter_url")[0].InnerText;
            _session.coPresenterUrl = xmlDoc.GetElementsByTagName("co_presenter_url")[0].InnerText;
            return _session;
        }

        public static List<Session> ParseSessionList(string root)
        {
            List<Session> sessionList = new List<Session>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(root);
            XmlNodeList nodes = xmlDoc.GetElementsByTagName("record");
            foreach (XmlNode node in nodes)
            {
                MSCCommon.Session _session = new Session();
                _session.wId = Convert.ToInt64(node.ChildNodes[0].InnerText);
                _session.title = node.ChildNodes[1].InnerText;
                _session.tutorLink = node.ChildNodes[3].InnerText;
                _session.recordingLink = node.ChildNodes[4].InnerText; 
                _session.tutorId = 10;              
                _session.presenterEmail = "gaurav.gautam17@gmail.com";
                _session.batchId = 1;
                _session.languageCultureName = "en-US";
                _session.duration = "20";
                _session.extendDuration = "20";
                _session.timeZone = "Asia/Kabul";
                _session.attendeeLimit = 25;
                _session.startTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                _session.presenterDefaultControls = "audio, video";
                _session.attendeeDefaultControls = "audio, writing";
                _session.createRecording = true;
                _session.returnUrl = "http://localhost:31313/login";
                _session.statusPingUrl = "http://localhost:31313/login";
                _session.attendeeLink = "http://localhost:31313/login";
                _session.coPresenterUrl = "http://localhost:31313/login";
                _session.isDelete = false;
                _session.isCancelled = false;
                _session.sessionDate = DateTime.Now;
                _session.createdDate = DateTime.Now;
                _session.deletedDate = DateTime.Now;
                sessionList.Add(_session);
            }
            return sessionList;
        }

    }
}