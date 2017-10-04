using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using MSCCommon;


/// <summary>
/// Summary description for Teacher
/// </summary>
namespace MSCServices
{
    public partial class WizIQClass
    {
        public static string AddTeacher(Teacher teacher)
        {
            NameValueCollection requestParameters = new NameValueCollection();
            string signature = WiZiQHelper.GetSignature("add_teacher");
            requestParameters.Add("name", teacher.name);
            requestParameters.Add("email", teacher.email);
            requestParameters.Add("password", teacher.password);
            requestParameters.Add("phone_number", teacher.phoneNumber);
            requestParameters.Add("mobile_number", teacher.mobileNumber);
            requestParameters.Add("time_zone", teacher.timeZone);
            requestParameters.Add("about_the_teacher", teacher.aboutTheTeacher);
            requestParameters.Add("can_schedule_class", Convert.ToInt32(teacher.canScheduleClass).ToString());
            requestParameters.Add("is_active", Convert.ToInt32(teacher.isActive).ToString());
            string postFilePath = teacher.photoPath == null ? "" : teacher.photoPath;
            return WiZiQHelper.MakeRequest("add_teacher", requestParameters, postFilePath);
        }
        public static string EditTeacher(Teacher teacher)
        {
            NameValueCollection requestParameters = new NameValueCollection();
            requestParameters.Add("teacher_id", teacher.wId.ToString());
            requestParameters.Add("name", teacher.name);
            requestParameters.Add("email", teacher.email);
            requestParameters.Add("password", teacher.password);
            requestParameters.Add("phone_number", teacher.phoneNumber);
            requestParameters.Add("mobile_number", teacher.mobileNumber);
            requestParameters.Add("time_zone", teacher.timeZone);
            requestParameters.Add("about_the_teacher", teacher.aboutTheTeacher);
            requestParameters.Add("can_schedule_class", Convert.ToInt32(teacher.canScheduleClass).ToString());
            requestParameters.Add("is_active", Convert.ToInt32(teacher.isActive).ToString());
            string postFilePath = teacher.photoPath == null ? "" : teacher.photoPath;
            return WiZiQHelper.MakeRequest("edit_teacher", requestParameters, postFilePath);
        }
        public static string GetTeacherDetailById(int teacherId)
        {
            var requestParameters = new Dictionary<string, string>();
            requestParameters["teacher_id"] = teacherId.ToString();
            return WiZiQHelper.MakeRequest("get_teacher_details", requestParameters);
        }
        public static string GetAllTeachers()
        {
            var requestParameters = new Dictionary<string, string>();
            return WiZiQHelper.MakeRequest("get_teacher_details", requestParameters);
        }
    }
}