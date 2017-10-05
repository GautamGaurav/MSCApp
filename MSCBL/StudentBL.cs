using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSCCommon;
using MSCDAL;

/// <summary>
/// Summary description for Student
/// </summary>
namespace MSCBL
{
    public class StudentBL
    {
        public static Student Get(int id)
        {
            return MSCDAL.StudentDAL.Get(id);
        }
        public static List<Student> GetAll()
        {
            return MSCDAL.StudentDAL.GetAll();
        }
        public static List<StudentSession> GetStudentSession()
        {
            return MSCDAL.StudentDAL.GetStudentSession();
        }
        public static List<StudentSession> GetUpcomingSessionByStudentId(int id)
        {
            return MSCDAL.StudentDAL.GetUpcomingSessionByStudentId(id);
        }
        public static List<StudentSession> GetLiveSessionByStudentId(int id)
        {
            return MSCDAL.StudentDAL.GetLiveSessionByStudentId(id);
        }
        public static List<StudentSession> GetRecordedSessionByStudentId(int id)
        {
            return MSCDAL.StudentDAL.GetRecordedSessionByStudentId(id);
        }
        public static Response CreateStudentSession(StudentSession studentSession)
        {
            return MSCDAL.StudentDAL.CreateStudentSession(studentSession);
        }
        public static List<Student> GetStudentByBatchId(long batchId)
        {
            return MSCDAL.StudentDAL.GetStudentByBatchId(batchId);
        }
        public static Response Create(Student Student)
        {
            return MSCDAL.StudentDAL.Create(Student);
        }
        public static Response Update(Student Student)
        {
            return MSCDAL.StudentDAL.Update(Student);
        }
        public static Response Delete(int id)
        {
            return MSCDAL.StudentDAL.Delete(id);
        }
        public static void SyncStudents(Student Student)
        {
            MSCDAL.StudentDAL.SyncStudents(Student);
        }
        public static List<Student> GetStudentByBatchId(int batchId)
        {
            return MSCDAL.StudentDAL.GetStudentByBatchId(batchId);
        }
    }
}