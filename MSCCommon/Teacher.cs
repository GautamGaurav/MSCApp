using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Teacher
/// </summary>
namespace MSCCommon
{
    public class Teacher : Response
    {

        public long id { get; set; }
        public long wId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public string mobileNumber { get; set; }
        public string timeZone { get; set; }
        public string photoPath { get; set; }
        public string aboutTheTeacher { get; set; }
        public bool canScheduleClass { get; set; }
        public bool isActive { get; set; }


        public Teacher() { }

        public Teacher(long _id, long _wId, string _name, string _email, string _password, string _phoneNumber, string _mobileNumber, string _timeZone, string _photoPath, string _aboutTheTeacher, bool _canScheduleClass, bool _isActive)
        {
            id = _id;
            wId = _wId;
            name = _name;
            email = _email;
            password = _password;
            phoneNumber = _phoneNumber;
            mobileNumber = _mobileNumber;
            timeZone = _timeZone;
            photoPath = _photoPath;
            aboutTheTeacher = _aboutTheTeacher;
            canScheduleClass = _canScheduleClass;
            isActive = _isActive;
        }

        public static long ParseTeacherWId(XmlNode root)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<root>" + root.InnerXml + "</root>");
            long teacherId = 0;
            XmlNodeList ErrorIdTags = xmlDoc.GetElementsByTagName("teacher_id");
            teacherId = ErrorIdTags.Count <= 1 ? Convert.ToInt64(ErrorIdTags[0].InnerText) : 0;
            return teacherId;
        }

        public static Teacher ParseTeacher(XmlNode root)
        {
            Teacher _teacher = new Teacher();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<root>" + root.InnerXml + "</root>");
            _teacher.wId = Convert.ToInt64(xmlDoc.GetElementsByTagName("teacher_id")[0].InnerText);
            _teacher.name = xmlDoc.GetElementsByTagName("name")[0].InnerText;
            _teacher.email = xmlDoc.GetElementsByTagName("email")[0].InnerText;
            _teacher.password = xmlDoc.GetElementsByTagName("password")[0].InnerText;
            _teacher.phoneNumber = xmlDoc.GetElementsByTagName("phone_number")[0].InnerText;
            _teacher.mobileNumber = xmlDoc.GetElementsByTagName("mobile_number")[0].InnerText;
            _teacher.aboutTheTeacher = xmlDoc.GetElementsByTagName("about_the_teacher")[0].InnerText;
            _teacher.timeZone = xmlDoc.GetElementsByTagName("time_zone")[0].InnerText;
            _teacher.canScheduleClass = Convert.ToBoolean(Convert.ToInt16(xmlDoc.GetElementsByTagName("can_schedule_class")[0].InnerText));
            _teacher.isActive = Convert.ToBoolean(Convert.ToInt16(xmlDoc.GetElementsByTagName("is_active")[0].InnerText));
            _teacher.status = 200;
            _teacher.message = _teacher.name + " (" + _teacher.email + ")" + " teacher found.";
            _teacher.isError = false;
            return _teacher;
        }

        public static List<Teacher> ParseTeacherList(string root)
        {
            List<Teacher> teacherList = new List<Teacher>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(root);
            XmlNodeList nodes = xmlDoc.GetElementsByTagName("teacher_details");
            foreach (XmlNode node in nodes)
            {
                Teacher _teacher = new Teacher();
                _teacher.wId = Convert.ToInt64(node.ChildNodes[0].InnerText);
                _teacher.name = node.ChildNodes[1].InnerText;
                _teacher.email = node.ChildNodes[2].InnerText;
                _teacher.password = node.ChildNodes[3].InnerText;
                _teacher.phoneNumber = node.ChildNodes[4].InnerText;
                _teacher.mobileNumber = node.ChildNodes[5].InnerText;
                _teacher.aboutTheTeacher = node.ChildNodes[6].InnerText;
                _teacher.photoPath = node.ChildNodes[7].InnerText;
                _teacher.timeZone = node.ChildNodes[8].InnerText;
                _teacher.canScheduleClass = Convert.ToBoolean(Convert.ToInt16(node.ChildNodes[9].InnerText));
                _teacher.isActive = Convert.ToBoolean(Convert.ToInt16(node.ChildNodes[10].InnerText));
                teacherList.Add(_teacher);
            }
            return teacherList;
        }
    }
}