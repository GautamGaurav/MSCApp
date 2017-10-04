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
    /// Summary description for CourseService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class CourseService : System.Web.Services.WebService
    {
        public CourseService()
        {
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public Course Get(long id)
        {
            return MSCBL.CourseBL.Get(id);
        }

        [WebMethod]
        public List<Course> GetAll()
        {
            return MSCBL.CourseBL.GetAll();
        }

        [WebMethod]
        public Response Create(Course course)
        {
            return MSCBL.CourseBL.Create(course);
        }

        [WebMethod]
        public Response Update(Course course)
        {
            return MSCBL.CourseBL.Update(course);
        }

        [WebMethod]
        public bool Delete()
        {
            bool isDeleted = false;
            return isDeleted;
        }

    }

}
