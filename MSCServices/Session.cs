using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using MSCCommon;


/// <summary>
/// Summary description for Session
/// </summary>
namespace MSCServices
{
    public partial class WizIQClass
    {
        public static string AddSession(Session session)
        {
            var requestParameters = new Dictionary<string, string>();
            requestParameters.Add("title", session.title);
            requestParameters.Add("start_time", session.startTime.ToString());
            requestParameters.Add("presenter_email", session.presenterEmail);
            requestParameters.Add("language_culture_name", session.languageCultureName);
            requestParameters.Add("extend_duration", session.extendDuration);
            requestParameters.Add("duration", session.duration);
            requestParameters.Add("time_zone", session.timeZone);
            requestParameters.Add("attendee_limit", session.attendeeLimit.ToString());
            requestParameters.Add("presenter_default_controls", session.presenterDefaultControls);
            requestParameters.Add("attendee_default_controls", session.attendeeDefaultControls);
            requestParameters.Add("create_recording", session.createRecording.ToString());
            requestParameters.Add("return_url", session.returnUrl);
            requestParameters.Add("status_ping_url", session.statusPingUrl);
            return WiZiQHelper.MakeRequest("create", requestParameters);
        }
        public static string UpdateSession(Session session)
        {
            var requestParameters = new Dictionary<string, string>();
            requestParameters["class_id"] = session.wId.ToString();
            requestParameters.Add("title", session.title);
            requestParameters.Add("start_time", session.startTime.ToString());
            requestParameters.Add("presenter_email", session.presenterEmail);
            requestParameters.Add("language_culture_name", session.languageCultureName);
            requestParameters.Add("extend_duration", session.extendDuration);
            requestParameters.Add("duration", session.duration);
            requestParameters.Add("time_zone", session.timeZone);
            requestParameters.Add("attendee_limit", session.attendeeLimit.ToString());
            requestParameters.Add("presenter_default_controls", session.presenterDefaultControls);
            requestParameters.Add("attendee_default_controls", session.attendeeDefaultControls);
            requestParameters.Add("create_recording", session.createRecording.ToString());
            requestParameters.Add("return_url", session.returnUrl);
            requestParameters.Add("status_ping_url", session.statusPingUrl);
            return WiZiQHelper.MakeRequest("modify", requestParameters);
        }

        public static string CancelSession(Session session)
        {
            var requestParameters = new Dictionary<string, string>();
            requestParameters["class_id"] = session.wId.ToString();
            //Required for permanent class
            //requestParameters["class_master_id"] = session.wMasterId.ToString();
            //requestParameters["perma_class"] = "true";
            MSCServices.HttpRequest oRequest = new MSCServices.HttpRequest();
            return WiZiQHelper.MakeRequest("cancel", requestParameters);
        }

        public static string DeleteSession(Session session)
        {
            var requestParameters = new Dictionary<string, string>();
            requestParameters["class_id"] = session.wId.ToString();
            //Required for permanent class
            //requestParameters["class_master_id"] = session.wMasterId.ToString();
            //requestParameters["perma_class"] = "true";
            MSCServices.HttpRequest oRequest = new MSCServices.HttpRequest();
            return WiZiQHelper.MakeRequest("delete", requestParameters);
        }      

        public static string AddAttendees(long sessionId, string attendeeXml)
        {
            var requestParameters = new Dictionary<string, string>();
            //Required for Time-based class
            requestParameters["class_id"] = sessionId.ToString();
            //Required for permanent class
            //requestParameters["class_master_id"] = session.wMasterId.ToString();
            //requestParameters["perma_class"] = "true";
            requestParameters["attendee_list"] = attendeeXml;
            return WiZiQHelper.MakeRequest("add_attendees", requestParameters);
        }

        public static string DownloadRecording(long sessionId)
        {
            var requestParameters = new Dictionary<string, string>();
            requestParameters["class_id"] = sessionId.ToString();
            requestParameters["recording_format"] = "zip";
            return WiZiQHelper.MakeRequest("download_recording", requestParameters);
        }

        public static string GetSessionDetailsById(long sessionId)
        {
            var requestParameters = new Dictionary<string, string>();
            requestParameters["class_id"] = sessionId.ToString();
            return WiZiQHelper.MakeRequest("get_data", requestParameters);
        }

        public static string GetAllSessions()
        {
            var requestParameters = new Dictionary<string, string>();
            return WiZiQHelper.MakeRequest("get_data", requestParameters);
        }

        public static string GetSessionDetails(string sessionIds)
        {
            var requestParameters = new Dictionary<string, string>();
            requestParameters["multiple_class_id"] = sessionIds; // "24392,24393";           
            return WiZiQHelper.MakeRequest("get_data", requestParameters);
        }
    }
}