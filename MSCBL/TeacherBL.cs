using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSCCommon;
using MSCDAL;
/// <summary>
/// Summary description for Teacher
/// </summary>
namespace MSCBL
{
    public class TeacherBL
    {
        public static Teacher GetByWid(int id)
        {
            return MSCDAL.TeacherDAL.GetByWid(id);
        }
        public static Teacher Get(int id)
        {
            return MSCDAL.TeacherDAL.Get(id);
        }
        public static List<Teacher> GetAll()
        {
            return MSCDAL.TeacherDAL.GetAll();
        }

        public static List<TeacherSession> GetTeacherSession()
        {
            return MSCDAL.TeacherDAL.GetTeacherSession();
        }
        public static List<TeacherSession> GetUpcomingSessionByTeacherId(int id)
        {
            return MSCDAL.TeacherDAL.GetUpcomingSessionByTeacherId(id);
        }
        public static List<TeacherSession> GetLiveSessionByTeacherId(int id)
        {
            return MSCDAL.TeacherDAL.GetLiveSessionByTeacherId(id);
        }
        public static List<TeacherSession> GetRecordedSessionByTeacherId(int id)
        {
            return MSCDAL.TeacherDAL.GetRecordedSessionByTeacherId(id);
        }
        public static Response Create(Teacher teacher)
        {
            return MSCDAL.TeacherDAL.Create(teacher);
        }
        public static Response Update(Teacher teacher)
        {
            return MSCDAL.TeacherDAL.Update(teacher);
        }
        public static Response Delete(int id)
        {
            return MSCDAL.TeacherDAL.Delete(id);
        }
        public static Response SyncTeachers(Teacher teacher)
        {
            return MSCDAL.TeacherDAL.SyncTeachers(teacher);
        }
    }
}