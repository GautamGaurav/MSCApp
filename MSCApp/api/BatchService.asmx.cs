using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MSCCommon;
using MSCBL;

namespace MSCApp.api
{
    /// <summary>
    /// Summary description for BatchService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class BatchService : System.Web.Services.WebService
    {

        public BatchService()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public Batch Get(int id)
        {
            return MSCBL.BatchBL.Get(id);
        }

        [WebMethod]
        public List<Batch> GetAll()
        {
            return MSCBL.BatchBL.GetAll();
        }

        [WebMethod]
        public Response Create(Batch batch)
        {
            return MSCBL.BatchBL.Create(batch);
        }

        [WebMethod]
        public Response Update(Batch batch)
        {
            return MSCBL.BatchBL.Update(batch);
        }

        [WebMethod]
        public Response Delete(int id)
        {
            return MSCBL.BatchBL.Delete(id);
        }

    }

}
