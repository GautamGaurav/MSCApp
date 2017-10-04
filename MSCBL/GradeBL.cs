using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSCCommon;
using MSCDAL;


/// <summary>
/// Summary description for Grade
/// </summary>
namespace MSCBL
{
    public class GradeBL 
    {
        public static Grade Get(long id)
        {
            return MSCDAL.GradeDAL.Get(id);
        }
        public static List<Grade> GetAll()
        {
            return MSCDAL.GradeDAL.GetAll();
        }
        public static Response Create(Grade grade)
        {
            return MSCDAL.GradeDAL.Create(grade);
        }
        public static Response Update(Grade Grade)
        {
            return MSCDAL.GradeDAL.Update(Grade);
        }
        public static Response Delete(int id)
        {
            return MSCDAL.GradeDAL.Delete(id);
        }
    }
}