using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSCCommon;
using MSCDAL;

/// <summary>
/// Summary description for Subject
/// </summary>
namespace MSCBL
{
    public class SubjectBL
    {

        public static Subject Get(int id)
        {
            return MSCDAL.SubjectDAL.Get(id);
        }
        public static List<Subject> GetAll()
        {
            return MSCDAL.SubjectDAL.GetAll();
        }
        public static Response Create(Subject Subject)
        {
            return MSCDAL.SubjectDAL.Create(Subject);
        }
        public static Response Update(Subject Subject)
        {
            return MSCDAL.SubjectDAL.Update(Subject);
        }
        public static Response Delete(int id)
        {
            return MSCDAL.SubjectDAL.Delete(id);
        }
        public static void SyncSubjects(Subject Subject)
        {
            MSCDAL.SubjectDAL.SyncSubjects(Subject);
        }
    }
}