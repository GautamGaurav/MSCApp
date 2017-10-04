using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSCCommon;
using MSCDAL;

/// <summary>
/// Summary description for Session
/// </summary>
namespace MSCBL
{
    public class SessionBL 
    {
        public static Session Get(long id)
        {
            return MSCDAL.SessionDAL.Get(id);
        }
        public static List<Session> GetAll()
        {
            return MSCDAL.SessionDAL.GetAll();
        }
        public static Response Create(Session session)
        {
            return MSCDAL.SessionDAL.Create(session);
        }
        public static Response Update(Session session)
        {
            return MSCDAL.SessionDAL.Update(session);
        }
        public static Response Delete(int id)
        {
            return MSCDAL.SessionDAL.Delete(id);
        }
        public static Response Cancel(Session session)
        {
            return MSCDAL.SessionDAL.Cancel(session);
        }
        public static void SyncClasses(Session session)
        {
            MSCDAL.SessionDAL.SyncClasses(session);
        }
    }
}