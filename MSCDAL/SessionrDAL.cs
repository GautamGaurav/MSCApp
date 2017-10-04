using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSCCommon;
using System.Data;
using System.Data.SqlClient;

namespace MSCDAL
{
    public class SessionDAL
    {

        static readonly SessionDAL _sessionDAL = new SessionDAL();
        private SessionDAL() { }
        public static SessionDAL GetInstance { get { return _sessionDAL; } }
        public static Session Get(long wId)
        {
            Session _session = new Session();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetSessionByWId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@WId", wId));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _session.id = Convert.ToInt32(reader["Id"]);
                        _session.wId = Convert.ToInt32(reader["WId"]);
                        _session.title = Convert.ToString(reader["Title"]);
                        _session.presenterEmail = Convert.ToString(reader["PresenterEmail"]);
                        _session.extendDuration = Convert.ToString(reader["ExtendDuration"]);
                        _session.timeZone = Convert.ToString(reader["TimeZone"]);
                        _session.attendeeLimit = Convert.ToInt32(reader["AttendeeLimit"]);
                        _session.presenterDefaultControls = Convert.ToString(reader["PresenterDefaultControls"]);
                        _session.attendeeDefaultControls = Convert.ToString(reader["AttendeeDefaultControls"]);
                        _session.createRecording = Convert.ToBoolean(reader["CreateRecording"]);
                        _session.returnUrl = Convert.ToString(reader["ReturnUrl"]);
                        _session.statusPingUrl = Convert.ToString(reader["StatusPingUrl"]);
                        //_session.coPresenterUrl = Convert.ToString(reader["CoPresenterUrl"]);

                        _session.batchId = Convert.ToInt32(reader["BatchId"]);
                        _session.batchName = Convert.ToString(reader["BatchName"]);
                        _session.tutorId = Convert.ToInt32(reader["TutorId"]);
                        _session.tutorName = Convert.ToString(reader["TutorName"]);
                        _session.tutorEmail = Convert.ToString(reader["TutorEmail"]);
                        _session.duration = Convert.ToString(reader["Duration"]);
                        _session.attendeeLink = Convert.ToString(reader["AttendeeLink"]);
                        _session.tutorLink = Convert.ToString(reader["TutorLink"]);
                        _session.recordingLink = Convert.ToString(reader["RecordingLink"]);
                        _session.isDelete = Convert.ToBoolean(reader["IsDelete"]);
                        _session.startTime = Convert.ToString(reader["StartTime"]);
                        _session.languageCultureName = Convert.ToString(reader["LanguageCultureName"]);
                        _session.createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                        _session.deletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                        _session.status = 200;
                        _session.message = _session.title + " Class Found.";
                        _session.isError = false;
                    }
                }
                else
                {
                    _session.status = 400;
                    _session.message = "No Class Found.";
                    _session.isError = true;
                }
                con.Close();
            }
            return _session;
        }
        public static List<Session> GetAll()
        {
            List<Session> SessionList = new List<Session>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetAllSession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Session _session = new Session();
                        _session.id = Convert.ToInt32(reader["Id"]);
                        _session.wId = Convert.ToInt32(reader["WId"]);
                        _session.title = Convert.ToString(reader["Title"]);
                        _session.presenterEmail = Convert.ToString(reader["PresenterEmail"]);
                        _session.batchId = Convert.ToInt32(reader["BatchId"]);
                        _session.batchName = Convert.ToString(reader["BatchName"]);
                        _session.tutorId = Convert.ToInt32(reader["TutorId"]);
                        _session.tutorName = Convert.ToString(reader["TutorName"]);
                        _session.duration = Convert.ToString(reader["Duration"]);
                        _session.attendeeLink = Convert.ToString(reader["AttendeeLink"]);
                        _session.tutorLink = Convert.ToString(reader["TutorLink"]);
                        _session.recordingLink = Convert.ToString(reader["RecordingLink"]);
                        _session.isDelete = Convert.ToBoolean(reader["IsDelete"]);
                        _session.startTime = Convert.ToString(reader["StartTime"]);
                        _session.createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                        _session.deletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                        _session.status = 200;
                        _session.message = "Session Found.";
                        _session.isError = false;
                        SessionList.Add(_session);
                    }
                }
                con.Close();
            }
            return SessionList;
        }
        public static Response Create(Session session)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreateSession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@WId", session.wId));
                cmd.Parameters.Add(new SqlParameter("@WMasterId", session.wId));
                cmd.Parameters.Add(new SqlParameter("@Title", session.title));
                cmd.Parameters.Add(new SqlParameter("@TutorId", session.tutorId));
                cmd.Parameters.Add(new SqlParameter("@BatchId", session.batchId));
                cmd.Parameters.Add(new SqlParameter("@PresenterEmail", session.presenterEmail));
                cmd.Parameters.Add(new SqlParameter("@LanguageCultureName", session.languageCultureName));
                cmd.Parameters.Add(new SqlParameter("@Duration", session.duration));
                cmd.Parameters.Add(new SqlParameter("@ExtendDuration", session.extendDuration));
                cmd.Parameters.Add(new SqlParameter("@TimeZone", session.timeZone));
                cmd.Parameters.Add(new SqlParameter("@AttendeeLimit", session.attendeeLimit));
                cmd.Parameters.Add(new SqlParameter("@StartTime", session.startTime));
                cmd.Parameters.Add(new SqlParameter("@PresenterDefaultControls", session.presenterDefaultControls));
                cmd.Parameters.Add(new SqlParameter("@AttendeeDefaultControls", session.attendeeDefaultControls));
                cmd.Parameters.Add(new SqlParameter("@CreateRecording", session.createRecording));
                session.returnUrl = String.IsNullOrEmpty(session.returnUrl) ? "" : session.returnUrl;
                cmd.Parameters.Add(new SqlParameter("@ReturnUrl", session.returnUrl));
                session.statusPingUrl = String.IsNullOrEmpty(session.statusPingUrl) ? "" : session.statusPingUrl;
                cmd.Parameters.Add(new SqlParameter("@StatusPingUrl", session.statusPingUrl));
                cmd.Parameters.Add(new SqlParameter("@AttendeeLink", session.attendeeLink));
                cmd.Parameters.Add(new SqlParameter("@TutorLink", session.tutorLink));
                cmd.Parameters.Add(new SqlParameter("@RecordingLink", session.recordingLink));
                cmd.Parameters.Add(new SqlParameter("@IsDelete", session.isDelete));
                cmd.Parameters.Add(new SqlParameter("@CreatedDate", session.createdDate));
                cmd.Parameters.Add(new SqlParameter("@DeletedDate", session.deletedDate));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
                _response.status = 200;
                _response.message = "Class Created Successfully";
                _response.isError = false;
            }
            return _response;
        }

        public static Response Update(Session session)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UpdateSession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@WId", session.wId));
                cmd.Parameters.Add(new SqlParameter("@Title", session.title));
                cmd.Parameters.Add(new SqlParameter("@StartTime", session.startTime));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
                _response.status = 200;
                _response.message = "Class Update Successfully";
                _response.isError = false;

            }
            return _response;
        }
        public static Response Delete(int id)
        {
            Response response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DeleteSession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        response.status = 200;
                        response.message = "Class Deleted Successfully";
                        response.isError = false;
                    }
                }
                con.Close();
            }
            return response;
        }

        public static Response Cancel(Session session)
        {
            Response response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CancelSession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", session.id));
                cmd.Parameters.Add(new SqlParameter("@WId", session.wId));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                response.status = 200;
                response.message = "Class Canceled Successfully";
                response.isError = false;
                con.Close();
            }
            return response;
        }

        public static void SyncClasses(Session session)
        {
            SessionDAL.Create(session);
        }
    }
}
