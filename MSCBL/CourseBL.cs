using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSCCommon;
using MSCDAL;

/// <summary>
/// Summary description for Course
/// </summary>
namespace MSCBL
{
    public class CourseBL 
    {
        public static Course Get(long id)
        {
            return MSCDAL.CourseDAL.Get(id);
        }
        public static List<Course> GetAll()
        {
            return MSCDAL.CourseDAL.GetAll();
        }
        public static Response Create(Course Course)
        {
            return MSCDAL.CourseDAL.Create(Course);
        }
        public static Response Update(Course Course)
        {
            return MSCDAL.CourseDAL.Update(Course);
        }
        public static Response Delete(int id)
        {
            return MSCDAL.CourseDAL.Delete(id);
        }
    }
}