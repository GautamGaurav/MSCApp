using System;
using System.Collections.Generic;
using MSCCommon;
using System.Data;
using System.Data.SqlClient;

namespace MSCDAL
{
    public class GradeDAL
    {
        static readonly GradeDAL _gradeDAL = new GradeDAL();
        private GradeDAL() { }
        public static GradeDAL GetInstance { get { return _gradeDAL; } }
        public static Grade Get(long id)
        {
            Grade _grade = new Grade();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetGradeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _grade.id = Convert.ToInt32(reader["Id"]);
                        _grade.name = Convert.ToString(reader["Name"]);
                        _grade.description = Convert.ToString(reader["Description"]);
                        _grade.createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                        _grade.status = 200;
                        _grade.message = _grade.name + " Grade found.";
                        _grade.isError = false;
                    }
                }
                else
                {
                    _grade.status = 400;
                    _grade.message = "No Grade Found.";
                    _grade.isError = true;
                }
                con.Close();
            }
            return _grade;
        }
        public static List<Grade> GetAll()
        {
            List<Grade> gradeList = new List<Grade>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetAllGrade", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Grade _grade = new Grade();
                        _grade.id = Convert.ToInt32(reader["Id"]);
                        _grade.name = Convert.ToString(reader["Name"]);
                        _grade.description = Convert.ToString(reader["Description"]);                        
                        _grade.isDelete = Convert.ToBoolean(reader["isDelete"]);
                        _grade.createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                        _grade.status = 200;
                        _grade.message = _grade.name + " Grade found.";
                        _grade.isError = false;
                        gradeList.Add(_grade);
                    }
                }
                con.Close();
            }
            return gradeList;
        }
        public static Response Create(Grade grade)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreateGrade", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", grade.name));
                cmd.Parameters.Add(new SqlParameter("@Description", grade.description));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
                _response.status = 200;
                _response.message = "Grade Created Successfully";
                _response.isError = false;
            }
            return _response;
        }
        public static Response Update(Grade grade)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UpdateGrade", con);
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
                SqlCommand cmd = new SqlCommand("DeleteGrade", con);
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
        public static void SyncBatchs(Batch Batch)
        {
        }
    }
}
