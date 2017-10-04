using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Student
/// </summary>
namespace MSCCommon
{
    public class Student : Response
    {
        public long id { get; set; }
        public int batchId { get; set; }
        public string batchName { get; set; }
        public int gradeId { get; set; }
        public string gradeName { get; set; }
        public int courseId { get; set; }
        public string courseName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string password { get; set; }
        public string photoPath { get; set; }
        public string timeZone { get; set; }
        public int userType { get; set; }
        public int userId { get; set; }
        public bool isDelete { get; set; }
        public DateTime createdDate { get; set; }

        public Student() { }

        public Student(long _id, int _batchId, string _batchName, int _gradeId, string _gradeName, int _courseId, string _courseName, string _name, string _email, string _phoneNumber, string _address, string _password, string _photoPath, string _timeZone, int _userType, int _userId, bool _isDelete, int _status, DateTime _createdDate)
        {
            id = _id;
            batchId = _batchId;
            batchName = _batchName;
            gradeId = _gradeId;
            gradeName = _gradeName;
            courseId = _courseId;
            courseName = _courseName;
            name = _name;
            email = _email;
            phoneNumber = _phoneNumber;
            address = _address;
            password = _password;
            photoPath = _photoPath;
            timeZone = _timeZone;
            userType = _userType;
            userId = _userId;
            isDelete = _isDelete;
            status = _status;
            createdDate = _createdDate;
        }
    }
}