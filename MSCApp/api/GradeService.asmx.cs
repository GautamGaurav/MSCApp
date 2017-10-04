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
    /// Summary description for GradeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class GradeService : System.Web.Services.WebService
    {
        public GradeService()
        {
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public Grade Get(int id)
        {
            return MSCBL.GradeBL.Get(id);
        }

        [WebMethod]
        public List<Grade> GetAll()
        {
            return MSCBL.GradeBL.GetAll();
        }

        [WebMethod]
        public Response Create(Grade grade)
        {
            return MSCBL.GradeBL.Create(grade);
        }

        [WebMethod]
        public Response Update(Grade grade)
        {
            return MSCBL.GradeBL.Update(grade);
        }

        [WebMethod]
        public bool Delete(int id)
        {
            return false; // MSCBL.GradeBL.Delete(id);
        }

    }

}
