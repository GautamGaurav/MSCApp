using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Subject
/// </summary>
namespace MSCCommon
{
    public class Subject : Response
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool isDelete { get; set; }
        public DateTime createdDate { get; set; }

        public Subject() { }

        public Subject(int _id, string _name, string _description, bool _isDelete, DateTime _createdDate)
        {
            id = _id;
            name = _name;
            description = _description;
            isDelete = _isDelete;
            createdDate = _createdDate;
        }
    }
}