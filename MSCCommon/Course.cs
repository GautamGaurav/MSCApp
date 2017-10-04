using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Course
/// </summary>
/// 
namespace MSCCommon
{
    public class Course : Response
    {

        public int id { get; set; }
        public string name { get; set; }
        public string targetExam { get; set; }
        public string subjectIds { get; set; }
        public string targetYear { get; set; }
        public bool isDelete { get; set; }
        public DateTime createdDate { get; set; }

        public Course() { }

        public Course(int _id, string _name, string _targetExam, string _subjectIds, string _targetYear, bool _isDelete, DateTime _createdDate)
        {
            id = _id;
            name = _name;
            targetExam = _targetExam;
            subjectIds = _subjectIds;
            targetYear = _targetYear;
            isDelete = _isDelete;
            createdDate = _createdDate;
        }
    }
}
