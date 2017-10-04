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
    public class SubjectDAL
    {
        static readonly SubjectDAL _subjectDAL = new SubjectDAL();
        private SubjectDAL() { }
        public static SubjectDAL GetInstance { get { return _subjectDAL; } }
        public static Subject Get(int id)
        {
            Subject _subject = new Subject();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetSubjectById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _subject.id = Convert.ToInt32(reader["Id"]);
                        _subject.name = Convert.ToString(reader["Name"]);
                        _subject.description = Convert.ToString(reader["Description"]);
                        _subject.isDelete = Convert.ToBoolean(reader["IsDelete"]);
                        _subject.createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                        _subject.status = 200;
                        _subject.message = _subject.name + " Subject found.";
                        _subject.isError = false;
                    }
                }
                else
                {
                    _subject.status = 400;
                    _subject.message = "No Subject Found.";
                    _subject.isError = true;
                }
                con.Close();
            }
            return _subject;
        }
        public static List<Subject> GetAll()
        {
            List<Subject> subjectList = new List<Subject>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetAllSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Subject _subject = new Subject();
                        _subject.id = Convert.ToInt32(reader["Id"]);
                        _subject.name = Convert.ToString(reader["Name"]);
                        _subject.description = Convert.ToString(reader["Description"]);
                        _subject.isDelete = Convert.ToBoolean(reader["IsDelete"]);
                        _subject.createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                        _subject.status = 200;
                        _subject.message = _subject.name + " Subject found.";
                        _subject.isError = false;
                        subjectList.Add(_subject);
                    }
                }
                con.Close();
            }
            return subjectList;
        } 
        public static Response Create(Subject subject)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreateSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", subject.name));
                cmd.Parameters.Add(new SqlParameter("@Description", subject.description));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
                _response.status = 200;
                _response.message = "Subject Created Successfully";
                _response.isError = false;
            }
            return _response;
        }
        public static Response Update(Subject subject)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UpdateSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _response.status = 200;
                        _response.message = "Login successfully";
                        _response.isError = false;
                    }
                }
                con.Close();
            }
            return _response;
        }
        public static Response Delete(int id)
        {
            Response response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DeleteSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        response.status = 200;
                        response.message = "Login successfully";
                        response.isError = false;
                    }
                }
                con.Close();
            }
            return response;
        }
        public static void SyncSubjects(Subject Subject)
        {
            
        }
    }
}
