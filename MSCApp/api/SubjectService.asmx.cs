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
    /// Summary description for SubjectService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class SubjectService : System.Web.Services.WebService
    {

        public SubjectService()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public Subject Get(int id)
        {            
            return MSCBL.SubjectBL.Get(id);
        }

        [WebMethod]
        public List<Subject> GetAll()
        {
            return MSCBL.SubjectBL.GetAll();
        }

        [WebMethod]
        public Response Create(Subject subject)
        {
            return MSCBL.SubjectBL.Create(subject);
        }

        [WebMethod]
        public Response Update(Subject subject)
        {
            return MSCBL.SubjectBL.Update(subject);
        }

        [WebMethod]
        public Response Delete(int id)
        {
            return MSCBL.SubjectBL.Delete(id);
        }

    }

}
