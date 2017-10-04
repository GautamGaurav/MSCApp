using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSCDAL;
using MSCCommon;

/// <summary>
/// Summary description for Batch
/// </summary>
namespace MSCBL
{
    public class BatchBL 
    {
        public static Batch Get(int id)
        {
            return MSCDAL.BatchDAL.Get(id);
        }
        public static List<Batch> GetAll()
        {
            return MSCDAL.BatchDAL.GetAll();
        }
        public static Response Create(Batch batch)
        {
            return MSCDAL.BatchDAL.Create(batch);
        }
        public static Response Update(Batch batch)
        {
            return MSCDAL.BatchDAL.Update(batch);
        }
        public static Response Delete(int id)
        {
            return MSCDAL.BatchDAL.Delete(id);
        }
        public static void SyncBatchs(Batch batch)
        {
            MSCDAL.BatchDAL.SyncBatchs(batch);
        }
    }
}
