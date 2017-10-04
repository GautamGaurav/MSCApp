using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Batch
/// </summary>
namespace MSCCommon
{
    public class Batch : Response
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public long gradeId { get; set; }
        public string gradeName { get; set; }        
        public bool isDelete { get; set; }
        public DateTime createdDate { get; set; }

        public Batch() { }

        public Batch(int _id, string _name, string _description, int _gradeId, string _gradeName, bool _isDelete, DateTime _createdDate)
        {
            id = _id;
            name = _name;
            description = _description;
            gradeId = _gradeId;
            gradeName = _gradeName;
            isDelete = _isDelete;
            createdDate = _createdDate;
        }
    }
}